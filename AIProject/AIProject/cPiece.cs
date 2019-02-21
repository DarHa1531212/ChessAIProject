using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class cPiece : IPiece
    {
        private int pieceValue;
        private bool pieceTeam;
        public cPiece(bool team, int value)
        {
            pieceTeam = team;
            pieceValue = value;
        }
        public bool PieceTeam
        {
            get { return this.pieceTeam; }
        }
        public int PieceValue
        {
            get { return this.pieceValue; }
        }

        public bool TestValidMove(int[] newPosition, int[] previousPosition, bool pieceTeam)
        {
            cPiece[,] tempBoard = new cPiece[8, 8];
            tempBoard = cGameBoard.board;
            int posX = newPosition[0];
            int posY = newPosition[1];
            bool fieldOccupiedByFreindly = false;
            
            // validates that there is no friendly piece at the target location
            if (tempBoard[posX, posY] != null)
            {
                Console.WriteLine("field is not null");
                if (tempBoard[posX, posY].pieceTeam == pieceTeam)
                {
                    Console.WriteLine("piece's team on this field: " + tempBoard[posX, posY].pieceTeam);
                    Console.WriteLine("this piece's team: " + pieceTeam);
                    fieldOccupiedByFreindly = true;

                }
            }

            return ValidatePieceOutOfBounds(newPosition, previousPosition) && !fieldOccupiedByFreindly;
        }

        private static bool ValidatePieceOutOfBounds(int[] newPosition, int[] previousPosition)
        {
            if (newPosition[0] <= 7 && newPosition[0] >= 0 && newPosition[1] <= 7 && newPosition[1] >= 0 && newPosition != previousPosition)
                return true;
            else return false;
        }

        public void MovePiece()
        {
            throw new NotImplementedException();
        }



    }
}
