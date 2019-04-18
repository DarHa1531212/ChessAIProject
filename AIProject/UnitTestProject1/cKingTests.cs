using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using AIProject;
using static AIProject.King;


namespace KingTests
{
    [TestClass]
    public class cKingTests
    {


        [TestMethod]
        public void TestvalidMove_AssertValidMove()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 1;
            currentPosition[1] = 1;

            int[] newPosition = new int[2];
            newPosition[0] = 2;
            newPosition[1] = 1;

            //Act
            King myKing = new King(true);
            bool result = myKing.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestValidMove_AssertInvalidMove()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 1;
            currentPosition[1] = 1;

            int[] newPosition = new int[2];
            newPosition[0] = 5;
            newPosition[1] = 1;

            //Act
            King myKing = new King(true);
            bool result = myKing.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void TestPieceNotMoving_AssertFalse()
        {
            //Arrange
            int[] position = new int[2];
            position[0] = 1;
            position[1] = 1;
            //Act
            King myKing = new King(true);
            bool result = myKing.MovePiece(position, position);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestFieldOccupiedByenemyPiece_AssertTrue()
        {
            Piece[,] board = new Piece[8, 8];
            board[0, 0] = new King(true);
            board[1, 0] = new King(false);
            CGameBoard myBoard = new CGameBoard(board); 
            
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 0;
            currentPosition[1] = 0;

            int[] newPosition = new int[2];
            newPosition[0] = 1;
            newPosition[1] = 0;

            //Act
            King myKing = new King(true);
            bool result = myKing.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestFieldOccupiedByFreindlyPiece_AssertFalse()
        {
            Piece[,] board = new Piece[8, 8];
            board[0, 0] = new King(true);
            board[1, 0] = new King(true);
            CGameBoard myBoard = new CGameBoard(board);

            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 0;
            currentPosition[1] = 0;

            int[] newPosition = new int[2];
            newPosition[0] = 1;
            newPosition[1] = 0;

            //Act
            King myKing = new King(true);
            bool result = myKing.MovePiece(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);

        }
    }
}
