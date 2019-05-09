using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    class Game
    {
        private DrawGame drawGame;
        private Board board;
        private Player player1;
        private Player player2;
        private Player currentPlayer;

        private ConsoleColor selectedColor;
        private string input;

        // Constructor
        public Game()
        {
            board = new Board();
            drawGame = new DrawGame(board);
            player1 = new Player(Type.type1, 9);
            player2 = new Player(Type.type2, 9);
            currentPlayer = player1;
            
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
                if (currentPlayer.HasGhosts())
                {
                    drawGame.AskForColor();
                    input = Console.ReadLine();
                    if (CheckColor(input))
                    {
                        drawGame.AskForPosition();
                        input = Console.ReadLine();
                        if (!CheckPosition(input, Console.ReadLine()))
                        {
                            drawGame.WrongPlace();
                            Console.ReadKey();
                            continue;
                        }
                    } else
                    {
                        drawGame.WrongColor();
                        Console.ReadKey();
                        continue;
                    }
                }
                drawGame.Draw();
                currentPlayer = currentPlayer == player1 ? player2 : player1;
            }
            while (true);
            Console.ReadLine();
        }

        private bool CheckColor(string input)
        {
            bool temp;
            switch(input)
            {
                case "Red":
                    temp = currentPlayer.RedGhost > 0;
                    selectedColor = ConsoleColor.Red;
                    break;
                case "Blue":
                    temp = currentPlayer.BlueGhost > 0;
                    selectedColor = ConsoleColor.Blue;
                    break;
                case "Yellow":
                    temp = currentPlayer.YellowGhost > 0;
                    selectedColor = ConsoleColor.Yellow;
                    break;
                default:
                    temp = false;
                    break;
            }

            return temp;
        }

        private bool CheckPosition(string col, string row)
        {
            int x = Convert.ToInt32(col);
            int y = Convert.ToInt32(row);
            bool temp = false;

            if (x >= 5 || y >= 5)
            {
                return false;
            }

            if (board.Houses[y, x].IsEmpty && board.Houses[y, x].Color == selectedColor)
            {
                temp = true;
                Ghost ghost = new Ghost(currentPlayer.type, selectedColor);
                currentPlayer.RemoveGhost(selectedColor);
                board.PlaceGhosts(y, x, ghost);
            }

            return temp;
        }
    }
}
