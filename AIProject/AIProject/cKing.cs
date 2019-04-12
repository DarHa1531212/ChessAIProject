using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class cKing : cPiece
    {
        public cKing(bool kingTeam) : base(kingTeam, 20, 'K')
        {
        }
        public override bool MovePiece(int[] currentPosition, int[] newPosition)
        {
            //moves a king can make
            if (currentPosition[0] - newPosition[0] == 1 || currentPosition[0] - newPosition[0] == -1 || currentPosition[1] - newPosition[1] == 1 || currentPosition[1] - newPosition[1] == -1)
            {
                if (TestValidMove(newPosition, currentPosition, this.PieceTeam, null))
                    return true;
                else return false;
            }
            return false;
        }

        public override List<cPotentialMove> GetAllValidMoves(cPiece[,] currentState, int[] currentPosition)
        {
            List<cPotentialMove> possibleMoves = new List<cPotentialMove>();
            cPiece[,] tempState = new cPiece[8, 8];
            int newX, newY;

            newX = currentPosition[0] - 1;
            newY = currentPosition[1] - 1;
            tempState = (cPiece[,])currentState.Clone();
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);

            newX = currentPosition[0];
            newY = currentPosition[1] - 1;
            tempState = (cPiece[,])currentState.Clone();
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);


            newX = currentPosition[0] + 1;
            newY = currentPosition[1] - 1;
            tempState = (cPiece[,])currentState.Clone();
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);


            newX = currentPosition[0] - 1;
            newY = currentPosition[1];
            tempState = (cPiece[,])currentState.Clone();
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);


            newX = currentPosition[0] + 1;
            newY = currentPosition[1];
            tempState = (cPiece[,])currentState.Clone();
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);

            newX = currentPosition[0] - 1;
            newY = currentPosition[1] + 1;
            tempState = (cPiece[,])currentState.Clone();
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);

            newX = currentPosition[0];
            newY = currentPosition[1] + 1;
            tempState = (cPiece[,])currentState.Clone();
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);

            newX = currentPosition[0] + 1;
            newY = currentPosition[1] + 1;
            tempState = (cPiece[,])currentState.Clone();
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);



            return possibleMoves;

        }

        private void TestValidMove(cPiece[,] currentState, int[] currentPosition, ref List<cPotentialMove> possibleMoves, cPiece[,] tempState, int newX, int newY)
        {
            int currentX = currentPosition[0];
            int currentY = currentPosition[1];

            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam, null))
            {
                tempState[newX, newY] = tempState[currentX, currentY];
                tempState[currentX, currentY] = null;
                possibleMoves.Add(new cPotentialMove(currentPosition, new[] { newX, newY }, tempState));
            }
        }
    }
}
