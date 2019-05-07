using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    class DrawBoard
    {
        // Variables 
        private Board board;
        int x, y;

        // Constructor
        public DrawGame(Board board)
        {
            this.board = board;
        }

        // Board method which creates board 
        public static void Draw()
        {
            // Console.BackgroundColor = ConsoleColor.DarkGray;
            string[] board = { "\u2554", "\u2550", "\u2566", "\u2557", "\u2551", "\u2560", "\u256C", "\u2563", "\u255A", "\u2569", "\u255D" };

            Console.WriteLine("________________________________________________");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("______|_______|_______|_______|_______|        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("______|_______|_______|_______|_______|        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("______|_______|_______|_______|_______|        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("______|_______|_______|_______|_______|        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine("______|_______|_______|_______|_______|________|");
            Console.WriteLine();
            FirstStep();


        }
        public void FirstStep()
        {
            Console.SetCursorPosition(57, 4);
            Console.Write(" - G1 - ");
            Console.SetCursorPosition(57, 5);
            Console.Write(" [ X ] ");
            Console.SetCursorPosition(57, 7);
            Console.Write(" <  > ");

            Console.SetCursorPosition(57, 10);
            Console.Write(" - G2 - ");
            Console.SetCursorPosition(57, 11);
            Console.Write(" [ O ] ");
            Console.SetCursorPosition(57, 13);
            Console.Write(" <  > ");

        }
    }
}