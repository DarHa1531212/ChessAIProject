using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class SmartAgent
    {
        List<cPiece[,]> validMoves = new List<cPiece[,]>();
        public List<cPotentialMove> MiniMaxDecision(cPiece[,] currentState, int depth, bool currentPlayer, int[] previousPosition, int[] newPosition)
        {

            List<cPotentialMove> possibeActions;
            List<cPotentialMove> evalList;
           List< cPotentialMove> bestAction = new List<cPotentialMove>();
            List<int> possibleActionsEvaluation = new List<int>();

            if (depth == 0)
            {
                cPotentialMove move = new cPotentialMove(previousPosition, newPosition, currentState);
                List<cPotentialMove> returnList = new List<cPotentialMove>();
                returnList.Add(move);
                return returnList;

            }

            //white plays
            else if (currentPlayer)
            {
                int maxEval = -999;
                possibeActions = ListAllPossibleActions(currentState, currentPlayer);
                foreach (var v in possibeActions)
                {
                    evalList = MiniMaxDecision(v.CurrentState, depth - 1, !currentPlayer, v.PreviousPosition, v.NewPosition);
                    cPotentialMove eval = evalList[evalList.Count - 1];
                    //  possibleActionsEvaluation.Add
                    if (CountUtility(eval.CurrentState) > maxEval)
                    {
                        evalList.Add(new cPotentialMove(previousPosition, newPosition, currentState));
                        bestAction = evalList;
                        //bestAction = eval;
                        //bestAction.NewPosition = newPosition;
                        // bestAction.PreviousPosition = previousPosition;
                        maxEval = CountUtility(eval.CurrentState);

                    }
                }
                
                return bestAction;
            }

            else
            {
                int minEval = 999;
                possibeActions = ListAllPossibleActions(currentState, currentPlayer);


                foreach (var v in possibeActions)
                {

                    evalList = MiniMaxDecision(v.CurrentState, depth - 1, !currentPlayer, v.PreviousPosition, v.NewPosition);
                    cPotentialMove eval = evalList[evalList.Count - 1];
                    //  possibleActionsEvaluation.Add
                    if (CountUtility(eval.CurrentState) < minEval)
                    {
                        evalList.Add(new cPotentialMove(previousPosition, newPosition, currentState));
                        bestAction = evalList;
                        //bestAction = eval;
                        //bestAction.NewPosition = newPosition;
                        // bestAction.PreviousPosition = previousPosition;
                        minEval = CountUtility(eval.CurrentState);
                    }
                }
                return bestAction;
            }
        }

        private int CountUtility(cPiece[,] currentState)
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

        private List<cPotentialMove> ListAllPossibleActions(cPiece[,] currentState, bool currentPlayer)
        {
            List<cPotentialMove> possibeActions = new List<cPotentialMove>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (currentState[i, j] != null && currentState[i, j].PieceTeam == currentPlayer)
                    {
                        List<cPotentialMove> actionsList = currentState[i, j].GetAllValidMoves(currentState, new[] { i, j });
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
