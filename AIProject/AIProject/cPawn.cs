//-----------------------------------------------------------------------
// <copyright file="cPawn.cs" company = "8INF700" >
//     Copyright (c) 8INF700. All rights reserved.
//      Name: Hans Darmstadt-Bélanger
//      Goal: The controller for the pawns
//      Date: 12/02/2019
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace AIProject
{
    public class Pawn : cPiece
    {
        public Pawn(bool pawnTeam) : base(pawnTeam, 1, 'P')
        {
        }

        public override bool MovePiece(int[] currentPosition, int[] newPosition)
        {
            if (ValidatePawnMove(currentPosition, newPosition, null))
            {
                if (TestValidMove(newPosition, currentPosition, this.PieceTeam, null))
                    return true;
                else return false;
            }
            return false;

        }

        private bool ValidatePawnMove(int[] currentPosition, int[] nextPosition, cPiece[,] tempBoard)
        {
            if (tempBoard == null)
                tempBoard = cGameBoard.board;

            int posX = nextPosition[0];
            int posY = nextPosition[1];

            if (posX < 0 || posX > 7 || posY < 0 || posY > 7)
            {
                return false;
            }


            //advanced in the right direction
            if ((PieceTeam == true && nextPosition[1] - currentPosition[1] == 1) || PieceTeam == false && currentPosition[1] - nextPosition[1] == 1)
            {
                //advanced straight
                /*sould this not be != */
                if (currentPosition[0] == nextPosition[0] && tempBoard[posX, posY] == null)
                {
                    return true;
                }
                //ate another piece
                else if (currentPosition[0] == nextPosition[0] + 1 || currentPosition[0] == nextPosition[0] - 1)
                {


                    if (tempBoard[posX, posY] != null && tempBoard[posX, posY].PieceTeam != PieceTeam)
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

        public override List<cPotentialMove> GetAllValidMoves(cPiece[,] currentState, int[] currentPosition)
        {
            List<cPotentialMove> possibleMoves = new List<cPotentialMove>();
            cPiece[,] tempState = new cPiece[8, 8];
            int newX, newY;

            if (PieceTeam == true)
            {
                newX = currentPosition[0];
                newY = currentPosition[1];
                newY++;
                if (ValidatePawnMove(currentPosition, new[] { newX, newY }, currentState))
                {
                    tempState = (cPiece[,])currentState.Clone();
                    tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                    tempState[currentPosition[0], currentPosition[1]] = null;
                    possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY }, tempState));
                }

                if (ValidatePawnMove(currentPosition, new[] { newX + 1, newY }, currentState))
                {
                    tempState = (cPiece[,])currentState.Clone();
                    tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                    tempState[currentPosition[0], currentPosition[1]] = null;
                    possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX + 1, newY }, tempState));
                }

                if (ValidatePawnMove(currentPosition, new[] { newX - 1, newY }, currentState))
                {
                    tempState = (cPiece[,])currentState.Clone();
                    tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                    tempState[currentPosition[0], currentPosition[1]] = null;
                    possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX - 1, newY }, tempState));
                }

                if (ValidatePawnMove(currentPosition, new[] { newX, newY + 1 }, currentState))
                {
                    tempState = (cPiece[,])currentState.Clone();
                    tempState[newX, newY + 1] = tempState[currentPosition[0], currentPosition[1]];
                    tempState[currentPosition[0], currentPosition[1]] = null;
                    possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY + 1 }, tempState));
                }
            }

            else if (PieceTeam == false)
            {
                newX = currentPosition[0];
                newY = currentPosition[1];
                newY--;
                if (ValidatePawnMove(currentPosition, new[] { newX, newY }, currentState))
                {
                    tempState = (cPiece[,])currentState.Clone();
                    tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                    tempState[currentPosition[0], currentPosition[1]] = null;
                    possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY }, tempState));
                }

                if (ValidatePawnMove(currentPosition, new[] { newX + 1, newY }, currentState))
                {
                    tempState = (cPiece[,])currentState.Clone();
                    tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                    tempState[currentPosition[0], currentPosition[1]] = null;
                    possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX + 1, newY }, tempState));
                }

                if (ValidatePawnMove(currentPosition, new[] { newX - 1, newY }, currentState))
                {
                    tempState = (cPiece[,])currentState.Clone();
                    tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                    tempState[currentPosition[0], currentPosition[1]] = null;
                    possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX - 1, newY }, tempState));
                }

                if (ValidatePawnMove(currentPosition, new[] { newX, newY - 1 }, currentState))
                {
                    tempState = (cPiece[,])currentState.Clone();
                    tempState[newX, newY + 1] = tempState[currentPosition[0], currentPosition[1]];
                    tempState[currentPosition[0], currentPosition[1]] = null;
                    possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY - 1 }, tempState));
                }
            }

            return possibleMoves;

        }
        private void TestValidMove(cPiece[,] currentState, int[] currentPosition, ref List<cPiece[,]> possibleMoves, cPiece[,] tempState, int newX, int newY)
        {
            int currentX = currentPosition[0];
            int currentY = currentPosition[1];

            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, null))
            {
                tempState[newX, newY] = tempState[currentX, currentY];
                tempState[currentX, currentY] = null;
                possibleMoves.Add(tempState);
            }
        }

    }
}
