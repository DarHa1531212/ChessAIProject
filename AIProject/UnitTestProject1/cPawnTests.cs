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
            cPiece[,] board = new cPiece[8, 8];
            cGameBoard myBoard = new cGameBoard(board);

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

        [TestMethod]
        public void TestInvalidMoveAteDiagonnaly_AssertFalse()
        {
            cPiece[,] board = new cPiece[8, 8];
            board[2, 3] = new Pawn(false);
            board[3, 4] = new Pawn(true);
            cGameBoard myBoard = new cGameBoard(board);

            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 2;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 3;
            newPosition[1] = 4;

            //Act
            King myPawn = new King(true);
            bool result = myPawn.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);


        }

        [TestMethod]
        public void TestValidMoveWhitePawnTwoStepsFirstMove_AssertTrue()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 1;

            int[] newPosition = new int[2];
            newPosition[0] = 3;
            newPosition[1] = 3;
            //Act
            Pawn myPawn = new Pawn(true);
            bool result = myPawn.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestValidMoveBlackPawnTwoStepsFirstMove_AssertTrue()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 6;

            int[] newPosition = new int[2];
            newPosition[0] = 3;
            newPosition[1] = 4;

            cPiece[,] board = new cPiece[8, 8];
            cGameBoard myBoard = new cGameBoard(board);
            //Act
            Pawn myPawn = new Pawn(false);
            bool result = myPawn.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestInvalidMoveWhitePawnTwoStepsFirstMove_AssertFalse()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 2;
            currentPosition[1] = 1;

            int[] newPosition = new int[2];
            newPosition[0] = 2;
            newPosition[1] = 3;

            cPiece[,] board = new cPiece[8, 8];
            board[2, 1] = new Pawn(true);
            board[2, 2] = new Pawn(false);
            cGameBoard myBoard = new cGameBoard(board);

            //Act
            Pawn myPawn = new Pawn(true);
            bool result = myPawn.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void TestInvalidMoveBlackPawnTwoStepsFirstMove_AssertFalse()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 2;
            currentPosition[1] = 6;

            int[] newPosition = new int[2];
            newPosition[0] = 2;
            newPosition[1] = 4;

            cPiece[,] board = new cPiece[8, 8];
            board[2, 6] = new Pawn(true);
            board[2, 5] = new Pawn(false);
            cGameBoard myBoard = new cGameBoard(board);

            //Act
            Pawn myPawn = new Pawn(false);
            bool result = myPawn.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);

        }


        [TestMethod]
        public void TestValidMoveWhitePawnTwoStepsFirstMoveEatsEnemyPiece_AssertFalse()
        {
            //Arrange
            cPiece[,] board = new cPiece[8, 8];
            board[3, 1] = new Pawn(true);
            board[3, 2] = new Pawn(false);
            cGameBoard myBoard = new cGameBoard(board);


            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 1;

            int[] newPosition = new int[2];
            newPosition[0] = 3;
            newPosition[1] = 3;
            //Act
            Pawn myPawn = new Pawn(true);
            bool result = myPawn.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void TestInvalidMovePawnCantEatInFrontOfHim_AssertFalse()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 1;
            currentPosition[1] = 1;

            int[] newPosition = new int[2];
            newPosition[0] = 1;
            newPosition[1] = 2;

            cPiece[,] board = new cPiece[8, 8];
            board[1, 2] = new Pawn(false);
            cGameBoard myBoard = new cGameBoard(board);
            //Act
            Pawn myPawn = new Pawn(true);
            bool result = myPawn.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);

        }

    }
}
