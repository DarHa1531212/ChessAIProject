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
            cPiece[,] tempBoard = new cPiece[8, 8];
            cKing myKing = new cKing(true);
            tempBoard[3, 3] = myKing;

            SmartAgent tempAgent = new SmartAgent();
            PrivateObject obj = new PrivateObject(tempAgent);

            //act
            List<cPiece[,]> actions = (List<cPiece[,]>)obj.Invoke("ListAllPossibleActions", tempBoard, true);
            //assert

            Assert.AreEqual(8, actions.Count);
        }

        [TestMethod]
        public void CountUtility_Assert20()
        {

            //arrange
            cPiece[,] tempBoard = new cPiece[8, 8];
            cKing myKing = new cKing(true);
            tempBoard[3, 3] = myKing;

            SmartAgent tempAgent = new SmartAgent();
            PrivateObject obj = new PrivateObject(tempAgent);

            //act
            int utility = (int)obj.Invoke("CountUtility", tempBoard);

            //assert
            Assert.AreEqual(20, utility);

        }

        [TestMethod]
        public void ListPawnValidMoves_Assert3()
        {
            //arrange
            cPiece[,] tempBoard = new cPiece[8, 8];
            Pawn myPawn = new Pawn(true);
            Pawn blackPawn = new Pawn(false);
            tempBoard[2, 1] = myPawn;
            tempBoard[1, 2] = blackPawn;
            SmartAgent tempAgent = new SmartAgent();
            PrivateObject obj = new PrivateObject(tempAgent);

            
            //act
            List<cPiece[,]> actions = (List<cPiece[,]>)obj.Invoke("ListAllPossibleActions", tempBoard, true);


            //assert

            Assert.AreEqual(3, actions.Count);
        }


    }
}
