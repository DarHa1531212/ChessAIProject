//-----------------------------------------------------------------------
// <copyright file="Program.cs"  >
//     Copyright (c) 8INF700. All rights reserved.
//      Name: Hans Darmstadt-Bélanger
//      Goal: The entry point of the program
//      Date: 18/04/2019
// </copyright>
//-----------------------------------------------------------------------
namespace AIProject
{
    /// <summary>
    /// The entry point of the program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The program's entry point
        /// </summary>
        /// <param name="args">The entry point's arguments</param>
        public static void Main(string[] args)
        {
            GameBoard gameBoard = new GameBoard();
            gameBoard.GameLoop();
        }
    }
}
