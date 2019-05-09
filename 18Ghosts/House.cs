using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    class House
    {
        // Properties - Não precisa de se verificar
        public bool Mirror { get; private set; }
        public ConsoleColor Color { get; private set; }
        public Ghost Ghost { get; set; }
        public Portal Portal { get; private set; }
        public string Carpet { get; private set; }
        public bool IsEmpty { get; set; }

        // Constructors
        public House(ConsoleColor color, string carpet)
        {
            Color = color;
            Carpet = carpet;
            IsEmpty = true;
        }

        public House(bool mirror)
        {
            Mirror = mirror;
            IsEmpty = false;
        }

        public House(Portal portal)
        {
            Portal = portal;
            IsEmpty = false;
        }


    }
}

