using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    /// <summary>
    /// Responsible for game mechanics and game loop
    /// </summary>
    class Game
    {
        /**\brief Contains instance of DrawGame class*/
        private DrawGame drawGame;
        /**\brief Contains instance of Board class*/
        private Board board;
        /**\brief Contains instance of Player class*/
        private Player player1;
        /**\brief Contains instance of Player class*/
        private Player player2;
        /**\brief Contains instance of Player class*/
        private Player currentPlayer;
        /**\brief Instance of ConsoleKeyInfo*/
        private ConsoleKeyInfo key;

        /**\brief Holds current selected color*/
        private ConsoleColor selectedColor;
        /**\brief Checks for Win Condition*/
        private bool winCondition;
        /**\brief Holds user input*/
        private string input;
        /**\brief Holds CurrentTurn*/
        private int currentTurn;
        /**\brief Holds the current X and Y positions*/
        private int currentX, currentY;

        /// <summary>
        /// Game constructor
        /// </summary>
        public Game()
        {
            // Initializes all necessary variables
            board = new Board();
            drawGame = new DrawGame(board);
            player1 = new Player(Type.type1, 9);
            player2 = new Player(Type.type2, 9);
            currentPlayer = player1;
            currentTurn = 1;
            winCondition = false;
        }

        /// <summary>
        /// Loops Game
        /// </summary>
        public void GameLoop()
        {

            // Does A while B is true
            // otherwise false
            do
            {
                // Draws game and playerstats
                drawGame.Draw();
                drawGame.PlayerStats(currentPlayer);
                // Checks if any player still has ghosts
                if (currentPlayer.HasGhosts())
                {
                    // If so he has to place them on board
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
                CheckNearPortals();
                drawGame.Draw();
                CheckForWin();
                currentPlayer = currentPlayer == player1 ? player2 : player1;
                currentTurn++;
            }
            // Checks if win condition is false
            while (!winCondition);
            Console.ReadLine();
        }

        /// <summary>
        /// Checks Win status
        /// </summary>
        private void CheckForWin()
        {
            if (currentPlayer.FreeBlueGhosts != 0 && currentPlayer.FreeRedGhosts != 0 &&
                currentPlayer.FreeYellowGhosts != 0)
            {
                winCondition = true;
                Console.Clear();
                if (currentPlayer.MyType == Type.type1) {
                    Console.WriteLine("Player 1 Wins!");
                }
                else
                {
                    Console.WriteLine("Player 2 Wins!");
                }
            }
        }

        /// <summary>
        /// Checks houses near portals
        /// </summary>
        private void CheckNearPortals()
        {
            // Checks houses around Red Portal
            switch (board.Houses[0, 2].Portal.MyRotation)
            {
                case Rotation.East:
                    if (!board.Houses[0, 3].IsEmpty && board.Houses[0, 3].Ghost.Color == ConsoleColor.Red)
                    {
                        currentPlayer.FreeRedGhosts++;
                    }
                    break;
                case Rotation.South:
                    if (!board.Houses[1, 2].IsEmpty && board.Houses[1, 2].Ghost.Color == ConsoleColor.Red)
                    {
                        currentPlayer.FreeRedGhosts++;
                    }
                    break;
                case Rotation.West:
                    if (!board.Houses[0, 1].IsEmpty && board.Houses[0, 1].Ghost.Color == ConsoleColor.Red)
                    {
                        currentPlayer.FreeRedGhosts++;
                    }
                    break;
            }
            // Checks houses around Blue Portal
            switch (board.Houses[4, 2].Portal.MyRotation)
            {
                case Rotation.East:
                    if (!board.Houses[4, 3].IsEmpty && board.Houses[4, 3].Ghost.Color == ConsoleColor.Blue)
                    {
                        currentPlayer.FreeBlueGhosts++;
                    }
                    break;
                case Rotation.North:
                    if (!board.Houses[3, 2].IsEmpty && board.Houses[3, 2].Ghost.Color == ConsoleColor.Blue)
                    {
                        currentPlayer.FreeBlueGhosts++;
                    }
                    break;
                case Rotation.West:
                    if (!board.Houses[4, 2].IsEmpty && board.Houses[4, 2].Ghost.Color == ConsoleColor.Blue)
                    {
                        currentPlayer.FreeBlueGhosts++;
                    }
                    break;
            }
            // Checks houses around Yellow Portal
            switch (board.Houses[2, 4].Portal.MyRotation)
            {
                case Rotation.North:
                    if (!board.Houses[1, 4].IsEmpty && board.Houses[1, 4].Ghost.Color == ConsoleColor.Yellow)
                    {
                        currentPlayer.FreeYellowGhosts++;
                    }
                    break;
                case Rotation.South:
                    if (!board.Houses[3, 4].IsEmpty && board.Houses[3, 4].Ghost.Color == ConsoleColor.Yellow)
                    {
                        currentPlayer.FreeYellowGhosts++;
                    }
                    break;
                case Rotation.West:
                    if (!board.Houses[2, 3].IsEmpty && board.Houses[2, 3].Ghost.Color == ConsoleColor.Yellow)
                    {
                        currentPlayer.FreeYellowGhosts++;
                    }
                    break;
            }
        }

        /// <summary>
        /// Updates the ghost position
        /// </summary>
        /// <returns> update the ghost position </returns>
        private bool UpdateGhost()
        {
            int x = currentX, y = currentY;
            bool temp = false;
            
            // Updates the position for each key  
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

        /// <summary>
        /// Moves the Ghost
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void MoveGhost(int x, int y)
        {
            // Updates the position of ghost if it's moved into a mirror house
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
            // If the ghost is moved into an empty house, it occupies it
            else if(board.Houses[y, x].IsEmpty)
            {
                board.Houses[y, x].Ghost = board.Houses[currentY, currentX].Ghost;
                board.Houses[y, x].IsEmpty = false;
            }
            // If ghost moves into house with another ghost already in it
            else
            {
                ConsoleColor myColor = board.Houses[currentY, currentX].Ghost.Color;
                ConsoleColor otherColor = board.Houses[y, x].Ghost.Color;
                // Checks which ghost wins the fight and stays in the house
                // Rotates the portal of the loser's color
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
            board.Houses[currentY, currentX].IsEmpty = true;
        }

        /// <summary>
        /// Rotates the portals
        /// </summary>
        /// <param name="color"></param>
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

        /// <summary>
        /// Checks the color chosen by the player
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool CheckColor(string input)
        {
            bool temp;
            // checks the input for the color given by player
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

        /// <summary>
        /// Checks if the current house has a ghost 
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checks if the selected position is compatible with the ghost the player wants to play
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
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
