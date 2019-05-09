using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    /// <summary>
    /// Class for ghosts information
    /// </summary>
    class Ghost
    {
        /** \brief Property */
        public ConsoleColor Color { get; private set; }
        public Type MyType { get; private set; }

        /// <summary>
        /// Constructor Ghost
        /// </summary>
        /// <param name="myType">Ghost type</param>
        /// <param name="color">Ghost color</param>
        public Ghost(Type myType, ConsoleColor color)
        {
            MyType = myType;
            Color = color;
        }
    }
}
