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
            return ListAllRookMoves(currentPosition, newPosition);
        }

        public override List<cPiece[,]> GetAllValidMoves(cPiece[,] currentState, int[] currentPosition)
        {
            return base.GetAllValidRookMoves(currentState, currentPosition);
        }

    }
}
