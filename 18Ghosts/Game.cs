using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    class Game
    {
        // Variables
        private DrawGame drawGame;
        private Board board;
        private Player player1;
        private Player player2;
        private Player currentPlayer;
        private ConsoleKeyInfo key;

        private ConsoleColor selectedColor;
        private string input;
        private int currentTurn;
        private int currentX, currentY;

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

            // Does A while B is true
            // otherwise false
            do
            {
                drawGame.Draw();
                drawGame.PlayerStats(currentPlayer);
                if ( currentTurn < 2 /*currentPlayer.HasGhosts()*/)
                {
                    drawGame.AskForColor();
                    input = Console.ReadLine();
                    if (CheckColor(input))
                    {
                        drawGame.ClearLine();
                        drawGame.AskForPosition();
                        input = Console.ReadLine();
                        string secondInput = Console.ReadLine();
                        if (!CheckPosition(input, secondInput))
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
                    drawGame.GhostToPlay();
                    input = Console.ReadLine();
                    string secondInput = Console.ReadLine();
                    if (CheckGhost(input, secondInput))
                    {
                        drawGame.ClearLine();
                        drawGame.HouseToMoveTo();
                        key = Console.ReadKey();

                        // Check if can't update ghost to restart turn
                        if (!UpdateGhost())
                        {
                            continue;
                        }

                    }
                }
                drawGame.Draw();
                currentPlayer = currentPlayer == player1 ? player2 : player1;
                currentTurn++;
            }
            while (true);
            Console.ReadLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool UpdateGhost()
        {
            int x = currentX, y = currentY;
            bool temp = false;
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (currentY != 0)
                    {
                        y--;
                        temp = true;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (currentY != 4)
                    {
                        y++;
                        temp = true;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (currentX != 4)
                    {
                        x++;
                        temp = true;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (currentX != 0)
                    {
                        x--;
                        temp = true;
                    }
                    break;
                default:
                    return temp;
            }

            if (board.Houses[y, x].Portal != null ||
                (board.Houses[y, x].Ghost != null &&
                board.Houses[y, x].Ghost.Color == board.Houses[currentY, currentX].Ghost.Color))
            {
                temp = false;
            }


            if (temp)
            {
                MoveGhost(x, y);
            }

            return temp;
        }

        private void MoveGhost(int x, int y)
        {
            if (board.Houses[y, x].Mirror)
            {
                if (x == 1 && y == 1)
                {
                    board.Houses[3, 3].Ghost = board.Houses[currentY, currentX].Ghost;
                }
                else if (x == 3 && y == 1)
                {
                    board.Houses[3, 1].Ghost = board.Houses[currentY, currentX].Ghost;
                }
                else if (x == 1 && y == 3)
                {
                    board.Houses[1, 3].Ghost = board.Houses[currentY, currentX].Ghost;
                }
                else if (x == 3 && y == 3)
                {
                    board.Houses[1, 1].Ghost = board.Houses[currentY, currentX].Ghost;
                }
            }
            else if(board.Houses[y, x].IsEmpty)
            {
                board.Houses[y, x].Ghost = board.Houses[currentY, currentX].Ghost;
                board.Houses[y, x].IsEmpty = false;
            }
            else
            {
                ConsoleColor myColor = board.Houses[currentY, currentX].Ghost.Color;
                ConsoleColor otherColor = board.Houses[y, x].Ghost.Color;
                switch (myColor)
                {
                    case ConsoleColor.Red:
                        if (otherColor == ConsoleColor.Blue)
                        {
                            board.Houses[y, x].Ghost = board.Houses[currentY, currentX].Ghost;
                            RotatePortal(otherColor);
                        }
                        else
                        {
                            RotatePortal(myColor);
                        }
                        break;
                    case ConsoleColor.Blue:
                        if (otherColor == ConsoleColor.Red)
                        {
                            RotatePortal(myColor);
                        }
                        else
                        {
                            board.Houses[y, x].Ghost = board.Houses[currentY, currentX].Ghost;
                            RotatePortal(otherColor);
                        }
                        break;
                    case ConsoleColor.Yellow:
                        if (otherColor == ConsoleColor.Blue)
                        {
                            RotatePortal(myColor);
                        }
                        else
                        {
                            board.Houses[y, x].Ghost = board.Houses[currentY, currentX].Ghost;
                            RotatePortal(otherColor);
                        }
                        break;
                }
            }
            board.Houses[currentY, currentX].Ghost = null;
        }

        private void RotatePortal(ConsoleColor color)
        {
            switch (color)
            {
                case ConsoleColor.Red:
                    board.Houses[0, 2].Portal.Rotate();
                    break;
                case ConsoleColor.Blue:
                    board.Houses[4, 2].Portal.Rotate();
                    break;
                case ConsoleColor.Yellow:
                    board.Houses[2, 4].Portal.Rotate();
                    break;
            }
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

        private bool CheckGhost(string col, string row)
        {
            currentX = Convert.ToInt32(col);
            currentY = Convert.ToInt32(row);

            bool temp = false;

            if (board.Houses[currentY, currentX].Ghost != null &&
                board.Houses[currentY, currentX].Ghost.MyType == currentPlayer.MyType)
            {
                temp = true;
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
                    if (currentPlayer.MyType == Type.type1)
                    {
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
