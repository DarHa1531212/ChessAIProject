using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class cKnight : cPiece
    {
        public cKnight(bool knightTeam) : base(knightTeam, 3, 'T')
        {
        }

        private List<cPiece[,]> GetAllValidMoves(cPiece[,] currentState, int[] currentPosition)
        {
            List<cPiece[,]> possibleMoves = new List<cPiece[,]>();
            cPiece[,] tempState = new cPiece[8, 8];
            int newX, newY;

            newX = currentPosition[0] - 1;
            newY = currentPosition[1] - 2;
            tempState = (cPiece[,])currentState.Clone();
            TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, currentState);
            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, null))
            {
                tempState[newX, newY] = tempState[newX, newY];
                tempState[newX, newY] = null;
                possibleMoves.Add(tempState);
            }

            /* if (
            (newPosition[1] == currentPosition[1] - 2 && newPosition[0] == currentPosition[0] - 1) ||
            (newPosition[1] == currentPosition[1] - 2 && newPosition[0] == currentPosition[0] + 1) ||
            (newPosition[1] == currentPosition[1] + 2 && newPosition[0] == currentPosition[0] - 1) ||
            (newPosition[1] == currentPosition[1] + 2 && newPosition[0] == currentPosition[0] + 1) ||
            (newPosition[0] == currentPosition[0] + 2 && newPosition[1] == currentPosition[1] - 1) ||
            (newPosition[0] == currentPosition[0] + 2 && newPosition[1] == currentPosition[1] + 1) ||
            (newPosition[0] == currentPosition[0] - 2 && newPosition[1] == currentPosition[1] - 1) ||
            (newPosition[0] == currentPosition[0] - 2 && newPosition[1] == currentPosition[1] + 1))*/

            return possibleMoves;

        }

        public override bool MovePiece(int[] currentPosition, int[] newPosition)
        {
            if (TestValidMove(newPosition, currentPosition, PieceTeam, null))
            {
                if ((newPosition[1] == currentPosition[1] - 2 && newPosition[0] == currentPosition[0] - 1) ||
                    (newPosition[1] == currentPosition[1] - 2 && newPosition[0] == currentPosition[0] + 1) ||
                    (newPosition[1] == currentPosition[1] + 2 && newPosition[0] == currentPosition[0] - 1) ||
                    (newPosition[1] == currentPosition[1] + 2 && newPosition[0] == currentPosition[0] + 1) ||
                    (newPosition[0] == currentPosition[0] + 2 && newPosition[1] == currentPosition[1] - 1) ||
                    (newPosition[0] == currentPosition[0] + 2 && newPosition[1] == currentPosition[1] + 1) ||
                    (newPosition[0] == currentPosition[0] - 2 && newPosition[1] == currentPosition[1] - 1) ||
                    (newPosition[0] == currentPosition[0] - 2 && newPosition[1] == currentPosition[1] + 1))
                {
                    return true;
                }

            }
            return false;
        }
    }
}

