using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class cRook : cPiece
    {
        public cRook(bool roookTeam) : base(roookTeam, 5,'R')
        { }

        public override bool MovePiece(int[] currentPosition, int[] newPosition)
        {
            return GetAllRookMoves(currentPosition, newPosition);
        }

    }
}
