//-----------------------------------------------------------------------
// <copyright file="Rook.cs" company = "8INF700" >
//     Copyright (c) 8INF700. All rights reserved.
//      Name: Hans Darmstadt-Bélanger
//      Goal: The controller for the rooks
//      Date: 12/02/2019
// </copyright>
//-----------------------------------------------------------------------

namespace AIProject
{
    using System.Collections.Generic;

    /// <summary>
    /// Rook related logic
    /// </summary>
    public class Rook : Piece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rook" /> class.
        /// </summary>
        /// <param name="roookTeam">The rook's team</param>
        public Rook(bool roookTeam) : base(roookTeam, 5,'R')
        {
        }

        /// <summary>
        /// Tests whether a given move is valid
        /// </summary>
        /// <param name="currentPosition">The rook's current position</param>
        /// <param name="newPosition">The rook's target position</param>
        /// <returns>The validity of the move</returns>
        public override bool TestValidMove(int[] currentPosition, int[] newPosition)
        {
            return TestValidRookMove(currentPosition, newPosition);
        }

        /// <summary>
        /// Lists all valid moves
        /// </summary>
        /// <param name="currentState">The gameboard's current state</param>
        /// <param name="currentPosition">The rook curren's position</param>
        /// <returns>all valid moves</returns>
        public override List<PotentialMove> GetAllValidMoves(Piece[,] currentState, int[] currentPosition)
        {
            return GetAllValidRookMoves(currentState, currentPosition);
        }
    }
}
