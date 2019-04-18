using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class cRook : Piece
    {
        public cRook(bool roookTeam) : base(roookTeam, 5,'R')
        { }

        public override bool MovePiece(int[] currentPosition, int[] newPosition)
        {
            return TestValidRookMove(currentPosition, newPosition);
        }

        public override List<PotentialMove> GetAllValidMoves(Piece[,] currentState, int[] currentPosition)
        {
            return base.GetAllValidRookMoves(currentState, currentPosition);
        }

    }
}
