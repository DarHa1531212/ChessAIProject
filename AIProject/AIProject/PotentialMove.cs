//-----------------------------------------------------------------------
// <copyright file = "PotentialMove.cs" >
//     Copyright(c) 8INF700.All rights reserved.
//    Name: Hans Darmstadt-Bélanger
//    Goal: To manage the piece's core logic
//    Date: 18/04/2019
// </copyright>
//-----------------------------------------------------------------------

namespace AIProject
{
    /// <summary>
    /// A potential move is a possible move the AI has to evaluate
    /// </summary>
    public class PotentialMove
    {
        /// <summary>
        /// the previous position of the piece moved to get to the current state of the game
        /// </summary>
        public int[] PreviousPosition { get; set; }

        /// <summary>
        /// the new position of the piece moved to get to the current state of the game
        /// </summary>
        public int[] NewPosition { get; set; }

        /// <summary>
        /// The current state of the gameboard
        /// </summary>
        public Piece[,] CurrentState { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PotentialMove" /> class.
        /// </summary>
        /// <param name="previousPosition">the previous position of the piece moved to get to the current state of the game</param>
        /// <param name="newPosition">the new position of the piece moved to get to the current state of the game</param>
        /// <param name="board">The current state of the gameboard</param>
        public PotentialMove(int[] previousPosition, int[] newPosition, Piece[,] board)
        {
            PreviousPosition = previousPosition;
            NewPosition = newPosition;
            CurrentState = board;
        }
    }
}
