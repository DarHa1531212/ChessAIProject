//-----------------------------------------------------------------------
// <copyright file="Pawn.cs" company = "8INF700" >
//     Copyright (c) 8INF700. All rights reserved.
//      Name: Hans Darmstadt-Bélanger
//      Goal: The controller for the pawns
//      Date: 12/02/2019
// </copyright>
//-----------------------------------------------------------------------

namespace AIProject
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains pawn related logic
    /// </summary>
    public class Pawn : Piece
    {
        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="Pawn" /> class.
        /// </summary>
        /// <param name="pawnTeam">the pawn's team</param>
        public Pawn(bool pawnTeam) : base(pawnTeam, 1, 'P')
        {
        }

        #endregion

        #region public methods
        /// <summary>
        /// Test wherther an attempted move is valid
        /// </summary>
        /// <param name="currentPosition">The pawn's current position</param>
        /// <param name="targetPosition">The pawn's target position</param>
        /// <returns>The validity of the attempted move</returns>
        public override bool TestValidMove(int[] currentPosition, int[] targetPosition)
        {
            if (ValidatePawnMove(currentPosition, targetPosition, null))
            {
                if (TestValidMove(targetPosition, currentPosition, this.PieceTeam, null))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets all valid moves
        /// </summary>
        /// <param name="currentState">The current state of the game</param>
        /// <param name="currentPosition">the pawn's current position</param>
        /// <returns>the list of valid moves</returns>
        public override List<PotentialMove> GetAllValidMoves(Piece[,] currentState, int[] currentPosition)
        {
            List<PotentialMove> possibleMoves = new List<PotentialMove>();
            Piece[,] tempState = new Piece[8, 8];
            int newX, newY;

            if (PieceTeam == true)
            {
                newX = currentPosition[0];
                newY = currentPosition[1];
                newY++;
                if (ValidatePawnMove(currentPosition, new[] { newX, newY }, currentState))
                {
                    tempState = (Piece[,])currentState.Clone();
                    tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                    tempState[currentPosition[0], currentPosition[1]] = null;
                    possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY }, tempState));
                }

                if (ValidatePawnMove(currentPosition, new[] { newX + 1, newY }, currentState))
                {
                    tempState = (Piece[,])currentState.Clone();
                    tempState[newX + 1, newY] = tempState[currentPosition[0], currentPosition[1]];
                    tempState[currentPosition[0], currentPosition[1]] = null;
                    possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX + 1, newY }, tempState));
                }

                if (ValidatePawnMove(currentPosition, new[] { newX - 1, newY }, currentState))
                {
                    tempState = (Piece[,])currentState.Clone();
                    tempState[newX - 1, newY] = tempState[currentPosition[0], currentPosition[1]];
                    tempState[currentPosition[0], currentPosition[1]] = null;
                    possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX - 1, newY }, tempState));
                }

                if (ValidatePawnMove(currentPosition, new[] { newX, newY + 1 }, currentState))
                {
                    tempState = (Piece[,])currentState.Clone();
                    tempState[newX, newY + 1] = tempState[currentPosition[0], currentPosition[1]];
                    tempState[currentPosition[0], currentPosition[1]] = null;
                    possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY + 1 }, tempState));
                }
            }
            else if (PieceTeam == false)
            {
                newX = currentPosition[0];
                newY = currentPosition[1];
                newY--;
                if (ValidatePawnMove(currentPosition, new[] { newX, newY }, currentState))
                {
                    tempState = (Piece[,])currentState.Clone();
                    tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                    tempState[currentPosition[0], currentPosition[1]] = null;
                    possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY }, tempState));
                }

                if (ValidatePawnMove(currentPosition, new[] { newX + 1, newY }, currentState))
                {
                    tempState = (Piece[,])currentState.Clone();
                    tempState[newX + 1, newY] = tempState[currentPosition[0], currentPosition[1]];
                    tempState[currentPosition[0], currentPosition[1]] = null;
                    possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX + 1, newY }, tempState));
                }

                if (ValidatePawnMove(currentPosition, new[] { newX - 1, newY }, currentState))
                {
                    tempState = (Piece[,])currentState.Clone();
                    tempState[newX - 1, newY] = tempState[currentPosition[0], currentPosition[1]];
                    tempState[currentPosition[0], currentPosition[1]] = null;
                    possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX - 1, newY }, tempState));
                }

                if (ValidatePawnMove(currentPosition, new[] { newX, newY - 1 }, currentState))
                {
                    tempState = (Piece[,])currentState.Clone();
                    tempState[newX, newY - 1] = tempState[currentPosition[0], currentPosition[1]];
                    tempState[currentPosition[0], currentPosition[1]] = null;
                    possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY - 1 }, tempState));
                }
            }

            return possibleMoves;
        }

        #endregion

        #region private methods

        /// <summary>
        /// validates wherther a pawn can make a given move
        /// </summary>
        /// <param name="currentPosition">The pawn's current position </param>
        /// <param name="nextPosition">The pawn's target position</param>
        /// <param name="currentState">The gameboard's current state</param>
        /// <returns>The validity of the move</returns>
        private bool ValidatePawnMove(int[] currentPosition, int[] nextPosition, Piece[,] currentState)
        {
            if (currentState == null)
            {
                currentState = GameBoard.GetGameBoard;
            }

            int posX = nextPosition[0];
            int posY = nextPosition[1];

            if (posX < 0 || posX > 7 || posY < 0 || posY > 7)
            {
                return false;
            }

            // advanced in the right direction
            if ((PieceTeam == true && nextPosition[1] - currentPosition[1] == 1) || (PieceTeam == false && currentPosition[1] - nextPosition[1] == 1))
            {
                if (currentPosition[0] == nextPosition[0] && currentState[posX, posY] == null)
                {
                    return true;
                }
                else if (currentPosition[0] == nextPosition[0] + 1 || currentPosition[0] == nextPosition[0] - 1)
                {
                    if (currentState[posX, posY] != null && currentState[posX, posY].PieceTeam != PieceTeam)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (this.PieceTeam == true && currentPosition[1] == 1 && nextPosition[1] == 3 && currentPosition[0] == nextPosition[0] && currentState[currentPosition[0], 2] == null && currentState[currentPosition[0], 3] == null)
            {
                return true;
            }
            else if (this.PieceTeam == false && currentPosition[1] == 6 && nextPosition[1] == 4 && currentPosition[0] == nextPosition[0] && currentState[currentPosition[0], 5] == null && currentState[currentPosition[0], 4] == null)
            {
                return true;
            }

            // did not advance straight or too much
            return false;
        }

        #endregion
    }
}
