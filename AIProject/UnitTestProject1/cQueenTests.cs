using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AIProject;


namespace QueenTests
{
    [TestClass]
    public class cQueenTests
    {
        [TestMethod]
        public void TestQueenUpRightValidMove_AssertTrue()
        {

            //Arrange
            Piece[,] board = new Piece[8, 8];
            GameBoard myBoard = new GameBoard(board);

            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 5;
            newPosition[1] = 5;
            //Act
            Queen myQueen = new Queen(true);
            bool result = myQueen.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestQueenUpLeftValidMove_AssertTrue()
        {

            //Arrange
            Piece[,] board = new Piece[8, 8];
            GameBoard myBoard = new GameBoard(board);

            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 5;
            newPosition[1] = 1;
            //Act
            Queen myQueen = new Queen(true);
            bool result = myQueen.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestQueenDownLeftValidMove_AssertTrue()
        {

            //Arrange
            Piece[,] board = new Piece[8, 8];
            GameBoard myBoard = new GameBoard(board);

            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 1;
            newPosition[1] = 1;
            //Act
            Queen myQueen = new Queen(true);
            bool result = myQueen.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }



        [TestMethod]
        public void TestQueenDownRightValidMove_AssertTrue()
        {

            //Arrange
            Piece[,] board = new Piece[8, 8];
            GameBoard myBoard = new GameBoard(board);

            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 1;
            newPosition[1] = 5;
            //Act
            Queen myQueen = new Queen(true);
            bool result = myQueen.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestQueenEatsEnemyPiece_AssertTrue()
        {

            //Arrange
            Piece[,] board = new Piece[8, 8];
            board[1, 1] = new Pawn(false);
            GameBoard myBoard = new GameBoard(board);

            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 1;
            newPosition[1] = 1;
            //Act
            Queen myQueen = new Queen(true);
            bool result = myQueen.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void TestQueenGoingBehindEnemyPiece_AssertFalse()
        {

            //Arrange
            Piece[,] board = new Piece[8, 8];
            board[1, 1] = new Pawn(false);
            GameBoard myBoard = new GameBoard(board);

            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 0;
            newPosition[1] = 0;
            //Act
            Queen myQueen = new Queen(true);
            bool result = myQueen.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void TestQueenEatsFreindlyPiece_AssertFalse()
        {

            //Arrange
            Piece[,] board = new Piece[8, 8];
            board[1, 1] = new Pawn(true);
            GameBoard myBoard = new GameBoard(board);

            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 1;
            newPosition[1] = 1;
            //Act
            Queen myQueen = new Queen(true);
            bool result = myQueen.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void TestQueenGoesBeyondFriendlyPiece_AssertFalse()
        {

            //Arrange
            Piece[,] board = new Piece[8, 8];
            board[1, 1] = new Pawn(true);
            GameBoard myBoard = new GameBoard(board);

            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 0;
            newPosition[1] = 0;
            //Act
            Queen myQueen = new Queen(true);
            bool result = myQueen.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);

        }
        [TestMethod]
        public void TestQueenMove_AssertTrue()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 2;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 2;
            newPosition[1] = 2;

            //Act
            Queen myKnight = new Queen(true);
            bool result = myKnight.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestEatEnemyPiece_AssertTrue()
        {
            Piece[,] board = new Piece[8, 8];
            board[3, 4] = new Pawn(false);
            GameBoard myBoard = new GameBoard(board);

            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 1;

            int[] newPosition = new int[2];
            newPosition[0] = 3;
            newPosition[1] = 4;

            //Act
            Queen myKing = new Queen(true);
            bool result = myKing.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestMoveFurtherThanEnemyPiece_AssertFalse()
        {
            Piece[,] board = new Piece[8, 8];
            board[3, 4] = new Pawn(false);
            GameBoard myBoard = new GameBoard(board);

            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 1;

            int[] newPosition = new int[2];
            newPosition[0] = 3;
            newPosition[1] = 5;

            //Act
            Queen myKing = new Queen(true);
            bool result = myKing.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);

        }

    }
}

