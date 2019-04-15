using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class cPotentialMove
    {
        public int[] PreviousPosition { get; set; }
        public int[] NewPosition { get; set; }
        public cPiece[,] CurrentState { get; set; }

        public cPotentialMove(int[] previousPosition, int[] newPosition, cPiece[,] board)
        {
            PreviousPosition = previousPosition;
            NewPosition = newPosition;
            CurrentState = board;
        }
    }
}
