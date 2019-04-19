//-----------------------------------------------------------------------
// <copyright file="cGameBoard.cs"  >
//     Copyright (c) 8INF700. All rights reserved.
//      Name: Hans Darmstadt-Bélanger
//      Goal: Manage the game logic
//      Date: 18/04/2019
// </copyright>
//-----------------------------------------------------------------------

namespace AIProject
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Contains the game management logic
    /// </summary>
    public class GameBoard
    {
        #region properties
        /// <summary>
        /// The gameboard
        /// </summary>
        private static Piece[,] board = new Piece[8, 8];

        /// <summary>
        /// The current player's turn
        /// </summary>
        private bool currentTurn = true;

        /// <summary>
        /// Gets the game board.
        /// </summary>
        /// <value>
        /// The game board.
        /// </value>
        public static Piece[,] GetGameBoard
        {
            get { return board; }
        }
        #endregion
        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="GameBoard"/> class.
        /// </summary>
        public GameBoard()
        {
            InitialiseBoard();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameBoard"/> class.
        /// </summary>
        /// <param name="customBoard">The custom board used for unit tests mocking.</param>
        public GameBoard(Piece[,] customBoard)
        {
            board = customBoard;
        }
        #endregion

        #region public methods
        /// <summary>
        /// The main game loop. plays while both kings are still standing.
        /// </summary>
        public void GameLoop()
        {
            DisplayGameBoard();
            SmartAgent myAgent = new SmartAgent();
            while (FindKings())
            {
                if (currentTurn)
                {
                    // List<cPotentialMove> chosenMoveList = myAgent.MiniMaxDecision(board, 5, currentTurn, null, null, -999, 999);
                    // cPotentialMove chosenMove = chosenMoveList[chosenMoveList.Count - 2];
                    // ValidateFieldAndPiece(chosenMove.PreviousPosition[0], chosenMove.PreviousPosition[1], chosenMove.NewPosition[0], chosenMove.NewPosition[1]);
                    PlayTurn();
                    DisplayGameBoard();
                }
                else
                {
                    List<PotentialMove> chosenMoveList = myAgent.MiniMaxDecision(board, 10, currentTurn, null, null, -999, 999);
                    PotentialMove chosenMove = chosenMoveList[chosenMoveList.Count - 2];
                    ValidateFieldAndPiece(chosenMove.PreviousPosition[0], chosenMove.PreviousPosition[1], chosenMove.NewPosition[0], chosenMove.NewPosition[1]);
                    DisplayGameBoard();
                    Console.WriteLine("Player " + currentTurn + " brought piece from field " + chosenMove.PreviousPosition[0] + "," + chosenMove.PreviousPosition[1] + " to field " + chosenMove.NewPosition[0] + "," + chosenMove.NewPosition[1]);
                }

                currentTurn = !currentTurn;
            }

            DisplayGameBoard();
        }

        #endregion

        #region private methods
        /// <summary>
        /// Initialises the board to its default state.
        /// </summary>
        private void InitialiseBoard()
        {
            for (int a = 0; a < 8; a++)
            {
                for (int b = 0; b < 8; b++)
                {
                    board[a, b] = null;
                }
            }

            board[0, 0] = new Rook(true);
            board[1, 0] = new Knight(true);
            board[2, 0] = new Bishop(true);
            board[3, 0] = new Queen(true);
            board[4, 0] = new King(true);
            board[5, 0] = new Bishop(true);
            board[6, 0] = new Knight(true);
            board[7, 0] = new Rook(true);

            for (int i = 0; i < 8; i++)
            {
                board[i, 1] = new Pawn(true);
                board[i, 6] = new Pawn(false);
            }

            board[0, 7] = new Rook(false);
            board[1, 7] = new Knight(false);
            board[2, 7] = new Bishop(false);
            board[3, 7] = new Queen(false);
            board[4, 7] = new King(false);
            board[5, 7] = new Bishop(false);
            board[6, 7] = new Knight(false);
            board[7, 7] = new Rook(false);
        }

        /// <summary>
        /// Finds the kings to detect an endgame
        /// </summary>
        /// <returns>werther the game is over or not</returns>
        public void gameLoop()
        {

            DisplayGameBoard();
            SmartAgent myAgent = new SmartAgent();
            while (FindKings())
            {

                if (currentTurn)
                {
                    //List<cPotentialMove> chosenMoveList = myAgent.MiniMaxDecision(board, 5, currentTurn, null, null, -999, 999);
                    //cPotentialMove chosenMove = chosenMoveList[chosenMoveList.Count - 2];
                    //ValidateFieldAndPiece(chosenMove.PreviousPosition[0], chosenMove.PreviousPosition[1], chosenMove.NewPosition[0], chosenMove.NewPosition[1]);

                    PlayTurn();
                    DisplayGameBoard();

                }
                else
                {

                    List<PotentialMove> chosenMoveList = myAgent.MiniMaxDecision(board, 6, currentTurn, null, null, -999, 999);
                    PotentialMove chosenMove = chosenMoveList[chosenMoveList.Count - 2];
                    ValidateFieldAndPiece(chosenMove.PreviousPosition[0], chosenMove.PreviousPosition[1], chosenMove.NewPosition[0], chosenMove.NewPosition[1]);
                    DisplayGameBoard();
                    Console.WriteLine("Player " + currentTurn + " brought piece from field " + chosenMove.PreviousPosition[0] + "," + chosenMove.PreviousPosition[1] + " to field " + chosenMove.NewPosition[0] + "," + chosenMove.NewPosition[1]);
;
                }
                currentTurn = !currentTurn;
            }
            DisplayGameBoard();

        }
        private bool FindKings()
        {
            bool foundWhiteKing = false;
            bool foundBlackKing = false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (GetGameBoard[i, j] != null && GetGameBoard[i, j].PieceSymbol == 'K')
                    {
                        if (GetGameBoard[i, j].PieceTeam == true)
                        {
                            foundWhiteKing = true;
                        }
                        else
                        {
                            foundBlackKing = true;
                        }
                    }
                }
            }

            return foundBlackKing && foundWhiteKing;
        }

        /// <summary>
        /// Displays the gameboard to the console
        /// </summary>
        private void DisplayGameBoard()
        {
            Console.Clear();
            Console.SetCursorPosition(10, 2);
            Console.WriteLine(" |0 1 2 3 4 5 6 7 ");
            for (int i = 0; i < 8; i++)
            {
                Console.SetCursorPosition(10, 3 + i);
                Console.Write(i + "|");
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == null)
                    {
                        Console.Write("*|");
                    }
                    else
                    {
                        if (board[i, j].PieceTeam == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }

                        if (board[i, j] != null)
                        {
                            Console.Write(board[i, j].PieceSymbol);
                        }
                        else
                        {
                            Console.WriteLine(" ");
                        }

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|");
                    }
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// The prompts to te get a player's move
        /// </summary>
        private void PlayTurn()
        {
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
            }
            while (!ValidateFieldAndPiece(currentX, currentY, nextX, nextY));
            Console.WriteLine("Game over!");
            Console.ReadLine();
        }

        /// <summary>
        /// Validates whether a move is valid or not
        /// </summary>
        /// <param name="currentX">current X axis of piece to move</param>
        /// <param name="currentY">current Y axis of piece to move</param>
        /// <param name="nextX">target X axis of piece to move</param>
        /// <param name="nextY">target Y axis of piece to move</param>
        /// <returns>whether the attemempted move is vaild or not</returns>
        private bool ValidateFieldAndPiece(int currentX, int currentY, int nextX, int nextY)
        {
            if (GetGameBoard[currentX, currentY] != null && GetGameBoard[currentX, currentY].PieceTeam == currentTurn)
            {
                if (GetGameBoard[currentX, currentY].TestValidMove(new[] { currentX, currentY }, new[] { nextX, nextY }))
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
            else if (GetGameBoard[currentX, currentY] != null && GetGameBoard[currentX, currentY].PieceTeam == !currentTurn)
            {
                Console.WriteLine("this piece belongs to your opponent. retry");
                return false;
            }
            else if (GetGameBoard[currentX, currentY] == null)
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
        #endregion
    }
}