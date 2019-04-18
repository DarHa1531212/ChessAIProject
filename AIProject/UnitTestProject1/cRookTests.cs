using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AIProject;

namespace RookTests
{

    [TestClass]
    public class cRookTests
    {
        [TestMethod]
        public void TestRookMove_AssertTrue()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 2;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 2;
            newPosition[1] = 2;

            //Act
            cRook myKnight = new cRook(true);
            bool result = myKnight.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestEatEnemyPiece_AssertTrue()
        {
            Piece[,] board = new Piece[8, 8];
            board[3, 4] = new Pawn(false);
            CGameBoard myBoard = new CGameBoard(board);

            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 1;

            int[] newPosition = new int[2];
            newPosition[0] = 3;
            newPosition[1] = 4;

            //Act
            cRook myKing = new cRook(true);
            bool result = myKing.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestMoveFurtherThanEnemyPiece_AssertFalse ()
        {
            Piece[,] board = new Piece[8, 8];
            board[3, 4] = new Pawn(false);
            CGameBoard myBoard = new CGameBoard(board);

            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 3;
            currentPosition[1] = 1;

            int[] newPosition = new int[2];
            newPosition[0] = 3;
            newPosition[1] = 5;

            //Act
            cRook myKing = new cRook(true);
            bool result = myKing.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);

        }

    }
}
