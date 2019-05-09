using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    class Player
    {
        // Variables
        public Ghost[] Ghosts { get; private set; }
        public int YellowGhost { get; set; }
        public int RedGhost { get; set; }
        public int BlueGhost { get; set; }
        public Type type;

        //Constructor
        public Player(Type type, int nghosts)
        {
            this.type = type;
            Ghosts = new Ghost[nghosts];
            YellowGhost = 0;
            BlueGhost = 0;
            RedGhost = 0;
            InitGhosts();
        }

        private void InitGhosts()
        {
            for (int i = 0; i < Ghosts.Length; i++)
            {
                if (i < 3)
                {
                    Ghosts[i] = new Ghost(type, ConsoleColor.Red);
                    RedGhost++;
                }
                else if (i < 6)
                {
                    Ghosts[i] = new Ghost(type, ConsoleColor.Blue);
                    BlueGhost++;
                }
                else
                {
                    Ghosts[i] = new Ghost(type, ConsoleColor.Yellow);
                    YellowGhost++;
                }
            }
        }

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
