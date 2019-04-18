//-----------------------------------------------------------------------
// <copyright file = "Piece.cs" >
//     Copyright(c) 8INF700.All rights reserved.
//    Name: Hans Darmstadt-Bélanger
//    Goal: To manage the piece's core logic
//    Date: 18/04/2019
// </copyright>
//-----------------------------------------------------------------------

namespace AIProject
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Contains the piece's attributes and core logic
    /// </summary>
    public class Piece : IPiece
    {
        #region Attributes
        /// <summary>
        /// The value/weight of the piece
        /// </summary>
        private readonly int pieceValue;

        /// <summary>
        /// The piece's team
        /// </summary>
        private bool pieceTeam;

        /// <summary>
        /// The piece's symbol when displayed to the console
        /// </summary>
        private char pieceSymbol;

        /// <summary>
        /// Gets the piece's symbol
        /// </summary>
        public char PieceSymbol
        {
            get { return this.pieceSymbol; }
        }

        /// <summary>
        /// Gets the piece's team
        /// </summary>
        public bool PieceTeam
        {
            get { return this.pieceTeam; }
        }

        /// <summary>
        /// Gets the piece's value/weight
        /// </summary>
        public int PieceValue
        {
            get { return this.pieceValue; }
        }

        #endregion

        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="Piece" /> class.
        /// </summary>
        /// <param name="team">the piece's team</param>
        /// <param name="value">the piece's value</param>
        /// <param name="symbol">the piece,s symbol</param>
        public Piece(bool team, int value, char symbol)
        {
            pieceTeam = team;
            pieceValue = value;
            pieceSymbol = symbol;
        }
        #endregion

        #region public methods

        /// <summary>
        /// Tests the validity of an attempted move
        /// </summary>
        /// <param name="newPosition">The piece's target position</param>
        /// <param name="previousPosition">The piece's previous position</param>
        /// <param name="pieceTeam">The piece's team</param>
        /// <param name="currentState">The gameboard's current state</param>
        /// <returns>Whether the attempted move is valid</returns>
        public bool TestValidMove(int[] newPosition, int[] previousPosition, bool pieceTeam, Piece[,] currentState)
        {
            Piece[,] tempBoard = new Piece[8, 8];

            if (currentState == null)
            {
                tempBoard = CGameBoard.GetGameBoard;
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

        /// <summary>
        /// The generic MovePiece method.
        /// It should never be called 
        /// </summary>
        /// <param name="v1">Previous position</param>
        /// <param name="v2">Target position</param>
        /// <returns>The move is invalid</returns>
        public virtual bool MovePiece(int[] v1, int[] v2)
        {
            Console.WriteLine("Not implemented error:");
            Console.WriteLine("Trying to move piece from field " + v1[0] + "," + v1[1]);
            Console.WriteLine("Hit enter to continue");
            Console.ReadLine();
            return false;

            // throw new NotImplementedException();
        }

        /// <summary>
        /// The base GetAllValidMoves function.
        /// This function is always overritten and should never be called
        /// </summary>
        /// <param name="currentState">The current game's state</param>
        /// <param name="v1">The target piece's position</param>
        /// <returns>no value</returns>
        public virtual List<PotentialMove> GetAllValidMoves(Piece[,] currentState, int[] v1)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validates whether an attempted move is valid
        /// </summary>
        /// <param name="currentPosition">the rook's current position</param>
        /// <param name="newPosition">The move's target position</param>
        /// <returns>the validity of the attempted move</returns>
        public bool TestValidRookMove(int[] currentPosition, int[] newPosition)
        {
            List<int[]> validMoves = new List<int[]>();
            Piece[,] tempBoard = new Piece[8, 8];
            tempBoard = CGameBoard.GetGameBoard;
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

            foreach (var v in validMoves)
            {
                if (v[0] == newPosition[0] && v[1] == newPosition[1])
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Validates whether an attempted move is valid
        /// </summary>
        /// <param name="currentPosition">the bishop's current position</param>
        /// <param name="newPosition">The move's target position</param>
        /// <returns>the validity of the attempted move</returns>
        public bool ListAllBishopMoves(int[] currentPosition, int[] newPosition)
        {
            List<int[]> validMoves = new List<int[]>();
            Piece[,] tempBoard = new Piece[8, 8];
            tempBoard = CGameBoard.GetGameBoard;
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

        /// <summary>
        /// Gets all bishop valid moves
        /// </summary>
        /// <param name="currentState">The game's current state</param>
        /// <param name="currentPosition">The bishop's current position</param>
        /// <returns>A list of all valid moves found</returns>
        public List<PotentialMove> TestValidBishopMove(Piece[,] currentState, int[] currentPosition)
        {
            List<PotentialMove> possibleMoves = new List<PotentialMove>();
            Piece[,] tempState = new Piece[8, 8];
            int newX, newY;

            newX = currentPosition[0];
            newY = currentPosition[1];

            tempState = (Piece[,])currentState.Clone();
            newX++;
            newY++;

            while (TestValidMove(new[] { newX, newY }, currentPosition, PieceTeam, currentState))
            {
                tempState = (Piece[,])currentState.Clone();

                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY }, tempState));
                if (currentState[newX, newY] != null && currentState[newX, newY].PieceTeam != currentState[currentPosition[0], currentPosition[1]].pieceTeam)
                {
                    break;
                }

                newX++;
                newY++;
            }

            newX = currentPosition[0];
            newY = currentPosition[1];

            tempState = (Piece[,])currentState.Clone();
            newX++;
            newY--;

            while (TestValidMove(new[] { newX, newY }, currentPosition, PieceTeam, currentState))
            {
                tempState = (Piece[,])currentState.Clone();

                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY }, tempState));
                if (currentState[newX, newY] != null && currentState[newX, newY].PieceTeam != currentState[currentPosition[0], currentPosition[1]].pieceTeam)
                {
                    break;
                }

                newX++;
                newY--;
            }

            newX = currentPosition[0];
            newY = currentPosition[1];

            tempState = (Piece[,])currentState.Clone();
            newX--;
            newY++;

            while (TestValidMove(new[] { newX, newY }, currentPosition, PieceTeam, currentState))
            {
                tempState = (Piece[,])currentState.Clone();

                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY }, tempState));
                if (currentState[newX, newY] != null && currentState[newX, newY].PieceTeam != currentState[currentPosition[0], currentPosition[1]].pieceTeam)
                {
                    break;
                }

                newX--;
                newY++;
            }

            newX = currentPosition[0];
            newY = currentPosition[1];

            tempState = (Piece[,])currentState.Clone();
            newX--;
            newY--;

            while (TestValidMove(new[] { newX, newY }, currentPosition, PieceTeam, currentState))
            {
                tempState = (Piece[,])currentState.Clone();

                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY }, tempState));
                if (currentState[newX, newY] != null && currentState[newX, newY].PieceTeam != currentState[currentPosition[0], currentPosition[1]].pieceTeam)
                {
                    break;
                }

                newX--;
                newY--;
            }

            return possibleMoves;
        }

        /// <summary>
        /// Gets all rook valid moves
        /// </summary>
        /// <param name="currentState">The game's current state</param>
        /// <param name="currentPosition">The rook's current position</param>
        /// <returns>A list of all valid moves found</returns>
        public List<PotentialMove> GetAllValidRookMoves(Piece[,] currentState, int[] currentPosition)
        {
            List<PotentialMove> possibleMoves = new List<PotentialMove>();
            Piece[,] tempState = new Piece[8, 8];
            int newX, newY;

            newX = currentPosition[0];
            newY = currentPosition[1];

            tempState = (Piece[,])currentState.Clone();
            newX++;

            while (TestValidMove(new[] { newX, newY }, currentPosition, PieceTeam, currentState))
            {
                tempState = (Piece[,])currentState.Clone();

                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY }, tempState));
                if (currentState[newX, newY] != null && currentState[newX, newY].PieceTeam != currentState[currentPosition[0], currentPosition[1]].pieceTeam)
                {
                    break;
                }

                newX++;
            }

            newX = currentPosition[0];
            newY = currentPosition[1];

            tempState = (Piece[,])currentState.Clone();
            newY++;

            while (TestValidMove(new[] { newX, newY }, currentPosition, PieceTeam, currentState))
            {
                tempState = (Piece[,])currentState.Clone();

                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY }, tempState));
                if (currentState[newX, newY] != null && currentState[newX, newY].PieceTeam != currentState[currentPosition[0], currentPosition[1]].pieceTeam)
                {
                    break;
                }

                newY++;
            }

            newX = currentPosition[0];
            newY = currentPosition[1];

            tempState = (Piece[,])currentState.Clone();
            newX--;

            while (TestValidMove(new[] { newX, newY }, currentPosition, PieceTeam, currentState))
            {
                tempState = (Piece[,])currentState.Clone();

                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY }, tempState));
                if (currentState[newX, newY] != null && currentState[newX, newY].PieceTeam != currentState[currentPosition[0], currentPosition[1]].pieceTeam)
                {
                    break;
                }

                newX--;
            }

            newX = currentPosition[0];
            newY = currentPosition[1];

            tempState = (Piece[,])currentState.Clone();
            newY--;

            while (TestValidMove(new[] { newX, newY }, currentPosition, PieceTeam, currentState))
            {
                tempState = (Piece[,])currentState.Clone();

                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY }, tempState));
                if (currentState[newX, newY] != null && currentState[newX, newY].PieceTeam != currentState[currentPosition[0], currentPosition[1]].pieceTeam)
                {
                    break;
                }

                newY--;
            }

            return possibleMoves;
        }
        #endregion

        #region private methods

        /// <summary>
        /// Validates whether the an attempted move would bring the piece out of bounds
        /// </summary>
        /// <param name="newPosition">the target position of a given move</param>
        /// <param name="previousPosition">the piece's prevoious position</param>
        /// <returns>whether the attempted move is out of bounds</returns>
        private static bool ValidatePieceOutOfBounds(int[] newPosition, int[] previousPosition)
        {
            if (newPosition[0] <= 7 && newPosition[0] >= 0 && newPosition[1] <= 7 && newPosition[1] >= 0 && newPosition != previousPosition)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}