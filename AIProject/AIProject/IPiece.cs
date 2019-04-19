//-----------------------------------------------------------------------
// <copyright file = "IPiece.cs" >
//     Copyright(c) 8INF700.All rights reserved.
//    Name: Hans Darmstadt-Bélanger
//    Goal: The Piece's interface
//    Date: 18/04/2019
// </copyright>
//-----------------------------------------------------------------------

namespace AIProject
{
    using System.Collections.Generic;

    /// <summary>
    /// The piece's mandatory methods
    /// </summary>
    public interface IPiece
    {
        /// <summary>
        /// The method to validate a piece's move
        /// </summary>
        /// <param name="currentPosition">The piece's current position</param>
        /// <param name="nextPosition">The piece's target position</param>
        /// <returns>The validity of the move</returns>
        bool TestValidMove(int[] currentPosition, int[] nextPosition);

        /// <summary>
        /// gets all valid moves a piece can move
        /// </summary>
        /// <param name="currentState">The gameboard's current state</param>
        /// <param name="v1">The target piece's current position</param>
        /// <returns>The list of valid moves</returns>
        List<PotentialMove > GetAllValidMoves(Piece [,] currentState, int [] v1);
    }
}
