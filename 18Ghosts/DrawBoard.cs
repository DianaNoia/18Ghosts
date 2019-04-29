using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    class DrawBoard
    {
        /* CARPET ═ \u2550, ║ \u2551, ╔ \u2554, ╗ \u2557, ╚ \u255A, ╝ \u255D, 
            ╬ \u256C ╦ \u2566 ╩ \u2569 ╠ \u2560  ╣ \u2563 */

        // Board method which creates board 
        public static void Board()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            String[] board = { "\u2554", "\u2550", "\u2566", "\u2557", "\u2551", "\u2560", "\u256C", "\u2563", "\u255A", "\u2569", "\u255D" };

            Console.WriteLine("_______________________________________________ ");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine($"  {board[0]}   |   {board[2]}   |   {board[2]}   |   {board[2]}   |   {board[3]}   |        |");
            Console.WriteLine("______|_______|_______|_______|_______|        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine($"  {board[5]}   |   {board[6]}   |   {board[6]}   |   {board[6]}   |   {board[7]}   |        |");
            Console.WriteLine("______|_______|_______|_______|_______|        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine($"  {board[5]}   |   {board[6]}   |   {board[6]}   |   {board[6]}   |   {board[7]}   |        |");
            Console.WriteLine("______|_______|_______|_______|_______|        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine($"  {board[5]}   |   {board[6]}   |   {board[6]}   |   {board[6]}   |   {board[7]}   |        |");
            Console.WriteLine("______|_______|_______|_______|_______|        |");
            Console.WriteLine("      |       |       |       |       |        |");
            Console.WriteLine($"  {board[8]}   |   {board[9]}   |   {board[9]}   |   {board[9]}   |   {board[10]}   |        |");
            Console.WriteLine("______|_______|_______|_______|_______|________|");
            Console.WriteLine();
        }
    }
}