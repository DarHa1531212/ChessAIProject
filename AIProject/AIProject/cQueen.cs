using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class Queen : Piece

    {
        public Queen(bool queenTeam) : base(queenTeam,9, 'Q')
        {

        }

        public override bool MovePiece(int[] currentPosition, int[] newPosition)
        {
            return BishopMoves(currentPosition, newPosition)||RookMoves(currentPosition, newPosition);
        }

        private bool BishopMoves(int[] currentPosition, int[] newPosition)
        {
            return base.ListAllBishopMoves(currentPosition, newPosition);
        }

        private bool RookMoves(int[] currentPosition, int[] newPosition)
        {
            return TestValidRookMove(currentPosition, newPosition);
        }

        public override List<PotentialMove> GetAllValidMoves(Piece[,] currentState, int[] currentPosition)
        {
            List<PotentialMove> possibleMoves = new List<PotentialMove>();

            possibleMoves.AddRange(TestValidBishopMove(currentState, currentPosition));
            possibleMoves.AddRange(GetAllValidRookMoves(currentState, currentPosition));

            return possibleMoves;
        }


    }
}
