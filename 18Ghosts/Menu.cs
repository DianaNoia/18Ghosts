using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    /// <summary>
    ///  Class to show Menu 
    /// </summary>
    class Menu
    {
        /// <summary>
        /// Introduction of the game
        /// </summary>
        public void Intro()
        {
            /** \brief  Clear the console */
            Console.Clear();
            /** \brief  Put a empty line */
            Console.WriteLine();
            /** \brief  Writes in the console */
            Console.WriteLine("\t\t     18 Ghosts ");
            Console.WriteLine();
            Console.WriteLine("\t\t   Press any key ");

            /** \brief  It will stop the program until the user press any key */
            Console.ReadKey();
            /** \brief  Call method MainMenu() */
            MainMenu();

        }

        /// <summary>
        ///  Show the Menu
        /// </summary>
        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t     18 Ghosts ");
            Console.WriteLine();
            Console.WriteLine("\t\t 1 ->  Game     <- ");
            Console.WriteLine("\t\t 2 ->  Rules    <- ");
            Console.WriteLine("\t\t 3 ->  Credits  <- ");
            Console.WriteLine("\t\t 4 ->  Quit     <- ");

            //brief Switch cicle to choose what to do 
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Game();
                    break;
                case 2:
                    Rules();
                    break;

                case 3:
                    Credits();
                    break;

                case 4:
                    Quit();
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine(" !!!!!!!!!!!!   ERROR   !!!!!!!!!!!! ");
                    break;
            }
            Console.ReadLine();
        }

        /// <summary>
        ///  Constructor to initiate the game
        /// </summary>
        private void Game()
        {
            /** \brief Instances of game */
            Game game = new Game();
            game.GameLoop();
        }

        /// <summary>
        /// Method for rule porposes
        /// </summary>
        private void Rules()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\tRules ");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  It's a strategy game for 2 players ");
            Console.WriteLine(" The board has 25 houses (5x5) and 1 dungeon on the rigth.  ");
            Console.WriteLine(" Each 3 portals in each color (1 red(north), 1 blue(south), ");
            Console.WriteLine(" 1 yellow(east))");
            Console.WriteLine();
            Console.WriteLine("  Each player has 9 ghosts of a specific type in ");
            Console.WriteLine(" 3 colors (3 red, 3 blue, 3 yellow).");
            Console.WriteLine(" The first player to put out 3 ghosts in each colors wins! ");
            Console.WriteLine();
            Console.WriteLine("\t   ->> The ghosts must escape the castle! <<- ");
            Console.WriteLine();
            Console.WriteLine("  The game is played in turns. ");
            Console.WriteLine(" Each turn a player will take one ghost and place it on a house ");
            Console.WriteLine(" with the same color carpet, until there are no ghosts left. ");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t I ");
            Console.WriteLine();
            Console.WriteLine("  You move 1 house only orthogonally, in mirrors houses you ");
            Console.WriteLine(" will go automatically in diogonal to the other mirror's house");
            Console.WriteLine(" You can move to a mirror house or other color carpet house.");
            Console.WriteLine();
            Console.WriteLine("\t\t\t         II ");
            Console.WriteLine();
            Console.WriteLine("  Ghosts can attack each other, and the loser goes to the dungeon.");
            Console.WriteLine(" -> Red ghosts beat blue ghosts");
            Console.WriteLine(" -> Blue ghosts beat yellow ghosts");
            Console.WriteLine(" -> Yellow ghosts beat red ghosts");
            Console.WriteLine(" You're able to defeat your own ghosts too. ");
            Console.WriteLine();
            Console.WriteLine("\t      »»» If made properly you CAN win. ««« ");
            Console.WriteLine();
            Console.WriteLine("\t\t\t        III ");
            Console.WriteLine();
            Console.WriteLine("  You may also release your ghosts, to do that, you need a free ");
            Console.WriteLine(" carpet house of the same color and you will give it to your ");
            Console.WriteLine(" opponente. He'l put it in the game where he pleases.");
            Console.WriteLine();
            Console.WriteLine("  The only way for the ghosts to get out, is through the portal ");
            Console.WriteLine(" of the same color and it must be open.");
            Console.WriteLine(" A portal will rotate 90º each time a ghost of the same color ");
            Console.WriteLine(" is sent to the dungeon.");
            Console.WriteLine(" The square is the portal's door to escape, ");
            Console.WriteLine(" and it's done automatically ");
            Console.WriteLine();
            Console.WriteLine(" !The 1º player to have 1 ghost of each color out is the winnner!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tPress any key to return to the Menu ");
            Console.SetWindowPosition(0, 0);
            Console.ReadLine();
            MainMenu();
        }

        /// <summary>
        /// Method to show who made the game
        /// </summary>
        private void Credits()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t\tCredits  ");
            Console.WriteLine();
            Console.WriteLine("\t\t\u2666 Diana Nóia nº 21703004 ");
            Console.WriteLine("\t\t\u2666 Sara Gama  nº 21705494 ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t Press any key to return to the Menu ");

            Console.ReadLine();
            MainMenu();
        }

        /// <summary>
        /// Method to quit the game
        /// </summary>
        private void Quit()
        {
            Environment.Exit(0);
        }
    }
}

