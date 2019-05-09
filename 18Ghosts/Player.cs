using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    class Player
    {
        // Variables
        public Ghost[] Ghosts { get; private set; }
        public Type type;

        //Constructor
        public Player (Type type, int nghosts)
        {
            this.type = type;
            Ghosts = new Ghost[nghosts];
        }

        private void InitGhosts()
        {
            for(int i=0; i<Ghosts.Length; i++)
            {
                if (i < 3)
                {
                    Ghosts[i] = new Ghost(type, ConsoleColor.Red);
                }
                else if (i < 6)
                {
                    Ghosts[i] = new Ghost(type, ConsoleColor.Blue);
                }
                else
                {
                    Ghosts[i] = new Ghost(type, ConsoleColor.Yellow);
                }
            }
        }
    }
}
