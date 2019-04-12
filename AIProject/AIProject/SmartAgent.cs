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
        public cPotentialMove MiniMaxDecision(cPiece[,] currentState, int depth, bool currentPlayer)
        {

            List<cPotentialMove> possibeActions;
            cPotentialMove bestAction = new cPotentialMove(null,null,null);
            List<int> possibleActionsEvaluation = new List<int>();
            if (depth == 0)
                return new cPotentialMove(null, null, currentState);

            //white plays
            else if (currentPlayer)
            {
                int maxEval = -999;
                possibeActions = ListAllPossibleActions(currentState, currentPlayer);
                foreach (var v in possibeActions)
                {
                    cPotentialMove eval = MiniMaxDecision(v.CurrentState, depth - 1, !currentPlayer);
                    //  possibleActionsEvaluation.Add
                    if (CountUtility(eval.CurrentState) > maxEval)
                    {
                        bestAction = eval;
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
                    cPotentialMove eval = MiniMaxDecision(v.CurrentState, depth - 1, !currentPlayer);
                    //  possibleActionsEvaluation.Add
                    if (CountUtility(eval.CurrentState) < minEval)
                    {
                        minEval = CountUtility(v.CurrentState);
                        bestAction = eval;
                    }
                }
                return bestAction;
            }
            
            //return max actions valeursMin(resultata(etat,a))
        }
        private int ValueMax()
        {
            int v;
            //si test terminal (profondeur 2)
            return v = -99;
            //sinon
            //return best action from list

        }

        private void ValueMin()
        {
            //if profondeur 2, retourner -99
            //else return best action from list
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
