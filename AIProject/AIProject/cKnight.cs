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

        public override bool MovePiece(int[] currentPosition, int[] newPosition)
        {
            if (TestValidMove(newPosition, currentPosition, PieceTeam))
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

