//-----------------------------------------------------------------------
// <copyright file="Queen.cs"  >
//     Copyright (c) 8INF700. All rights reserved.
//      Name: Hans Darmstadt-Bélanger
//      Goal: Queen related logic
//      Date: 18/04/2019
// </copyright>
//-----------------------------------------------------------------------

namespace AIProject
{
    using System.Collections.Generic;

    /// <summary>
    /// Queen related logic
    /// </summary>
    public class Queen : Piece
    {
        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="Queen" /> class.
        /// </summary>
        /// <param name="queenTeam">The queen's team</param>
        public Queen(bool queenTeam) : base(queenTeam, 9, 'Q')
        {
        }
        #endregion

        #region public methods
        /// <summary>
        /// Teste whether a move is valid
        /// </summary>
        /// <param name="currentPosition">The queen's current position</param>
        /// <param name="newPosition">The target position</param>
        /// <returns>The validity of the move</returns>
        public override bool TestValidMove(int[] currentPosition, int[] newPosition)
        {
            return TestValidBishopMove(currentPosition, newPosition) || TestValidRookMove(currentPosition, newPosition);
        }

        /// <summary>
        /// Gets all valid queen moves
        /// </summary>
        /// <param name="currentState">The current game state</param>
        /// <param name="currentPosition">The current queen's position</param>
        /// <returns>The list of valid moves</returns>
        public override List<PotentialMove> GetAllValidMoves(Piece[,] currentState, int[] currentPosition)
        {
            List<PotentialMove> possibleMoves = new List<PotentialMove>();

            possibleMoves.AddRange(TestValidBishopMove(currentState, currentPosition));
            possibleMoves.AddRange(GetAllValidRookMoves(currentState, currentPosition));

            return possibleMoves;
        }
        #endregion
    }
}