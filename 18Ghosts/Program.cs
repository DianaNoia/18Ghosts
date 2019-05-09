using System;
using System.Text;

namespace _18Ghosts
{
    /// <summary>
    /// Starting Class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Reads complex symbols
            Console.OutputEncoding = Encoding.UTF8;

            // Declares the Class Menu and initiates method Menu
            Menu menu = new Menu();

            // Calls class Menu in the method Intro
            menu.Intro();
        }
    }
}

/*
_______________________________________________
      |       |       |       |       |        |
  ╔   |   ╦   |   ╦   |   ╦   |   ╗   |        |
______|_______|_______|_______|_______|        |
      |       |       |       |       |        |
  ╠   |   ╬   |   ╬   |   ╬   |   ╣   |        |
______|_______|_______|_______|_______|        |
      |       |       |       |       |        |
  ╠   |   ╬   |   ╬   |   ╬   |   ╣   |        |
______|_______|_______|_______|_______|        |
      |       |       |       |       |        |
  ╠   |   ╬   |   ╬   |   ╬   |   ╣   |        |
______|_______|_______|_______|_______|        |
      |       |       |       |       |        |
  ╚   |   ╩   |   ╩   |   ╩   |   ╝   |        |
______|_______|_______|_______|_______|________|
*/