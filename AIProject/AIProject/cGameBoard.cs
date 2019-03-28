﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class cGameBoard
    {
        bool currentTurn = true;
        bool whiteWon = false;
        bool blackWon = false;
        static public cPiece[,] board = new cPiece[8, 8];

        public cGameBoard()
        {
            InitialiseBoard();
        }
        public cGameBoard(cPiece[,] customBoard)
        {
            board = customBoard;
        }

        private void InitialiseBoard()
        {
            for (int a = 0; a < 8; a++)
            {
                for (int b = 0; b < 8; b++)
                {
                    board[a, b] = null;
                }
            }

            board[0, 0] = new cRook(true);
            board[1, 0] = new cKnight(true);
            board[2, 0] = new cBishop(true);
            board[3, 0] = new cQueen(true);
            board[4, 0] = new King(true);
            board[5, 0] = new cBishop(true);
            board[6, 0] = new cKnight(true);
            board[7, 0] = new cRook(true);

            for (int i = 0; i < 8; i++)
            {
                board[i, 1] = new Pawn(true);
                board[i, 6] = new Pawn(false);
            }

            board[0, 7] = new cRook(false);
            board[1, 7] = new cKnight(false);
            board[2, 7] = new cBishop(false);
            board[3, 7] = new cQueen(false);
            board[4, 7] = new King(false);
            board[5, 7] = new cBishop(false);
            board[6, 7] = new cKnight(false);
            board[7, 7] = new cRook(false);




        }

        public cPiece[,] GameBoard
        {
            get { return board; }
        }

        public void gameLoop()
        {
            SmartAgent myAgent = new SmartAgent();
            while (!whiteWon && !blackWon)
            {
                if (currentTurn)
                {
                    PlayTurn();
                }
                else
                {
                    myAgent.MiniMaxDecision(board,2,currentTurn);
                }
                currentTurn = !currentTurn;
                FindKings();
            }

        }

        private void FindKings()
        {
            bool foundWhiteKing = false;
            bool foundBlackKing = false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (GameBoard[i, j].pieceSymbol == 'K')
                    {
                        if (GameBoard[i, j].PieceTeam == true)
                            foundWhiteKing = true;
                        else
                            foundBlackKing = true;
                    }
                }
            }
            if (!foundBlackKing)
            {
                whiteWon = true;
            }
            if (!foundWhiteKing)
            {
                blackWon = true;
            }

        }

        //function is currently broken
        private void DisplayGameBoard()
        {
            Console.SetCursorPosition(10, 2);
            Console.WriteLine(" |0 1 2 3 4 5 6 7 ");
            for (int i = 0; i < 8; i++)
            {
                Console.SetCursorPosition(10, 3 + i);
                Console.Write(i + "|");
                for (int j = 0; j < 8; j++)
                {
                    if (board[j, i] == null)
                        Console.Write("*|");
                    else
                    {
                        if (board[j, i].PieceTeam == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }

                        Console.Write(board[i, j].pieceSymbol);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|");
                    }

                }

            }
            Console.WriteLine();
        }

        private void PlayTurn()
        {
            //     DisplayGameBoard();
            int currentX, currentY, nextX, nextY;

            do
            {
                Console.WriteLine("Player " + currentTurn + ", play your turn");
                Console.WriteLine("select X axis of piece to move");
                currentX = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("select Y axis of piece to move");
                currentY = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("select X axis of destination");
                nextX = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("select Y axis of destination");
                nextY = Convert.ToInt32(Console.ReadLine());

                //left, top
                /*Console.SetCursorPosition(12 + 2 * currentY, 3 + currentX);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(board[currentX, currentY].pieceSymbol);
                Console.SetCursorPosition(0, 20);*/

            }
            while (!ValidateFieldAndPiece(currentX, currentY, nextX, nextY));
        }

        private bool ValidateFieldAndPiece(int currentX, int currentY, int nextX, int nextY)
        {
            if (GameBoard[currentX, currentY].PieceTeam == currentTurn)
            {
                if (GameBoard[currentX, currentY].MovePiece(new[] { currentX, currentY }, new[] { nextX, nextY }))
                {
                    Console.WriteLine("accepted move");
                    board[nextX, nextY] = board[currentX, currentY];
                    board[currentX, currentY] = null;
                    return true;

                }
                else
                {
                    Console.WriteLine("illegal move, retry");
                    return false;
                }
            }
            else if (GameBoard[currentX, currentY].PieceTeam == !currentTurn)
            {
                Console.WriteLine("this piece belongs to your opponent. retry");
                return false;
            }
            else if (GameBoard[currentX, currentY] == null)
            {
                Console.WriteLine("there is no piece at this field. retry");
                return false;
            }

            else
            {
                Console.WriteLine("unknown error...");
                throw new Exception();
            }
        }
    }
}
