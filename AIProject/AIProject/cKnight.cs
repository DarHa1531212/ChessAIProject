using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class cKnight : cPiece
    {
        public cKnight(bool knightTeam) : base(knightTeam, 3, 'T')
        {
        }

        public override List<cPotentialMove> GetAllValidMoves(cPiece[,] currentState, int[] currentPosition)
        {
            List<cPotentialMove> possibleMoves = new List<cPotentialMove>();
            cPiece[,] tempState = new cPiece[8, 8];
            int newX, newY;

            newX = currentPosition[0] - 1;
            newY = currentPosition[1] - 2;
            tempState = (cPiece[,])currentState.Clone();

            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, currentState))
            {
                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY }, tempState));
            }


            newX = currentPosition[0] + 1;
            newY = currentPosition[1] - 2;
            tempState = (cPiece[,])currentState.Clone();

            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, currentState))
            {
                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY }, tempState));
            }

            newX = currentPosition[0] - 1;
            newY = currentPosition[1] + 2;
            tempState = (cPiece[,])currentState.Clone();

            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, currentState))
            {
                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY }, tempState));
            }

            newX = currentPosition[0] + 1;
            newY = currentPosition[1] + 2;
            tempState = (cPiece[,])currentState.Clone();

            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, currentState))
            {
                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY }, tempState));
            }


            newX = currentPosition[0] + 2;
            newY = currentPosition[1] - 1;
            tempState = (cPiece[,])currentState.Clone();

            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, currentState))
            {
                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY }, tempState));
            }


            newX = currentPosition[0] + 2;
            newY = currentPosition[1] + 1;
            tempState = (cPiece[,])currentState.Clone();

            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, currentState))
            {
                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY }, tempState));
            }



            newX = currentPosition[0] - 2;
            newY = currentPosition[1] - 1;
            tempState = (cPiece[,])currentState.Clone();

            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, currentState))
            {
                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY }, tempState));
            }


            newX = currentPosition[0] - 2;
            newY = currentPosition[1] + 1;
            tempState = (cPiece[,])currentState.Clone();

            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, currentState))
            {
                tempState[newX, newY] = tempState[currentPosition[0], currentPosition[1]];
                tempState[currentPosition[0], currentPosition[1]] = null;
                possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY }, tempState));
            }


            return possibleMoves;

        }

        public override bool MovePiece(int[] currentPosition, int[] newPosition)
        {
            if (TestValidMove(newPosition, currentPosition, PieceTeam, null))
            {
                if ((newPosition[1] == currentPosition[1] - 2 && newPosition[0] == currentPosition[0] - 1) ||
                    (newPosition[1] == currentPosition[1] - 2 && newPosition[0] == currentPosition[0] + 1) ||
                    (newPosition[1] == currentPosition[1] + 2 && newPosition[0] == currentPosition[0] - 1) ||
                    (newPosition[1] == currentPosition[1] + 2 && newPosition[0] == currentPosition[0] + 1) ||
                    (newPosition[0] == currentPosition[0] + 2 && newPosition[1] == currentPosition[1] - 1) ||
                    (newPosition[0] == currentPosition[0] + 2 && newPosition[1] == currentPosition[1] + 1) ||
                    (newPosition[0] == currentPosition[0] - 2 && newPosition[1] == currentPosition[1] - 1) ||
                    (newPosition[0] == currentPosition[0] - 2 && newPosition[1] == currentPosition[1] + 1))
                {
                    return true;
                }

            }
            return false;
        }
    }
}

