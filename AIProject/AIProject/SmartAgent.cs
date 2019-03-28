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
        public void MiniMaxDecision(cPiece[,] currentState, int depth, bool currentPlayer)
        {
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

        private List<cPiece[,]> ListAllPossibleActions(cPiece[,] currentState, bool currentPlayer)
        {
            List<cPiece[,]> possibeActions = new List<cPiece[,]>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (currentState[i, j] != null && currentState[i, j].PieceTeam == currentPlayer)
                    {
                        List<cPiece[,]> actionsList = currentState[i, j].GetAllValidMoves(currentState, new[] { i, j });
                        foreach (var v in actionsList)
                        {
                            possibeActions.Add(v);
                        }
                    }
                }
            }


            return null;
        }
    }
}
