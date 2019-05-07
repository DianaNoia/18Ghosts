using System;
using System.Text;

namespace _18Ghosts
{
    class Program
    {
        // Begining of the program
        static void Main(string[] args)
        {
            // Reads complex symbols
            Console.OutputEncoding = Encoding.UTF8;

            // Declares Class Menu and iniciates method Menu()
            Menu menu = new Menu();

            // Calls class Menu in the method Intro()
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