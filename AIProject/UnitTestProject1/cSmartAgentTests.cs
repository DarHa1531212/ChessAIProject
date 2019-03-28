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
        public void testKingValidMovesList()
        {
            //arrange
            cPiece[,] tempBoard = new cPiece[8, 8];
            cKnight myKing = new cKnight(true);
            tempBoard[3, 3] = myKing;

            SmartAgent tempAgent = new SmartAgent();
            PrivateObject obj = new PrivateObject(tempAgent);

            //ListAllPossibleActions(cPiece[,] currentState, bool currentPlayer)



            //act
            List<cPiece[,]> actions = (List<cPiece[,]>)obj.Invoke("ListAllPossibleActions", tempBoard, true);
            //assert

            Assert.AreEqual(8, actions.Count);
        }
    }
}
