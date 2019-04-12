using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
   public class cPotentialMove
    {
        public int[] PreviousPosition { get; }
        public int[] NewPosition { get; }
        public cPiece[,] CurrentState { get; }

       public cPotentialMove(int[] previousPosition, int[] newPosition, cPiece[,] board )
        {
            PreviousPosition = previousPosition;
            NewPosition = newPosition;
            CurrentState = board;
        }
    }
}
