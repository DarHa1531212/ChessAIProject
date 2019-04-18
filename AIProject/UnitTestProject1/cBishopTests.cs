using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AIProject;


namespace Bishoptests
{
    [TestClass]
    public class cBishopTests
    {
        [TestMethod]
        public void TestBishopUpRightValidMove_AssertTrue()
        {

            //Arrange
            Piece[,] board = new Piece[8, 8];
            CGameBoard myBoard = new CGameBoard(board);

            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 5;
            newPosition[1] = 5;
            //Act
            CBishop myBishop = new CBishop(true);
            bool result = myBishop.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestBishopUpLeftValidMove_AssertTrue()
        {

            //Arrange
            Piece[,] board = new Piece[8, 8];
            CGameBoard myBoard = new CGameBoard(board);

            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 5;
            newPosition[1] = 1;
            //Act
            CBishop myBishop = new CBishop(true);
            bool result = myBishop.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestBishopDownLeftValidMove_AssertTrue()
        {

            //Arrange
            Piece[,] tempBoard = new Piece[8, 8];
            CGameBoard myBoard = new CGameBoard(tempBoard);

            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 1;
            newPosition[1] = 1;
            //Act
            CBishop myBishop = new CBishop(true);
            bool result = myBishop.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }



        [TestMethod]
        public void TestBishopDownRightValidMove_AssertTrue()
        {

            //Arrange
            Piece[,] board = new Piece[8, 8];
            CGameBoard myBoard = new CGameBoard(board);

            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 1;
            newPosition[1] = 5;
            //Act
            CBishop myBishop = new CBishop(true);
            bool result = myBishop.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestBishopEatsEnemyPiece_AssertTrue()
        {

            //Arrange
            Piece[,] board = new Piece[8, 8];
            board[1, 1] = new Pawn(false);
            CGameBoard myBoard = new CGameBoard(board);

            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 1;
            newPosition[1] = 1;
            //Act
            CBishop myBishop = new CBishop(true);
            bool result = myBishop.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void TestBishopGoingBehindEnemyPiece_AssertFalse()
        {

            //Arrange
            Piece[,] board = new Piece[8, 8];
            board[1, 1] = new Pawn(false);
            CGameBoard myBoard = new CGameBoard(board);

            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 0;
            newPosition[1] = 0;
            //Act
            CBishop myBishop = new CBishop(true);
            bool result = myBishop.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void TestBishopEatsFreindlyPiece_AssertFalse()
        {

            //Arrange
            Piece[,] board = new Piece[8, 8];
            board[1, 1] = new Pawn(true);
            CGameBoard myBoard = new CGameBoard(board);

            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 1;
            newPosition[1] = 1;
            //Act
            CBishop myBishop = new CBishop(true);
            bool result = myBishop.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void TestBishopGoesBeyondFriendlyPiece_AssertFalse()
        {

            //Arrange
            Piece[,] board = new Piece[8, 8];
            board[1, 1] = new Pawn(true);
            CGameBoard myBoard = new CGameBoard(board);

            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 0;
            newPosition[1] = 0;
            //Act
            CBishop myBishop = new CBishop(true);
            bool result = myBishop.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);

        }
    }
}


