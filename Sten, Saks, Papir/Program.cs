using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sten__Saks__Papir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                StartController();

                if(GetPressedKey() == ConsoleKey.Enter)
                {
                    WriteRestartProgram();
                }
                else
                {
                    break;
                }
            } while (true);
        }

        #region Model
        /// <summary>
        /// Gets which element the user has chosen to fight with
        /// </summary>
        /// <returns>The element which the user has chosen</returns>
        private static string GetChosenElement()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Gets the pressed key
        /// </summary>
        /// <returns>Returns the key which the user pressed</returns>
        private static ConsoleKey GetPressedKey()
        {
            return Console.ReadKey(true).Key;
        }

        /// <summary>
        /// Gets a random element to fight with
        /// </summary>
        /// <returns>The element which the computer has chosen</returns>
        private static string GetComputerChosenElement()
        {
            string[] elementArr = { "Rock", "Paper", "Scissors" };
            Random rand = new Random();
            return elementArr[rand.Next(1, 4) - 1];
        }
        #endregion

        #region View
        /// <summary>
        /// Writes a little summary of the game, its rules and an instruction
        /// </summary>
        private static void WriteGUIText()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Rock, Paper, Scissors\n");
            Console.WriteLine("You are playing against the computer, where you and the computer are");
            Console.WriteLine("choosing between 3 elements to win. When you and the computer has");
            Console.WriteLine("chosen an element then the game will begin.\n");
            Console.WriteLine("Game rules:");
            Console.WriteLine("- Rock wins over scissors, since the scissors can't cut the rock");
            Console.WriteLine("- Paper wins over stone, since the paper can wrap the stone");
            Console.WriteLine("- Scissor wins over paper, since it can cut the paper\n");
            Console.WriteLine("Choose a element: (Rock, Paper or Scissors)");
        }

        /// <summary>
        /// Writes a strip of elements with a delay of 1 second
        /// </summary>
        private static void WriteStripOfElements()
        {
            Console.Clear();
            Console.WriteLine("Rock");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Paper");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Scissors");
            System.Threading.Thread.Sleep(1000);
        }
        /// <summary>
        /// Writes what the user has chosen and what the computer has chosen
        /// </summary>
        /// <param name="userElement">element which the user has chosen</param>
        /// <param name="computerElement">element which the computer has chosen</param>
        private static void WriteHands(string userElement, string computerElement)
        {
            Console.Clear();
            Console.WriteLine("Your hand: " + userElement);
            Console.WriteLine("Computers hand: " + computerElement);
            Console.WriteLine("\nFor trying again press enter, or any other key to exit");
        }

        /// <summary>
        /// Writes a message when the program is about to restart
        /// </summary>
        private static void WriteRestartProgram()
        {
            Console.WriteLine("The program will start over soon, please wait 15 seconds");
            System.Threading.Thread.Sleep(15000);
        }
        #endregion

        #region Controller
        /// <summary>
        ///  Starts the game/program, the first controller
        /// </summary>
        private static void StartController()
        {
            string userElement = "";

            // Loops until the user has chosen a element and not a random string
            do
            {
                WriteGUIText();
                userElement = GetChosenElement();
            } while (!IsAElement(userElement));

            // All 3 elements will be written, with a delay of 1000.
            // Just like this "Rock", "Paper", "Scissors"
            WriteStripOfElements();

            string computerElement = GetComputerChosenElement();

            // Writes out which element the user and computer has chosen
            WriteHands(userElement, computerElement);
        }

        /// <summary>
        /// Checks whether the given string is a element or not
        /// </summary>
        /// <param name="userElement">input from user, which is checked</param>
        /// <returns>A boolean. If the string is a element then true will be returned, if not then false will be returned</returns>
        private static bool IsAElement(string userElement)
        {
            if(userElement == "Rock" || userElement == "Paper" || userElement == "Scissors")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
