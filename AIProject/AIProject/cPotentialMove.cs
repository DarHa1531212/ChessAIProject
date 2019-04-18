using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class PotentialMove
    {
        public int[] PreviousPosition { get; set; }
        public int[] NewPosition { get; set; }
        public Piece[,] CurrentState { get; set; }

        public PotentialMove(int[] previousPosition, int[] newPosition, Piece[,] board)
        {
            PreviousPosition = previousPosition;
            NewPosition = newPosition;
            CurrentState = board;
        }
    }
}
