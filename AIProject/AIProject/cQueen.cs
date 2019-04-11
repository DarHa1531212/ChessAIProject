using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class cQueen : cPiece

    {
        public cQueen(bool queenTeam) : base(queenTeam,9, 'Q')
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
            return ListAllRookMoves(currentPosition, newPosition);
        }

        public override List<cPiece[,]> GetAllValidMoves(cPiece[,] currentState, int[] currentPosition)
        {
            List<cPiece[,]> possibleMoves = new List<cPiece[,]>();

            possibleMoves.AddRange(GetAllValidBishopMoves(currentState, currentPosition));
            possibleMoves.AddRange(GetAllValidRookMoves(currentState, currentPosition));

            return possibleMoves;
        }


    }
}
