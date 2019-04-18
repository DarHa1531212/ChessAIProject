//-----------------------------------------------------------------------
// <copyright file="Knight.cs"  >
//     Copyright (c) 8INF700. All rights reserved.
//      Name: Hans Darmstadt-Bélanger
//      Goal: Manage the Knight related logic
//      Date: 18/04/2019
// </copyright>
//-----------------------------------------------------------------------

namespace AIProject
{
    using System.Collections.Generic;

    /// <summary>
    /// The knight related logic
    /// </summary>
    public class Knight : Piece
    {
        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="Knight" /> class.
        /// </summary>
        /// <param name="knightTeam">The knight's team</param>
        public Knight(bool knightTeam) : base(knightTeam, 3, 'T')
        {
        }
        #endregion

        #region public methods
        /// <summary>
        /// Gets all moves a given knight could make
        /// </summary>
        /// <param name="currentState">TYhe game's current state</param>
        /// <param name="currentPosition">The knight's current position</param>
        /// <returns>The list of valid moves</returns>
        public override List<PotentialMove> GetAllValidMoves(Piece[,] currentState, int[] currentPosition)
        {
            List<PotentialMove> possibleMoves = new List<PotentialMove>();
            Piece[,] tempState = new Piece[8, 8];
            int newX, newY;

            newX = currentPosition[0] - 1;
            newY = currentPosition[1] - 2;
            tempState = (Piece[,])currentState.Clone();

            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, currentState))
            {
                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY }, tempState));
            }

            newX = currentPosition[0] + 1;
            newY = currentPosition[1] - 2;
            tempState = (Piece[,])currentState.Clone();

            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, currentState))
            {
                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY }, tempState));
            }

            newX = currentPosition[0] - 1;
            newY = currentPosition[1] + 2;
            tempState = (Piece[,])currentState.Clone();

            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, currentState))
            {
                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY }, tempState));
            }

            newX = currentPosition[0] + 1;
            newY = currentPosition[1] + 2;
            tempState = (Piece[,])currentState.Clone();

            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, currentState))
            {
                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY }, tempState));
            }

            newX = currentPosition[0] + 2;
            newY = currentPosition[1] - 1;
            tempState = (Piece[,])currentState.Clone();

            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, currentState))
            {
                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY }, tempState));
            }

            newX = currentPosition[0] + 2;
            newY = currentPosition[1] + 1;
            tempState = (Piece[,])currentState.Clone();

            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, currentState))
            {
                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY }, tempState));
            }

            newX = currentPosition[0] - 2;
            newY = currentPosition[1] - 1;
            tempState = (Piece[,])currentState.Clone();

            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, currentState))
            {
                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY }, tempState));
            }

            newX = currentPosition[0] - 2;
            newY = currentPosition[1] + 1;
            tempState = (Piece[,])currentState.Clone();

            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, currentState))
            {
                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY }, tempState));
            }

            return possibleMoves;
        }

        /// <summary>
        /// Validates whether a given move attempted by a knight is valid
        /// </summary>
        /// <param name="currentPosition">The current position of the knight</param>
        /// <param name="newPosition">the target position of the attempted move</param>
        /// <returns>whether the attempted move is valid</returns>
        public override bool MovePiece(int[] currentPosition, int[] newPosition)
        {
            if (TestValidMove(newPosition, currentPosition, PieceTeam, null))
            {
                if ((newPosition[1] == currentPosition[1] - 2 && newPosition[0] == currentPosition[0] - 1) ||
                    (newPosition[1] == currentPosition[1] - 2 && newPosition[0] == currentPosition[0] + 1) ||
                    (newPosition[1] == currentPosition[1] + 2 && newPosition[0] == currentPosition[0] - 1) ||
                    (newPosition[1] == currentPosition[1] + 2 && newPosition[0] == currentPosition[0] + 1) ||
                    (newPosition[0] == currentPosition[0] + 2 && newPosition[1] == currentPosition[1] - 1) ||
                    (newPosition[0] == currentPosition[0] + 2 && newPosition[1] == currentPosition[1] + 1) ||
                    (newPosition[0] == currentPosition[0] - 2 && newPosition[1] == currentPosition[1] - 1) ||
                    (newPosition[0] == currentPosition[0] - 2 && newPosition[1] == currentPosition[1] + 1))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}