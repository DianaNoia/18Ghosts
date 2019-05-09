using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    /// <summary>
    /// Responsible for creating and releasing the ghosts
    /// </summary>
    class Player
    {
        /**\brief Creates an array of ghosts*/
        public Ghost[] Ghosts { get; private set; }
        /**\brief Creates a FreeRedGhosts property*/
        public int FreeRedGhosts { get; set; }
        /**\brief Creates a FreeBlueGhosts property*/
        public int FreeBlueGhosts { get; set; }
        /**\brief Creates a FreeYellowGhosts property*/
        public int FreeYellowGhosts { get; set; }
        /**\brief Creates a YellowGhost property*/
        public int YellowGhost { get; set; }
        /**\brief Creates a RedGhost property*/
        public int RedGhost { get; set; }
        /**\brief Creates a BlueGhosts property*/
        public int BlueGhost { get; set; }
        /**\brief Contains instance of Type class*/
        public Type MyType { get; private set; }

        /// <summary>
        /// Method Player has all 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="nghosts"></param>
        public Player(Type type, int nghosts)
        {
            MyType = type;
            Ghosts = new Ghost[nghosts];
            YellowGhost = 0;
            BlueGhost = 0;
            RedGhost = 0;
            FreeRedGhosts = 0;
            FreeBlueGhosts = 0;
            FreeYellowGhosts = 0;
            InitGhosts();
        }

        /// <summary>
        /// Creates 3 ghosts of each color
        /// </summary>
        private void InitGhosts()
        {
            for (int i = 0; i < Ghosts.Length; i++)
            {
                if (i < 3)
                {
                    Ghosts[i] = new Ghost(MyType, ConsoleColor.Red);
                    RedGhost++;
                }
                else if (i < 6)
                {
                    Ghosts[i] = new Ghost(MyType, ConsoleColor.Blue);
                    BlueGhost++;
                }
                else
                {
                    Ghosts[i] = new Ghost(MyType, ConsoleColor.Yellow);
                    YellowGhost++;
                }
            }
        }

        /// <summary>
        /// Checks if the player still has ghosts
        /// </summary>
        /// <returns> if the player has ghosts </returns>
        public bool HasGhosts()
        {
            for (int i = 0; i < Ghosts.Length; i++)
            {
                if (Ghosts[i] != null)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Removes the ghosts from the player
        /// </summary>
        /// <param name="color"></param>
        public void RemoveGhost(ConsoleColor color)
        {
            switch (color)
            {
                case ConsoleColor.Red:
                    RedGhost--;
                    break;
                case ConsoleColor.Blue:
                    BlueGhost--;
                    break;
                case ConsoleColor.Yellow:
                    YellowGhost--;
                    break;
            }
            for (int i = 0; i < Ghosts.Length; i++)
            {
                if (Ghosts[i] != null && Ghosts[i].Color == color)
                {
                    Ghosts[i] = null;
                }
            }
        }
    }
}