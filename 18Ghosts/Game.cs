using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    class Game
    {
        public Game()
        {

        }

        // Method to make turns until the end of th game
        public void GameLoop()
        {

            // Faz A enquando que B for Verdadero
            // Caso contrario é falso
            // Do While
            do
            {
                Console.Clear();
                Console.WriteLine();
                DrawBoard.Board();
                break;
            }
            while (true);
            Console.ReadLine();
        }
    }
}
