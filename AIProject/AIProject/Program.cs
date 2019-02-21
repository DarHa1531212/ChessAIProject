using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 5;

            int[] newPosition = new int[2];
            newPosition[0] = 3;
            newPosition[1] = 6;
            //Act
            Pawn myPawn = new Pawn(false);
            bool result = myPawn.MovePiece(currentPosition, newPosition);

        }
    }
}
