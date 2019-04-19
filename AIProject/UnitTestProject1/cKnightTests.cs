using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AIProject;

namespace KnightTests
{
    [TestClass]
    public class cKnightTests
    {
        [TestMethod]
        public void TestKnightDownLeftMove_AssertTrue()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 2;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 1;
            newPosition[1] = 1;

            //Act
            King myKnight = new King(true);
            bool result = myKnight.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestKnightDownRightMove_AssertTrue()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 2;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 3;
            newPosition[1] = 1;

            //Act
            King myKnight = new King(true);
            bool result = myKnight.TestValidMove(currentPosition, newPosition);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestKnightUpRightMove_AssertTrue()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 2;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 3;
            newPosition[1] = 5;

            //Act
            King myKnight = new King(true);
            bool result = myKnight.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestKnightUpLeftMove_AssertTrue()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 2;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 1;
            newPosition[1] = 5;

            //Act
            King myKnight = new King(true);
            bool result = myKnight.TestValidMove(currentPosition, newPosition);
        }

        [TestMethod]
        public void TestKnightLeftUpMove_AssertTrue()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 2;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 0;
            newPosition[1] = 2;

            //Act
            King myKnight = new King(true);
            bool result = myKnight.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestKnightLeftDownMove_AssertTrue()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 2;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 0;
            newPosition[1] = 4;

            //Act
            King myKnight = new King(true);
            bool result = myKnight.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestKnightRightDownMove_AssertTrue()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 2;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 4;
            newPosition[1] = 4;

            //Act
            King myKnight = new King(true);
            bool result = myKnight.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestKnightRightUpMove_AssertTrue()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 2;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 4;
            newPosition[1] = 2;

            //Act
            King myKnight = new King(true);
            bool result = myKnight.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestKnightInvalidMove_AssertFalse()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 2;
            currentPosition[1] = 3;

            int[] newPosition = new int[2];
            newPosition[0] = 5;
            newPosition[1] = 2;

            //Act
            Knight myKnight = new Knight(true);
            bool result = myKnight.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void TestKnightOutOfBoundsMove_AssertFalse()
        {
            //Arrange
            int[] currentPosition = new int[2];
            currentPosition[0] = 1;
            currentPosition[1] = 6;

            int[] newPosition = new int[2];
            newPosition[0] = 0;
            newPosition[1] = 8;

            //Act
            King myKnight = new King(true);
            bool result = myKnight.TestValidMove(currentPosition, newPosition);

            //Assert
            Assert.IsFalse(result);

        }
    }
}
