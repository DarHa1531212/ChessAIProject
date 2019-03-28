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
                if (TestValidMove(newPosition, currentPosition, this.PieceTeam))
                    return true;
                else return false;
            }
            return false;
        }

        public override List<cPiece[,]> GetAllValidMoves(cPiece[,] currentState, int[] currentPosition)
        {
            List<cPiece[,]> possibleMoves = new List<cPiece[,]>();
            cPiece[,] tempState = new cPiece[8, 8];
            int newX, newY;

            newX = currentPosition[0] - 1;
            newY = currentPosition[1] - 1;
            tempState = currentState;
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);

            newX = currentPosition[0];
            newY = currentPosition[1] - 1;
            tempState = currentState;
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);


            newX = currentPosition[0] + 1;
            newY = currentPosition[1] - 1;
            tempState = currentState;
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);


            newX = currentPosition[0] - 1;
            newY = currentPosition[1];
            tempState = currentState;
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);


            newX = currentPosition[0] + 1;
            newY = currentPosition[1];
            tempState = currentState;
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);

            newX = currentPosition[0] - 1;
            newY = currentPosition[1] + 1;
            tempState = currentState;
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);

            newX = currentPosition[0];
            newY = currentPosition[1] + 1;
            tempState = currentState;
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);

            newX = currentPosition[0] + 1;
            newY = currentPosition[1] + 1;
            tempState = currentState;
            TestValidMove(currentState, currentPosition, ref possibleMoves, tempState, newX, newY);



            return possibleMoves;

        }

        private void TestValidMove(cPiece[,] currentState, int[] currentPosition, ref List<cPiece[,]> possibleMoves, cPiece[,] tempState, int newX, int newY)
        {
            int currentX = currentPosition[0];
            int currentY = currentPosition[1];
            //TODO: null reference exception raised here...
            //problem caused by the presence of a pointer when current state should be duplicated instead, just need to find where...
            if (TestValidMove(new[] { newX, newY }, currentPosition, currentState[currentPosition[0], currentPosition[1]].PieceTeam))
            {
                tempState[newX, newY] = tempState[currentX, currentY];
                tempState[currentX, currentY] = null;
                possibleMoves.Add(tempState);
            }
        }
    }
}
