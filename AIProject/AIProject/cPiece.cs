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
        public bool TestValidMove(int[] newPosition, int[] previousPosition, bool pieceTeam, cPiece[,] currentState)
        {
            cPiece[,] tempBoard = new cPiece[8, 8];

            if (currentState == null)
            {
                tempBoard = cGameBoard.board;
            }
            else

            {
                tempBoard = currentState;
            }


            int posX = newPosition[0];
            int posY = newPosition[1];

            if (!ValidatePieceOutOfBounds(newPosition, previousPosition))
            {
                return false;
            }
            // validates that there is no friendly piece at the target location
            if (tempBoard[posX, posY] != null)
            {
                if (tempBoard[posX, posY].pieceTeam == pieceTeam)
                {
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

        public virtual List<cPotentialMove> GetAllValidMoves(cPiece[,] currentState, int[] v1)
        {

            throw new NotImplementedException();
        }

        public bool ListAllRookMoves(int[] currentPosition, int[] newPosition)
        {
            List<int[]> validMoves = new List<int[]>();
            cPiece[,] tempBoard = new cPiece[8, 8];
            tempBoard = cGameBoard.board;
            int[] tempVal = new int[2];
            int posX, posY;


            int[] testingPosition = new int[2];
            testingPosition[0] = currentPosition[0] + 1;
            testingPosition[1] = currentPosition[1];

            while (TestValidMove(testingPosition, currentPosition, PieceTeam, null))
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
            while (TestValidMove(testingPosition, currentPosition, PieceTeam, null))
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
            while (TestValidMove(testingPosition, currentPosition, PieceTeam, null))
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
            while (TestValidMove(testingPosition, currentPosition, PieceTeam, null))
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

            while (TestValidMove(testingPosition, currentPosition, PieceTeam, null))
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
            while (TestValidMove(testingPosition, currentPosition, PieceTeam, null))
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
            while (TestValidMove(testingPosition, currentPosition, PieceTeam, null))
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
            while (TestValidMove(testingPosition, currentPosition, PieceTeam, null))
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

        public List<cPotentialMove> GetAllValidBishopMoves(cPiece[,] currentState, int[] currentPosition)
        {
            List<cPotentialMove> possibleMoves = new List<cPotentialMove>();
            cPiece[,] tempState = new cPiece[8, 8];
            int newX, newY;

            newX = currentPosition[0];
            newY = currentPosition[1];

            tempState = (cPiece[,])currentState.Clone();
            newX++;
            newY++;

            while (TestValidMove(new[] { newX, newY }, currentPosition, PieceTeam, currentState))
            {
                tempState = (cPiece[,])currentState.Clone();


                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX , newY }, tempState));
                newX++;
                newY++;


            }


            newX = currentPosition[0];
            newY = currentPosition[1];

            tempState = (cPiece[,])currentState.Clone();
            newX++;
            newY--;

            while (TestValidMove(new[] { newX, newY }, currentPosition, PieceTeam, currentState))
            {
                tempState = (cPiece[,])currentState.Clone();


                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY }, tempState));
                newX++;
                newY--;

            }

            newX = currentPosition[0];
            newY = currentPosition[1];

            tempState = (cPiece[,])currentState.Clone();
            newX--;
            newY++;

            while (TestValidMove(new[] { newX, newY }, currentPosition, PieceTeam, currentState))
            {
                tempState = (cPiece[,])currentState.Clone();


                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY }, tempState));
                newX--;
                newY++;

            }

            newX = currentPosition[0];
            newY = currentPosition[1];

            tempState = (cPiece[,])currentState.Clone();
            newX--;
            newY--;

            while (TestValidMove(new[] { newX, newY }, currentPosition, PieceTeam, currentState))
            {
                tempState = (cPiece[,])currentState.Clone();


                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY }, tempState));
                newX--;
                newY--;

            }

            return possibleMoves;
        }

        public List<cPotentialMove> GetAllValidRookMoves(cPiece[,] currentState, int[] currentPosition)
        {
            List<cPotentialMove> possibleMoves = new List<cPotentialMove>();
            cPiece[,] tempState = new cPiece[8, 8];
            int newX, newY;

            newX = currentPosition[0];
            newY = currentPosition[1];

            tempState = (cPiece[,])currentState.Clone();
            newX++;

            while (TestValidMove(new[] { newX, newY }, currentPosition, PieceTeam, currentState))
            {
                tempState = (cPiece[,])currentState.Clone();


                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY }, tempState));
                newX++;

            }


            newX = currentPosition[0];
            newY = currentPosition[1];

            tempState = (cPiece[,])currentState.Clone();
            newY++;

            while (TestValidMove(new[] { newX, newY }, currentPosition, PieceTeam, currentState))
            {
                tempState = (cPiece[,])currentState.Clone();


                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY }, tempState));
                newY++;

            }

            newX = currentPosition[0];
            newY = currentPosition[1];

            tempState = (cPiece[,])currentState.Clone();
            newX--;

            while (TestValidMove(new[] { newX, newY }, currentPosition, PieceTeam, currentState))
            {
                tempState = (cPiece[,])currentState.Clone();


                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY }, tempState));
                newX--;

            }

            newX = currentPosition[0];
            newY = currentPosition[1];

            tempState = (cPiece[,])currentState.Clone();
            newY--;

            while (TestValidMove(new[] { newX, newY }, currentPosition, PieceTeam, currentState))
            {
                tempState = (cPiece[,])currentState.Clone();


                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY }, tempState));
                newY--;

            }

            return possibleMoves;
        }



    }
}
