using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    interface IPiece
    {
        bool MovePiece(int[] currentPosition, int[] nextPosition);
        List<cPiece[,]> GetAllValidMoves(cPiece[,] currentState, int [] v1);

    }
}
