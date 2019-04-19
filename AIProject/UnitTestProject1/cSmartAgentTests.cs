using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AIProject;
using System.Collections.Generic;


namespace SmartAgentTests
{
    [TestClass]
    public class SmartAgentClass
    {
        [TestMethod]
        public void testKingValidMovesList_Assert8ValidMoves()
        {
            //arrange
            Piece[,] tempBoard = new Piece[8, 8];
            King myKing = new King(true);
            tempBoard[3, 3] = myKing;

            SmartAgent tempAgent = new SmartAgent();
            PrivateObject obj = new PrivateObject(tempAgent);

            //act
            List<PotentialMove> actions = (List<PotentialMove>)obj.Invoke("ListAllPossibleActions", tempBoard, true);
            //assert

            Assert.AreEqual(8, actions.Count);
        }

        [TestMethod]
        public void CountUtility_Assert20()
        {

            //arrange
            Piece[,] tempBoard = new Piece[8, 8];
            King myKing = new King(true);
            tempBoard[3, 3] = myKing;

            SmartAgent tempAgent = new SmartAgent();
            PrivateObject obj = new PrivateObject(tempAgent);

            //act
            int utility = (int)obj.Invoke("CountUtility", tempBoard);

            //assert
            Assert.AreEqual(20, utility);

        }

        [TestMethod]
        public void ListWhitePawnValidMovesAtFirstMove_Assert3()
        {
            //arrange
            Piece[,] tempBoard = new Piece[8, 8];
            Pawn myPawn = new Pawn(true);
            Pawn blackPawn = new Pawn(false);
            tempBoard[2, 1] = myPawn;
            tempBoard[1, 2] = blackPawn;
            SmartAgent tempAgent = new SmartAgent();
            PrivateObject obj = new PrivateObject(tempAgent);


            //act
            List<PotentialMove> actions = (List<PotentialMove>)obj.Invoke("ListAllPossibleActions", tempBoard, true);


            //assert

            Assert.AreEqual(3, actions.Count);
        }

        [TestMethod]
        public void ListWhitePawnValidMoves_Assert2()
        {
            //arrange
            Piece[,] tempBoard = new Piece[8, 8];
            Pawn myPawn = new Pawn(true);
            Pawn blackPawn = new Pawn(false);
            tempBoard[2, 2] = myPawn;
            tempBoard[1, 3] = blackPawn;
            SmartAgent tempAgent = new SmartAgent();
            PrivateObject obj = new PrivateObject(tempAgent);


            //act
            List<PotentialMove> actions = (List<PotentialMove>)obj.Invoke("ListAllPossibleActions", tempBoard, true);


            //assert

            Assert.AreEqual(2, actions.Count);
        }

        [TestMethod]
        public void ListBlackPawnValidMovesAtFirstMove_Assert3()
        {
            //arrange
            Piece[,] tempBoard = new Piece[8, 8];
            Pawn myBlackPawn = new Pawn(false);
            Pawn myWhitePawn = new Pawn(true);
            tempBoard[2, 6] = myBlackPawn;
            tempBoard[1, 5] = myWhitePawn;
            SmartAgent tempAgent = new SmartAgent();
            PrivateObject obj = new PrivateObject(tempAgent);

            //act
            List<PotentialMove> actions = (List<PotentialMove>)obj.Invoke("ListAllPossibleActions", tempBoard, false);

            //assert

            Assert.AreEqual(3, actions.Count);
        }

        [TestMethod]
        public void CountAllKnightValidMoves_Assert8()
        {
            //arrange
            Piece[,] tempBoard = new Piece[8, 8];
            Knight myKnight = new Knight(true);
            tempBoard[3, 3] = myKnight;
            SmartAgent tempAgent = new SmartAgent();
            PrivateObject obj = new PrivateObject(tempAgent);

            //act
            List<PotentialMove> actions = (List<PotentialMove>)obj.Invoke("ListAllPossibleActions", tempBoard, true);

            //assert
            Assert.AreEqual(8, actions.Count);

        }

        [TestMethod]
        public void CountAllBishopValidMoves_Assert13()
        {
            //arrange
            Piece[,] tempBoard = new Piece[8, 8];
            Bishop myBishop = new Bishop(true);
            tempBoard[3, 3] = myBishop;
            SmartAgent tempAgent = new SmartAgent();
            PrivateObject obj = new PrivateObject(tempAgent);

            //act
            List<PotentialMove> actions = (List<PotentialMove>)obj.Invoke("ListAllPossibleActions", tempBoard, true);

            //assert
            Assert.AreEqual(13, actions.Count);

        }

        [TestMethod]
        public void CountAllRookValidMoves_Assert14()
        {
            //arrange
            Piece[,] tempBoard = new Piece[8, 8];
            Rook myRook = new Rook(true);
            tempBoard[3, 3] = myRook;
            SmartAgent tempAgent = new SmartAgent();
            PrivateObject obj = new PrivateObject(tempAgent);

            //act
            List<PotentialMove> actions = (List<PotentialMove>)obj.Invoke("ListAllPossibleActions", tempBoard, true);

            //assert
            Assert.AreEqual(14, actions.Count);

        }

        [TestMethod]
        public void CountAllQueenValidMoves_Assert27()
        {
            //arrange
            Piece[,] tempBoard = new Piece[8, 8];
            Queen myQueen = new Queen(true);
            tempBoard[3, 3] = myQueen;
            SmartAgent tempAgent = new SmartAgent();
            PrivateObject obj = new PrivateObject(tempAgent);

            //act
            List<PotentialMove> actions = (List<PotentialMove>)obj.Invoke("ListAllPossibleActions", tempBoard, true);

            //assert
            Assert.AreEqual(27, actions.Count);

        }

    }
}
