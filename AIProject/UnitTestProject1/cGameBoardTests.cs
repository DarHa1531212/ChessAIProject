using System;
using System.Text;
using System.Collections.Generic;
using AIProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    /// <summary>
    /// Description résumée pour cGameBoardTests
    /// </summary>
    [TestClass]
    public class cGameBoardTests
    {

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ValidateEndGame_WhiteWon()
        {

            //arrange            
            cPiece[,] tempBoard = new cPiece[8, 8];
            cKing myKing = new cKing(true);
            tempBoard[3, 3] = myKing;
            cGameBoard myGameBoard = new cGameBoard(tempBoard);


            PrivateObject obj = new PrivateObject(myGameBoard);
            bool a = true;

            //act
            bool utility = (bool)obj.Invoke("FindKings");

            //assert
            Assert.AreEqual(a, utility);

        }
    }
}
