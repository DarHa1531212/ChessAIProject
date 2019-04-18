using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class SmartAgent
    {
        //List<Piece[,]> validMoves = new List<Piece[,]>();
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

            //white plays
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
                        break;


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
                        break;
                }
                return bestAction;
            }
        }

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
    }
}
