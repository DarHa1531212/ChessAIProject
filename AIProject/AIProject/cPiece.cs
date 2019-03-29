using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class cPiece : IPiece
    {
        private int pieceValue;
        private bool pieceTeam;
        public char pieceSymbol;
        public cPiece(bool team, int value, char symbol)
        {
            pieceTeam = team;
            pieceValue = value;
            pieceSymbol = symbol;
        }
        public bool PieceTeam
        {
            get { return this.pieceTeam; }
        }
        public int PieceValue
        {
            get { return this.pieceValue; }
        }

        //returns true if move is valid and false if invalid
        public bool TestValidMove(int[] newPosition, int[] previousPosition, bool pieceTeam)
        {
            cPiece[,] tempBoard = new cPiece[8, 8];
            tempBoard = cGameBoard.board;
            int posX = newPosition[0];
            int posY = newPosition[1];

            if (!ValidatePieceOutOfBounds(newPosition, previousPosition))
            {
                return false;
            }
            // validates that there is no friendly piece at the target location
            if (tempBoard[posX, posY] != null)
            {
                Console.WriteLine("field is not null");
                if (tempBoard[posX, posY].pieceTeam == pieceTeam)
                {
                    Console.WriteLine("piece's team on this field: " + tempBoard[posX, posY].pieceTeam);
                    Console.WriteLine("this piece's team: " + pieceTeam);
                    return false;

                }
            }
            return true;

        }


        private static bool ValidatePieceOutOfBounds(int[] newPosition, int[] previousPosition)
        {
            if (newPosition[0] <= 7 && newPosition[0] >= 0 && newPosition[1] <= 7 && newPosition[1] >= 0 && newPosition != previousPosition)
                return true;
            else return false;
        }

        public void MovePiece()
        {
            throw new NotImplementedException();
        }

        public virtual bool MovePiece(int[] v1, int[] v2)
        {
            throw new NotImplementedException();
        }

        public virtual List<cPiece[,]> GetAllValidMoves(cPiece[,] currentState, int [] v1)
        {
            
            throw new NotImplementedException();
        }

        public bool GetAllRookMoves(int[] currentPosition, int[] newPosition)
        {
            List<int[]> validMoves = new List<int[]>();
            cPiece[,] tempBoard = new cPiece[8, 8];
            tempBoard = cGameBoard.board;
            int[] tempVal = new int[2];
            int posX, posY;


            int[] testingPosition = new int[2];
            testingPosition[0] = currentPosition[0] + 1;
            testingPosition[1] = currentPosition[1];

            while (TestValidMove(testingPosition, currentPosition, PieceTeam))
            {

                tempVal[0] = testingPosition[0];
                tempVal[1] = currentPosition[1];
                validMoves.Add(new[] { tempVal[0], tempVal[1] });
                testingPosition[0]++;
                posX = tempVal[0];
                posY = tempVal[1];
                if (tempBoard[posX, posY] != null)
                {
                    break;
                }
            }

            testingPosition[0] = currentPosition[0] - 1;
            testingPosition[1] = currentPosition[1];
            while (TestValidMove(testingPosition, currentPosition, PieceTeam))
            {
                tempVal[0] = testingPosition[0];
                tempVal[1] = currentPosition[1];
                validMoves.Add(new[] { tempVal[0], tempVal[1] });
                testingPosition[0]--;
                posX = tempVal[0];
                posY = tempVal[1];
                if (tempBoard[posX, posY] != null)
                {
                    break;
                }

            }

            testingPosition[1] = currentPosition[1] + 1;
            testingPosition[0] = currentPosition[0];
            while (TestValidMove(testingPosition, currentPosition, PieceTeam))
            {
                tempVal[1] = testingPosition[1];
                tempVal[0] = currentPosition[0];
                validMoves.Add(new[] { tempVal[0], tempVal[1] });
                testingPosition[1]++;
                posX = tempVal[0];
                posY = tempVal[1];
                if (tempBoard[posX, posY] != null)
                {
                    break;
                }

            }

            testingPosition[1] = currentPosition[1] - 1;
            testingPosition[0] = currentPosition[0];
            while (TestValidMove(testingPosition, currentPosition, PieceTeam))
            {
                tempVal[1] = testingPosition[1];
                tempVal[0] = currentPosition[0];
                validMoves.Add(new[] { tempVal[0], tempVal[1] });
                testingPosition[1]--;
                posX = tempVal[0];
                posY = tempVal[1];
                if (tempBoard[posX, posY] != null)
                {
                    break;
                }

            }

            foreach (var x in validMoves)
            {
                if (x[0] == newPosition[0] && x[1] == newPosition[1])
                {
                    return true;
                }
            }

            return false;
        }



        public bool ListAllBishopMoves(int[] currentPosition, int[] newPosition)
        {
            List<int[]> validMoves = new List<int[]>();
            cPiece[,] tempBoard = new cPiece[8, 8];
            tempBoard = cGameBoard.board;
            int[] tempVal = new int[2];
            int posX, posY;


            int[] testingPosition = new int[2];
            testingPosition[0] = currentPosition[0] + 1;
            testingPosition[1] = currentPosition[1] + 1;

            while (TestValidMove(testingPosition, currentPosition, PieceTeam))
            {

                tempVal[0] = testingPosition[0];
                tempVal[1] = testingPosition[1];
                validMoves.Add(new[] { tempVal[0], tempVal[1] });
                testingPosition[0]++;
                testingPosition[1]++;
                posX = tempVal[0];
                posY = tempVal[1];
                if (tempBoard[posX, posY] != null)
                {
                    break;
                }
            }

            testingPosition[0] = currentPosition[0] + 1;
            testingPosition[1] = currentPosition[1] - 1;
            while (TestValidMove(testingPosition, currentPosition, PieceTeam))
            {
                tempVal[0] = testingPosition[0];
                tempVal[1] = testingPosition[1];
                validMoves.Add(new[] { tempVal[0], tempVal[1] });
                testingPosition[0]++;
                testingPosition[1]--;
                posX = tempVal[0];
                posY = tempVal[1];
                if (tempBoard[posX, posY] != null)
                {
                    break;
                }

            }

            testingPosition[0] = currentPosition[0] - 1;
            testingPosition[1] = currentPosition[1] + 1;
            while (TestValidMove(testingPosition, currentPosition, PieceTeam))
            {
                tempVal[0] = testingPosition[0];
                tempVal[1] = testingPosition[1];
                validMoves.Add(new[] { tempVal[0], tempVal[1] });
                testingPosition[0]--;
                testingPosition[1]++;
                posX = tempVal[0];
                posY = tempVal[1];
                if (tempBoard[posX, posY] != null)
                {
                    break;
                }

            }

            testingPosition[1] = currentPosition[1] - 1;
            testingPosition[0] = currentPosition[0] - 1;
            while (TestValidMove(testingPosition, currentPosition, PieceTeam))
            {
                tempVal[1] = testingPosition[1];
                tempVal[0] = testingPosition[0];
                validMoves.Add(new[] { tempVal[0], tempVal[1] });
                testingPosition[0]--;
                testingPosition[1]--;
                posX = tempVal[0];
                posY = tempVal[1];
                if (tempBoard[posX, posY] != null)
                {
                    break;
                }

            }

            foreach (var x in validMoves)
            {
                if (x[0] == newPosition[0] && x[1] == newPosition[1])
                {
                    return true;
                }
            }

            return false;
        }

    }
}
