//-----------------------------------------------------------------------
// <copyright file="Bishop.cs"  >
//     Copyright (c) 8INF700. All rights reserved.
//      Name: Hans Darmstadt-Bélanger
//      Goal: The controller for the bishops
//      Date: 18/04/2019
// </copyright>
//-----------------------------------------------------------------------

namespace AIProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Contains Bishop related logic
    /// </summary>
    /// <seealso cref="AIProject.Piece" />
    public class Bishop : Piece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bishop"/> class.
        /// </summary>
        /// <param name="bishopTeam">if set to <c>true</c> [bishop team].</param>
        public Bishop(bool bishopTeam) : base(bishopTeam, 3, 'B')
        {
        }

        /// <summary>
        /// Moves the piece.
        /// </summary>
        /// <param name="currentPosition">The current position.</param>
        /// <param name="newPosition">The new position.</param>
        /// <returns>The validity of the move being attempted</returns>
        public new bool MovePiece(int[] currentPosition, int[] newPosition)
        {
           return TestValidBishopMove(currentPosition, newPosition);
        }

        /// <summary>
        /// Gets all valid moves.
        /// </summary>
        /// <param name="currentState">State of the current.</param>
        /// <param name="currentPosition">The current position.</param>
        /// <returns>All valid moves for the bishop</returns>
        public override List<PotentialMove> GetAllValidMoves(Piece[,] currentState, int[] currentPosition)
        {
            return TestValidBishopMove(currentState, currentPosition);
        }
    }
}
