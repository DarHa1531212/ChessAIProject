//-----------------------------------------------------------------------
// <copyright file = "King.cs" >
//     Copyright(c) 8INF700.All rights reserved.
//    Name: Hans Darmstadt-Bélanger
//    Goal: Manage the King related logic
//    Date: 18/04/2019
// </copyright>
//-----------------------------------------------------------------------

namespace AIProject
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains the king related logic
    /// </summary>
    public class King : Piece
    {
        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="King" /> class.
        /// </summary>
        /// <param name="kingTeam">This king's team</param>
        public King(bool kingTeam) : base(kingTeam, 20, 'K')
        {
        }
        #endregion

        #region public methods
        /// <summary>
        /// Validates wherther a move made by a king is valid
        /// </summary>
        /// <param name="currentPosition">The king's current position</param>
        /// <param name="newPosition">The king's target position</param>
        /// <returns>Wherther the attempted move is valid</returns>
        public override bool MovePiece(int[] currentPosition, int[] newPosition)
        {
            // Moves a king can make
            if (currentPosition[0] - newPosition[0] == 1 || currentPosition[0] - newPosition[0] == -1 || currentPosition[1] - newPosition[1] == 1 || currentPosition[1] - newPosition[1] == -1)
            {
                if (this.TestValidMove(newPosition, currentPosition, this.PieceTeam, null))
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
        /// Gets all moves the king can make
        /// </summary>
        /// <param name="currentState">The game's current state</param>
        /// <param name="currentPosition">The king's current position</param>
        /// <returns>a list of the valid moves</returns>
        public override List<PotentialMove> GetAllValidMoves(Piece[,] currentState, int[] currentPosition)
        {
            List<PotentialMove> possibleMoves = new List<PotentialMove>();
            Piece[,] tempState = new Piece[8, 8];
            int newX, newY;

            newX = currentPosition[0] - 1;
            newY = currentPosition[1] - 1;
            tempState = (Piece[,])currentState.Clone();
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);

            newX = currentPosition[0];
            newY = currentPosition[1] - 1;
            tempState = (Piece[,])currentState.Clone();
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);

            newX = currentPosition[0] + 1;
            newY = currentPosition[1] - 1;
            tempState = (Piece[,])currentState.Clone();
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);

            newX = currentPosition[0] - 1;
            newY = currentPosition[1];
            tempState = (Piece[,])currentState.Clone();
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);

            newX = currentPosition[0] + 1;
            newY = currentPosition[1];
            tempState = (Piece[,])currentState.Clone();
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);

            newX = currentPosition[0] - 1;
            newY = currentPosition[1] + 1;
            tempState = (Piece[,])currentState.Clone();
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);

            newX = currentPosition[0];
            newY = currentPosition[1] + 1;
            tempState = (Piece[,])currentState.Clone();
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);

            newX = currentPosition[0] + 1;
            newY = currentPosition[1] + 1;
            tempState = (Piece[,])currentState.Clone();
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);

            return possibleMoves;
        }

        #endregion

        #region private methods
        /// <summary>
        /// Tests wherther an attempted move is valid
        /// </summary>
        /// <param name="currentState">the game's current state</param>
        /// <param name="currentPosition">The king's current position</param>
        /// <param name="possibleMoves">The possible moves list. If the attempted move is valid, it will be added to this list</param>
        /// <param name="nextState">Should the move be valid, this will be the new game's state</param>
        /// <param name="newX">The attempted move's X axis target coordonate</param>
        /// <param name="newY">The attempted move's Y axis target coordonate</param>
        private void TestValidMove(Piece[,] currentState, int[] currentPosition, ref List<PotentialMove> possibleMoves, Piece[,] nextState, int newX, int newY)
        {
            int currentX = currentPosition[0];
            int currentY = currentPosition[1];

            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, null))
            {
                nextState[newX, newY] = nextState[currentX, currentY];
                nextState[currentX, currentY] = null;
                possibleMoves.Add(new PotentialMove(currentPosition, new[] { newX, newY }, nextState));
            }
        }
        #endregion
    }
}
