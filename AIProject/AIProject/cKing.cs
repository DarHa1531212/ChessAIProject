using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
 public class cKing : cPiece
    {
        public cKing(bool kingTeam) : base( kingTeam,  20)
        {          
        }
        public bool MovePiece(int[] currentPosition, int[] newPosition)
        {
            //moves a king can make
            if (currentPosition[0] - newPosition[0] == 1 || currentPosition[0] - newPosition[0] == -1 || currentPosition[1] - newPosition[1] == 1 || currentPosition[1] - newPosition[1] == -1)
            {
                if (TestValidMove(newPosition, currentPosition, this.PieceTeam))
                    return true;
                else return false;
            }
            return false;
        }
    }
}
