﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class cBishop : cPiece
    {
        public cBishop(bool bishopTeam) : base(bishopTeam, 3, 'B')
        { }

        public new bool MovePiece(int[] currentPosition, int[] newPosition)
        {
            List<int[]> validMoves = new List<int[]>();
            cPiece[,] tempBoard = new cPiece[8, 8];
            tempBoard = cGameBoard.board;
            int[] tempVal = new int[2];
            int posX, posY;


            int[] testingPosition = new int[2];
            testingPosition[0] = currentPosition[0] + 1;
            testingPosition[1] = currentPosition[1] + 1;

            while (TestValidMove(testingPosition, currentPosition, PieceTeam))
            {

                tempVal[0] = testingPosition[0];
                tempVal[1] = testingPosition[1];
                validMoves.Add(new[] { tempVal[0], tempVal[1] });
                testingPosition[0]++;
                testingPosition[1]++;
                posX = tempVal[0];
                posY = tempVal[1];
                if (tempBoard[posX, posY] != null)
                {
                    break;
                }
            }

            testingPosition[0] = currentPosition[0] + 1;
            testingPosition[1] = currentPosition[1] - 1;
            while (TestValidMove(testingPosition, currentPosition, PieceTeam))
            {
                tempVal[0] = testingPosition[0];
                tempVal[1] = testingPosition[1];
                validMoves.Add(new[] { tempVal[0], tempVal[1] });
                testingPosition[0]++;
                testingPosition[1]--;
                posX = tempVal[0];
                posY = tempVal[1];
                if (tempBoard[posX, posY] != null)
                {
                    break;
                }

            }

            testingPosition[0] = currentPosition[0] - 1;
            testingPosition[1] = currentPosition[1] + 1;
            while (TestValidMove(testingPosition, currentPosition, PieceTeam))
            {
                tempVal[0] = testingPosition[0];
                tempVal[1] = testingPosition[1];
                validMoves.Add(new[] { tempVal[0], tempVal[1] });
                testingPosition[0]--;
                testingPosition[1]++;
                posX = tempVal[0];
                posY = tempVal[1];
                if (tempBoard[posX, posY] != null)
                {
                    break;
                }

            }

            testingPosition[1] = currentPosition[1] - 1;
            testingPosition[0] = currentPosition[0] - 1;
            while (TestValidMove(testingPosition, currentPosition, PieceTeam))
            {
                tempVal[1] = testingPosition[1];
                tempVal[0] = testingPosition[0];
                validMoves.Add(new[] { tempVal[0], tempVal[1] });
                testingPosition[0]--;
                testingPosition[1]--;
                posX = tempVal[0];
                posY = tempVal[1];
                if (tempBoard[posX, posY] != null)
                {
                    break;
                }

            }

            foreach (var x in validMoves)
            {
                if (x[0] == newPosition[0] && x[1] == newPosition[1])
                {
                    return true;
                }
            }

            return false;

        }
    }
}
