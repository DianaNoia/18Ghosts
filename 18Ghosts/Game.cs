using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    class Game
    {
        DrawGame drawGame;
        Board board;

        // Constructor
        public Game()
        {
            board = new Board();
            drawGame = new DrawGame(board);
        }

        // Method to make turns until the end of the game
        public void GameLoop()
        {

            // Faz A enquando que B for Verdadero
            // Caso contrario é falso
            // Do While
            do
            {
                drawGame.Draw();
                break;

            }
            while (true);
            Console.ReadLine();
        }
    }
}
