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
        private int currentTurn;

        // Constructor
        public Game()
        {
            board = new Board();
            drawGame = new DrawGame(board);
            player1 = new Player(Type.type1, 9);
            player2 = new Player(Type.type2, 9);
            currentPlayer = player1;
            currentTurn = 0;
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
                drawGame.PlayerStats(currentPlayer);
                if (currentPlayer.HasGhosts())
                {
                    drawGame.AskForColor();
                    input = Console.ReadLine();
                    if (CheckColor(input))
                    {
                        drawGame.ClearLine();
                        drawGame.AskForPosition();
                        input = Console.ReadLine();
                        if (!CheckPosition(input, Console.ReadLine()))
                        {
                            drawGame.ClearLine();
                            drawGame.WrongPlace();
                            Console.ReadKey();
                            continue;
                        }
                    }
                    else
                    {
                        drawGame.ClearLine();
                        drawGame.WrongColor();
                        Console.ReadKey();
                        continue;
                    }
                }
                else
                {

                }
                drawGame.Draw();
                currentPlayer = currentPlayer == player1 ? player2 : player1;
                currentTurn++;
            }
            while (true);
            Console.ReadLine();
        }

        private bool CheckColor(string input)
        {
            bool temp;
            switch (input)
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
            Ghost ghost;

            if (x >= 5 || y >= 5)
            {
                return false;
            }

            if (board.Houses[y, x].IsEmpty && board.Houses[y, x].Color == selectedColor)
            {
                temp = true;
                if (currentTurn > 18)
                {
                    if (currentPlayer.MyType == Type.type1) {
                        ghost = new Ghost(Type.type2, selectedColor);
                    }
                    else
                    {
                        ghost = new Ghost(Type.type1, selectedColor);
                    }
                }
                else
                {
                    ghost = new Ghost(currentPlayer.MyType, selectedColor);
                }
                
                currentPlayer.RemoveGhost(selectedColor);
                board.PlaceGhosts(y, x, ghost);
            }

            return temp;
        }
    }
}
