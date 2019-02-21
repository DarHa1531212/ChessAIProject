using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class cGameBoard
    {
        static public cPiece[,] board = new cPiece[8, 8];
        public cGameBoard()
        {
        }
        public cGameBoard(cPiece[,] customBoard)
        {
            board = customBoard;
        }

        public cPiece[,] GameBoard
        {
            get { return board; }
        }


    }
}
