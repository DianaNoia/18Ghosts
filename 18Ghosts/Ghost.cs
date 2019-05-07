using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    class Ghost
    {
        // Property
        public ConsoleColor Color { get; private set; }
        public Type MyType { get; private set; }

        // Constructor
        public Ghost(Type myType, ConsoleColor color)
        {
            MyType = myType;
            Color = color;
        }
    }
}
