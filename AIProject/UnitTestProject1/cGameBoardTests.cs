using System;
using System.Text;
using System.Collections.Generic;
using AIProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameBoardTests
{
    /// <summary>
    /// Description résumée pour cGameBoardTests
    /// </summary>
    [TestClass]
    public class cGameBoardTests
    {

        [TestMethod]
        public void ValidateEndGame_WhiteWon()
        {

            //arrange            
            cPiece[,] tempBoard = new cPiece[8, 8];
            cKing myKing = new cKing(true);
            tempBoard[3, 3] = myKing;
            cGameBoard myGameBoard = new cGameBoard(tempBoard);


            PrivateObject obj = new PrivateObject(myGameBoard);
            bool a = false;

            //act
            bool utility = (bool)obj.Invoke("FindKings");

            //assert
            Assert.AreEqual(a, utility);

        }

        //[TestMethod]
        //public void FindKings_AssertWhiteKingNotFound()
        //{
        //    //arrange 
        //    cPiece[,] tempBoard = new cPiece[8, 8];
        //    cKing myKing = new cKing(false);
        //    tempBoard[3, 3] = myKing;
        //    cGameBoard myGameBoard = new cGameBoard(tempBoard);

        //    //act
        //    //FindKings
        //    PrivateObject obj = new PrivateObject(myGameBoard);
        //    bool value = obj.Invoke()



        //}
    }
}
