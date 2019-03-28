//-----------------------------------------------------------------------
// <copyright file="cPawn.cs" company = "8INF700" >
//     Copyright (c) 8INF700. All rights reserved.
//      Name: Hans Darmstadt-Bélanger
//      Goal: The controller for the pawns
//      Date: 12/02/2019
// </copyright>
//-----------------------------------------------------------------------
using System;
namespace AIProject
{
    public class Pawn : cPiece
    {
        public Pawn(bool pawnTeam) : base(pawnTeam, 1,'P')
        {
        }

        public override bool MovePiece(int[] currentPosition, int[] newPosition)
        {
            if (ValidatePawnMove(currentPosition, newPosition))
            {
                if (TestValidMove(newPosition, currentPosition, this.PieceTeam))
                    return true;
                else return false;
            }
            return false;

        }

        private bool ValidatePawnMove(int[] currentPosition, int[] nextPosition)
        {
            cPiece[,] tempBoard = new cPiece[8, 8];
            int posX = nextPosition[0];
            int posY = nextPosition[1];

            tempBoard = cGameBoard.board;


            //advanced in the right direction
            if ((PieceTeam == true && nextPosition[1] - currentPosition[1] == 1) || PieceTeam == false && currentPosition[1] - nextPosition[1] == 1)
            {
                //advanced straight
                /*sould this not be != */
                if (currentPosition[0] == nextPosition[0] && tempBoard[posX,posY] ==  null)
                {
                    return true;
                }
                //ate another piece
                else if (currentPosition[0] == nextPosition[0] + 1 || currentPosition[0] == nextPosition[0] - 1)
                {


                    if (tempBoard[posX, posY].PieceTeam != PieceTeam)
                    { return true; }
                    else { return false; }

                }
            }
            //white pawn can advance 2 fields if it is its first move
            else if (this.PieceTeam == true && currentPosition[1] == 1 && nextPosition[1] == 3 && currentPosition[0] == nextPosition[0] && tempBoard[currentPosition[0], 2] == null && tempBoard[currentPosition[0], 3] == null)
            {
                return true;
            }

            //black pawn can advance 2 fields if it is its first move
            else if (this.PieceTeam == false && currentPosition[1] == 6 && nextPosition[1] == 4 && currentPosition[0] == nextPosition[0] && tempBoard[currentPosition[0], 5] == null && tempBoard[currentPosition[0], 4] == null)
            {
                return true;
            }

            //did not advance straight or too much
            return false;

        }
    }
}
