//-----------------------------------------------------------------------
// <copyright file="SmartAgent.cs" company = "8INF700" >
//     Copyright (c) 8INF700. All rights reserved.
//      Name: Hans Darmstadt-Bélanger
//      Goal: Contains the logic for the smart agent
//      Date: 12/02/2019
// </copyright>
//-----------------------------------------------------------------------

namespace AIProject
{
    using System.Collections.Generic;

    /// <summary>
    /// The smart agent's logic
    /// </summary>
    public class SmartAgent
    {
        #region public methods

        /// <summary>
        /// The recursive function to pick a move using the minimax algorithm
        /// </summary>
        /// <param name="currentState">The current gameboard's state</param>
        /// <param name="depth">the depth of the recursive calls</param>
        /// <param name="currentPlayer">The player currently playing</param>
        /// <param name="previousPosition">The previous position of the piece that moved in the last round</param>
        /// <param name="newPosition">The new position of the piece that moved in the last round</param>
        /// <param name="bestAlpha">The best move alpha could make. Used for pruning</param>
        /// <param name="bestBeta">The best move beta could make. Used for pruning</param>
        /// <returns>the list of optimal moves</returns>
        public List<PotentialMove> MiniMaxDecision(Piece[,] currentState, int depth, bool currentPlayer, int[] previousPosition, int[] newPosition, int bestAlpha, int bestBeta)
        {
            List<PotentialMove> possibleActions, evalList;
            List<PotentialMove> bestAction = new List<PotentialMove>();
            List<int> possibleActionsEvaluation = new List<int>();

            if (depth == 0)
            {
                PotentialMove move = new PotentialMove(previousPosition, newPosition, currentState);
                List<PotentialMove> returnList = new List<PotentialMove>();
                returnList.Add(move);
                return returnList;
            }
            else if (currentPlayer)
            {
                int maxEval = -999;
                possibleActions = ListAllPossibleActions(currentState, currentPlayer);
                foreach (var v in possibleActions)
                {
                    evalList = MiniMaxDecision(v.CurrentState, depth - 1, !currentPlayer, v.PreviousPosition, v.NewPosition, bestAlpha, bestBeta);
                    PotentialMove eval = evalList[evalList.Count - 1];

                    if (CountUtility(eval.CurrentState) > maxEval)
                    {
                        evalList.Add(new PotentialMove(previousPosition, newPosition, currentState));
                        bestAction = evalList;
                        maxEval = CountUtility(eval.CurrentState);
                    }

                    if (bestAlpha < CountUtility(eval.CurrentState))
                    {
                        bestAlpha = CountUtility(eval.CurrentState);
                    }

                    if (bestBeta <= bestAlpha)
                    {
                        break;
                    }
                }

                return bestAction;
            }
            else
            {
                int minEval = 999;
                possibleActions = ListAllPossibleActions(currentState, currentPlayer);

                foreach (var v in possibleActions)
                {
                    evalList = MiniMaxDecision(v.CurrentState, depth - 1, !currentPlayer, v.PreviousPosition, v.NewPosition, bestAlpha, bestBeta);
                    PotentialMove eval = evalList[evalList.Count - 1];
                    if (CountUtility(eval.CurrentState) < minEval)
                    {
                        evalList.Add(new PotentialMove(previousPosition, newPosition, currentState));
                        bestAction = evalList;
                        minEval = CountUtility(eval.CurrentState);
                    }

                    if (bestBeta > CountUtility(eval.CurrentState))
                    {
                        bestBeta = CountUtility(eval.CurrentState);
                    }

                    if (bestBeta <= bestAlpha)
                    {
                        break;
                    }
                }

                return bestAction;
            }
        }

        #endregion

        #region private methods

        /// <summary>
        /// Counts the utiliti/value of a given state
        /// </summary>
        /// <param name="currentState">The current state</param>
        /// <returns>The utility</returns>
        private int CountUtility(Piece[,] currentState)
        {
            int sum = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (currentState[i, j] != null)
                    {
                        if (currentState[i, j].PieceTeam)
                        {
                            sum += currentState[i, j].PieceValue;
                        }
                        else
                        {
                            sum -= currentState[i, j].PieceValue;
                        }
                    }
                }
            }

            return sum;
        }

        /// <summary>
        /// Gets all possible actions for all pieces of the current player
        /// </summary>
        /// <param name="currentState">The current gameboard's state</param>
        /// <param name="currentPlayer">The player currently playing</param>
        /// <returns>all the possible actions the player can make</returns>
        private List<PotentialMove> ListAllPossibleActions(Piece[,] currentState, bool currentPlayer)
        {
            List<PotentialMove> possibeActions = new List<PotentialMove>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (currentState[i, j] != null && currentState[i, j].PieceTeam == currentPlayer)
                    {
                        List<PotentialMove> actionsList = currentState[i, j].GetAllValidMoves(currentState, new[] { i, j });
                        foreach (var v in actionsList)
                        {
                            possibeActions.Add(v);
                        }
                    }
                }
            }

            return possibeActions;
        }
        #endregion
    }
}
