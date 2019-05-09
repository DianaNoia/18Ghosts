using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    /// <summary>
    /// Contains an object to be on the board
    /// </summary>
    class House
    {
        /** \brief Properties */
        public bool Mirror { get; private set; }
        public ConsoleColor Color { get; private set; }
        public Ghost Ghost { get; set; }
        public Portal Portal { get; private set; }
        public string Carpet { get; private set; }
        public bool IsEmpty { get; set; }

        /// <summary>
        /// Constructors for Color
        /// </summary>
        /// <param name="color">House color</param>
        /// <param name="carpet">House carpet</param>
        public House(ConsoleColor color, string carpet)
        {
            Color = color;
            Carpet = carpet;
            IsEmpty = true;
        }

        /// <summary>
        /// Constructors for Mirror
        /// </summary>
        /// <param name="mirror">House mirror</param>
        public House(bool mirror)
        {
            Mirror = mirror;
            IsEmpty = false;
        }

        /// <summary>
        /// Constructors for Portal
        /// </summary>
        /// <param name="portal">House portal</param>
        public House(Portal portal)
        {
            Portal = portal;
            IsEmpty = false;
        }


    }
}

