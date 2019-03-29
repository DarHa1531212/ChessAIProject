using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class cBishop : cPiece
    {
        public cBishop(bool bishopTeam) : base(bishopTeam, 3, 'B')
        { }

        public new bool MovePiece(int[] currentPosition, int[] newPosition)
        {
           return base.ListAllBishopMoves(currentPosition, newPosition);
        }
    }
}
