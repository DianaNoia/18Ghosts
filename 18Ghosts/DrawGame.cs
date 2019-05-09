using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    class DrawGame
    {
        // Variable
        private Board board;
        int x, y;

        // Contructor
        public DrawGame(Board board)
        {
            this.board = board;
        }

        // Board method which creates board 
        public void Draw()
        {
            string[] board = { "\u2554", "\u2550", "\u2566", "\u2557", "\u2551", "\u2560", "\u256C", "\u2563", "\u255A", "\u2569", "\u255D" };

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("_______________________________________________ ");
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
            Legend();
            DrawVerification();

        }

        public void FirstStep()
        {
            Console.SetCursorPosition(57, 4);
            Console.Write(" - G1 - ");
            Console.SetCursorPosition(57, 5);
            Console.Write(" [ X ] ");
            Console.SetCursorPosition(57, 7);
            Console.Write("  <-> ");

            Console.SetCursorPosition(57, 10);
            Console.Write(" - G2 - ");
            Console.SetCursorPosition(57, 12);
            Console.Write(" [ O ] ");
            Console.SetCursorPosition(57, 13);
            Console.Write(" <   > ");
        }

        // LEGENDA COM OS SIMBOLOS !!!!!
        public void Legend()
        {
            Console.SetCursorPosition(35, 19);
            Console.Write(" Carpet      ║  ╔ ╗ ═ ╚ ╝ ╬ ╦ ╩ ╠ ╣");
            Console.SetCursorPosition(35, 21);
            Console.Write(" Portal      N ╿ . S ╽ . E ╼  . W ╾");
            Console.SetCursorPosition(35, 23);
            Console.Write(" Mirror      ♦");

            // MOSTRAR AS TRES CORES DOS GHOSTS
            Console.SetCursorPosition(32, 25);
            Console.Write(" G1 - Ghost 1   ☻ ");
            Console.SetCursorPosition(32, 27);
            Console.Write(" G2 - Ghost 2   ◌ ");
        }

        private void DrawVerification()
        {
            for (int rows = 0; rows < 5; rows++)
            {
                y = (rows + 1) * 3;

                for (int columns = 0; columns < 5; columns++)
                {
                    switch (columns)
                    {
                        case 0:
                            x = 2; 
                            break;
                        case 1:
                            x = 10;
                            break;
                        case 2:
                            x = 18;
                            break;
                        case 3:
                            x = 24;
                            break;
                        case 4:
                            x = 32; 
                            break;
                    }

                    Console.SetCursorPosition(x, y);

                    // Draws Ghost
                    if (board.Houses[rows, columns].Ghost != null)
                    {
                        Console.ForegroundColor = board.Houses[rows, columns].Ghost.Color;
                        if (board.Houses[rows, columns].Ghost.MyType==Type.type1)
                        {
                            Console.WriteLine("\u263B");
                        }
                        else if (board.Houses[rows, columns].Ghost.MyType == Type.type2)
                        {
                            Console.WriteLine("\u25CC");
                        }

                    }
                    // Draws empty house
                    else if (board.Houses[rows, columns].Color != (ConsoleColor.Black))
                    {
                        Console.ForegroundColor = board.Houses[rows, columns].Color;
                        Console.Write(board.Houses[rows, columns].Carpet);
                    }
                    // Draws Portal
                    else if (board.Houses[rows, columns].Portal != null)
                    {
                        Console.ForegroundColor = board.Houses[rows, columns].Portal.Color;
                        Portal temp = board.Houses[rows, columns].Portal;
                        Console.Write(temp.portal[(int)temp.MyRotation]);
                    }
                    // Draws Mirror
                    else if (board.Houses[rows, columns].Mirror)
                    {
                        Console.Write("\u2666");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}

/* CARPET ═ U+2550, ║ \u2551, ╔ U +2554, ╗ U+2557, ╚ U+255A, ╝ U+255D, 
           ╬ \u256C ╦ 2566 ╩ \u2569 ╠ U+2560  ╣ U+2563 */

//PORTAL ╼ U+257C ╾ U+257E ╽ U+257D ╿ U+257F

// ESPELHO † \u2020 ‡ \2021 ♦ \u2666
// ⯌  U+2BCC ⯍ U+2BCD

//2 TIPOS DE PHANTASMAS ░ \u2591 ▓ \u2593 ֍ \u058D ◌ \u25CC ● \u25CF ☻ \u263B
//Console.ForegroundColor = ConsoleColor.Blue;
//Console.WriteLine("\t\u26C4 ");
//Console.ForegroundColor = ConsoleColor.Yellow;
//Console.WriteLine(" \t\u25CC ");
//Console.ForegroundColor = ConsoleColor.Red;
//Console.WriteLine(" \t\u263B ");

//PORTAL
//Console.ForegroundColor = ConsoleColor.White;
//abertura para a esquerda
//Console.WriteLine(" \t\u03FD ");
//abertura para direita
//Console.WriteLine(" \t\u03F9 ");
//abertura para a esquerda
//Console.WriteLine(" \t\u256C ");
//Console.WriteLine(" \t\u2AA7");
//abertura para direita