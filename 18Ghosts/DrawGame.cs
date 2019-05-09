using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    /// <summary>
    /// Class to draw in the console
    /// </summary>
    class DrawGame
    {
        /** \brief  Variables */
        private Board board;
        int x, y;

        /// <summary>
        /// Contructor DrawGame
        /// </summary>
        /// <param name="board">Draw game</param>
        public DrawGame(Board board)
        {
            this.board = board;
        }

        /// <summary>
        /// Board method which creates board
        /// </summary>
        public void Draw()
        {
            string[] board = { "\u2554", "\u2550", "\u2566", "\u2557", "\u2551", "\u2560", "\u256C", "\u2563", "\u255A", "\u2569", "\u255D" };

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("_______________________________________________ ");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("______|_______|_______|_______|_______|        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("______|_______|_______|_______|_______|        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("______|_______|_______|_______|_______|        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("______|_______|_______|_______|_______|        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("______|_______|_______|_______|_______|________|");
            Console.WriteLine();
            Legend();
            DrawVerification();

        }

        /// <summary>
        /// Method to show the legend
        /// </summary>
        public void Legend()
        {
            Console.SetCursorPosition(55, 5);
            Console.Write(" Carpet         ║  ╔ ╗ ═ ╚ ╝ ╬ ╦ ╩ ╠ ╣ ");
            Console.SetCursorPosition(55, 7);
            Console.Write(" Portal         N ╿ . S ╽ . E ╼  . W ╾ ");
            Console.SetCursorPosition(55, 8);
            Console.Write(" Portal...      Aberto ->  ╾  <- Fechado ");
            Console.SetCursorPosition(55, 10);
            Console.Write(" Mirror         ♦ ");

            Console.SetCursorPosition(55, 12);
            Console.Write(" G1 - Ghost 1   ☻ ");
            Console.SetCursorPosition(55, 14);
            Console.Write(" G2 - Ghost 2   ◌ ");
        }

        /// <summary>
        /// Method to make the draw verification 
        /// </summary>
        private void DrawVerification()
        {
            for (int rows = 0; rows < 5; rows++)
            {
                y = (rows + 1) * 3;

                for (int columns = 0; columns < 5; columns++)
                {
                    switch (columns)
                    {
                        case 0:
                            x = 2;
                            break;
                        case 1:
                            x = 10;
                            break;
                        case 2:
                            x = 18;
                            break;
                        case 3:
                            x = 26;
                            break;
                        case 4:
                            x = 34;
                            break;
                    }

                    Console.SetCursorPosition(x, y);

                    //brief Draws Ghost 
                    if (board.Houses[rows, columns].Ghost != null)
                    {
                        Console.ForegroundColor = board.Houses[rows, columns].Ghost.Color;
                        if (board.Houses[rows, columns].Ghost.MyType == Type.type1)
                        {
                            Console.WriteLine("\u263B");
                        }
                        else if (board.Houses[rows, columns].Ghost.MyType == Type.type2)
                        {
                            Console.WriteLine("\u25CC");
                        }

                    }
                    //brief Draws empty house 
                    else if (board.Houses[rows, columns].Color != (ConsoleColor.Black))
                    {
                        Console.ForegroundColor = board.Houses[rows, columns].Color;
                        Console.Write(board.Houses[rows, columns].Carpet);
                    }
                    // \brief Draws Portal 
                    else if (board.Houses[rows, columns].Portal != null)
                    {
                        Console.ForegroundColor = board.Houses[rows, columns].Portal.Color;
                        Portal temp = board.Houses[rows, columns].Portal;
                        Console.Write(temp.portal[(int)temp.MyRotation]);
                    }
                    // \brief Draws Mirror 
                    else if (board.Houses[rows, columns].Mirror)
                    {
                        Console.Write("\u2666");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        /// <summary>
        /// Method to ask the user witch color he want
        /// </summary>
        public void AskForColor()
        {
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("    What color ghost do you want to place? (E.g.: Red)");
        }

        /// <summary>
        /// Method to ask the use witch position he want
        /// </summary>
        public void AskForPosition()
        {
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("    In what position do you want to place it?");
            Console.WriteLine("    (Position x e.g. 2 | Position y e.g. 3)");

        }

        /// <summary>
        /// Method to warn that the color is not available
        /// </summary>
        public void WrongColor()
        {
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("    That color is unavailable try again...");
        }

        /// <summary>
        /// Method to warn the place is ocupied
        /// </summary>
        public void WrongPlace()
        {
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("    That location can't be ocupied...");
        }

        /// <summary>
        /// Method to ask if the user wants to release ghosts from the dungeon
        /// </summary>
        public void AskForDungeon()
        {
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("    Do you want to free a ghost from the dungeon?");
        }

        /// <summary>
        /// Method to asks the position of the ghost he wants to move 
        /// </summary>
        public void GhostToPlay()
        {
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("    What's the position of the ghost you want to control?");
        }

        /// <summary>
        /// Method to tell userto move the keys
        /// </summary>
        public void HouseToMoveTo()
        {
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("    Use the arrow keys to move to one house in any direction.");
        }

        /// <summary>
        /// Method to clear the input and output lines
        /// </summary>
        public void ClearLine()
        {
            Console.SetCursorPosition(0, 28);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 29);
            Console.Write(new string(' ', Console.WindowWidth));
        }

        /// <summary>
        /// Method that displayes the current player states
        /// </summary>
        /// <param name="player">Player states</param>
        public void PlayerStats(Player player)
        {
            Console.SetCursorPosition(0, 18);
            Console.WriteLine("  Player Stats: ");
            if (player.MyType == Type.type1)
            {
                Console.WriteLine("  Current PLayer: PLayer 1 \n");
            }
            else
            {
                Console.WriteLine(" > Current PLayer: PLayer 2 \n");
            }
            Console.WriteLine($" > Red Ghosts: {player.RedGhost}\n");
            Console.WriteLine($" > Blue Ghosts: {player.BlueGhost}\n");
            Console.WriteLine($" > Yellow Ghosts: {player.YellowGhost}\n");
        }
    }
}

/* CARPET ═ U+2550, ║ \u2551, ╔ U +2554, ╗ U+2557, ╚ U+255A, ╝ U+255D, 
           ╬ \u256C ╦ 2566 ╩ \u2569 ╠ U+2560  ╣ U+2563 */

//PORTAL ╼ U+257C ╾ U+257E ╽ U+257D ╿ U+257F

// ESPELHO † \u2020 ‡ \u2021 ♦ \u2666

//2 TIPOS DE PHANTASMAS ░ \u2591 ▓ \u2593 ֍ \u058D ◌ \u25CC ● \u25CF ☻ \u263B
