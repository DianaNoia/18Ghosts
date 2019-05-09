using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    /// <summary>
    /// Class to show the unicodes position, type, color and rotation
    /// </summary>
    class Board
    {

        /** \brief  Variavel */
        private Portal portalYellow, portalRed, portalBlue;
        /** \brief  Property */
        public House[,] Houses { get; private set; }
        /** \brief  String array to give the unicode in the board */
        string[] board = { "\u2554", "\u2550", "\u2566", "\u2557", "\u2551", "\u2560", "\u256C", "\u2563", "\u255A", "\u2569", "\u255D" };

        /// <summary>
        /// Contructor Board
        /// </summary>
        public Board()
        {
            portalYellow = new Portal(Rotation.East, ConsoleColor.Yellow);
            portalRed = new Portal(Rotation.North, ConsoleColor.Red);
            portalBlue = new Portal(Rotation.South, ConsoleColor.Blue);
            Houses = new House[5, 5];
            IniHouses();
        }

        /// <summary>
        /// Method to initiate the houses
        /// </summary>
        private void IniHouses()
        {
            Houses[0, 0] = new House(ConsoleColor.Blue, board[0]);
            Houses[0, 1] = new House(ConsoleColor.Red, board[2]);
            Houses[0, 2] = new House(portalRed);
            Houses[0, 3] = new House(ConsoleColor.Blue, board[2]);
            Houses[0, 4] = new House(ConsoleColor.Red, board[3]);
            Houses[1, 0] = new House(ConsoleColor.Yellow, board[5]);
            Houses[1, 1] = new House(true);
            Houses[1, 2] = new House(ConsoleColor.Yellow, board[6]);
            Houses[1, 3] = new House(true);
            Houses[1, 4] = new House(ConsoleColor.Yellow, board[7]);
            Houses[2, 0] = new House(ConsoleColor.Red, board[5]);
            Houses[2, 1] = new House(ConsoleColor.Blue, board[6]);
            Houses[2, 2] = new House(ConsoleColor.Red, board[6]);
            Houses[2, 3] = new House(ConsoleColor.Blue, board[6]);
            Houses[2, 4] = new House(portalYellow);
            Houses[3, 0] = new House(ConsoleColor.Blue, board[5]);
            Houses[3, 1] = new House(true);
            Houses[3, 2] = new House(ConsoleColor.Yellow, board[6]);
            Houses[3, 3] = new House(true);
            Houses[3, 4] = new House(ConsoleColor.Red, board[7]);
            Houses[4, 0] = new House(ConsoleColor.Yellow, board[8]);
            Houses[4, 1] = new House(ConsoleColor.Red, board[9]);
            Houses[4, 2] = new House(portalBlue);
            Houses[4, 3] = new House(ConsoleColor.Blue, board[9]);
            Houses[4, 4] = new House(ConsoleColor.Yellow, board[10]);
        }

        /// <summary>
        /// Method to place the ghosts in the houses
        /// </summary>
        /// <param name="row">Bard row</param>
        /// <param name="column">Board column</param>
        /// <param name="ghost">Ghost to place</param>
        public void PlaceGhosts(int row, int column, Ghost ghost)
        {
            Houses[row, column].Ghost = ghost;
            Houses[row, column].IsEmpty = false;
        }
    }
}
