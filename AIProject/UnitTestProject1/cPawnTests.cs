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
            bool result = myPawn.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestValidMoveBlackPawn_AssertTrue()
        {
            //Arrange
            Piece[,] board = new Piece[8, 8];
            GameBoard myBoard = new GameBoard(board);

            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 5;

            int[] newPosition = new int[2];
            newPosition[0] = 3;
            newPosition[1] = 4;
            //Act
            Pawn myPawn = new Pawn(false);
            bool result = myPawn.TestValidMove(currentPosition, newPosition);

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
            bool result = myPawn.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void TestInvalidMoveAteDiagonnaly_AssertFalse()
        {
            Piece[,] board = new Piece[8, 8];
            board[2, 3] = new Pawn(false);
            board[3, 4] = new Pawn(true);
            GameBoard myBoard = new GameBoard(board);

            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 2;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 3;
            newPosition[1] = 4;

            //Act
            King myPawn = new King(true);
            bool result = myPawn.TestValidMove(currentPosition, newPosition);

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
            bool result = myPawn.TestValidMove(currentPosition, newPosition);

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

            Piece[,] board = new Piece[8, 8];
            GameBoard myBoard = new GameBoard(board);
            //Act
            Pawn myPawn = new Pawn(false);
            bool result = myPawn.TestValidMove(currentPosition, newPosition);

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

            Piece[,] board = new Piece[8, 8];
            board[2, 1] = new Pawn(true);
            board[2, 2] = new Pawn(false);
            GameBoard myBoard = new GameBoard(board);

            //Act
            Pawn myPawn = new Pawn(true);
            bool result = myPawn.TestValidMove(currentPosition, newPosition);

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

            Piece[,] board = new Piece[8, 8];
            board[2, 6] = new Pawn(true);
            board[2, 5] = new Pawn(false);
            GameBoard myBoard = new GameBoard(board);

            //Act
            Pawn myPawn = new Pawn(false);
            bool result = myPawn.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);

        }


        [TestMethod]
        public void TestValidMoveWhitePawnTwoStepsFirstMoveEatsEnemyPiece_AssertFalse()
        {
            //Arrange
            Piece[,] board = new Piece[8, 8];
            board[3, 1] = new Pawn(true);
            board[3, 2] = new Pawn(false);
            GameBoard myBoard = new GameBoard(board);


            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 1;

            int[] newPosition = new int[2];
            newPosition[0] = 3;
            newPosition[1] = 3;
            //Act
            Pawn myPawn = new Pawn(true);
            bool result = myPawn.TestValidMove(currentPosition, newPosition);

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

            Piece[,] board = new Piece[8, 8];
            board[1, 2] = new Pawn(false);
            GameBoard myBoard = new GameBoard(board);
            //Act
            Pawn myPawn = new Pawn(true);
            bool result = myPawn.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);

        }

    }
}
