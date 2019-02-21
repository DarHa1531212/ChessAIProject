using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AIProject;

namespace PawnTests
{
    [TestClass]
    public class cPawnTests
    {
        [TestMethod]
        public void TestValidMoveWhitePawn_AssertTrue()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 1;

            int[] newPosition = new int[2];
            newPosition[0] = 3;
            newPosition[1] = 2;
            //Act
            Pawn myPawn = new Pawn(true);
            bool result = myPawn.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestValidMoveBlackPawn_AssertTrue()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 5;

            int[] newPosition = new int[2];
            newPosition[0] = 3;
            newPosition[1] = 4;
            //Act
            Pawn myPawn = new Pawn(false);
            bool result = myPawn.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }


        [TestMethod]
        public void TestInvalidMoveBlackPawn_AssertFalse()
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

            //Assert
            Assert.IsFalse(result);

        }

        //this test not finished
        [TestMethod]
        public void TestInvalidMoveAteDiagonnaly_AssertFalse()
        {
            cPiece[,] board = new cPiece[8, 8];
            board[2, 3] = new Pawn(true);
            board[3, 4] = new Pawn(false);
            cGameBoard myBoard = new cGameBoard(board);

            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 0;
            currentPosition[1] = 0;

            int[] newPosition = new int[2];
            newPosition[0] = 1;
            newPosition[1] = 0;

            //Act
            cKing myKing = new cKing(true);
            bool result = myKing.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);


        }

    }
}
