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
        public Pawn(bool pawnTeam) : base(pawnTeam, 1)
        {
        }

        public bool MovePiece(int[] currentPosition, int[] newPosition)
        {
            if (ValidatePawnMove(currentPosition, newPosition))
            {
                if (TestValidMove(newPosition, currentPosition, this.PieceTeam))
                    return true;
                else return false;
            }
            return false;

        }

        private bool ValidatePawnMove(int[] currentPosition, int[] newPosition)
        {
            //advanced in the right direction
            if ((PieceTeam == true && newPosition[1] - currentPosition[1] == 1) || PieceTeam == false && currentPosition[1] - newPosition[1] == 1)
            {
                //advanced straight
                if (currentPosition[0] == newPosition[0])
                {
                    return true;
                }
                //ate another piece
                else if (currentPosition[0] == newPosition[0] + 1 || currentPosition[0] == newPosition[0] - 1)
                {
                    cPiece[,] tempBoard = new cPiece[8, 8];
                    int posX = newPosition[0];
                    int posY = newPosition[1];

                    tempBoard = cGameBoard.board;

                    if (tempBoard[posX, posY].PieceTeam != PieceTeam)
                    { return true; }
                    else { return false; }

                }
            }
            //did not advance straight or too much
            return false;
        }

    }
}
