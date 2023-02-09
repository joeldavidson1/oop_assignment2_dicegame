using System;
using System.Data;
using System.Linq;

namespace OOP_Assessment2
{
    /// <summary>
    /// A class which handles all of the user input in the console.
    /// </summary>
    public static class InputHandler
    {
        /// <summary>
        /// Gets the amount human players which will be playing the game.
        /// </summary>
        /// <returns>An integer - amount of human players.</returns>
        /// <exception cref="InvalidInputException">Checks whether the input is valid.</exception>
        public static int GetHumanPlayerNum()
        {
            int humanPlayers;
            do
            {
                try
                {
                    // Tries parsing the user input which checks whether they entered an integer or not
                    // Throws exceptions when user entered something other than an integer or the integer <= 0.
                    Console.WriteLine("How many human players are playing?");
                    if (Int32.TryParse(Console.ReadLine(), out humanPlayers) is false)
                    {
                        throw new InvalidInputException("Please enter an integer only.");
                    }

                    if (humanPlayers <= 0)
                    {
                        throw new InvalidInputException("At least 1 human player must play.");
                    }

                    break;
                }
                
                // Writes the message to the console to show the user.
                catch (InvalidInputException e)
                {
                    OutputConsole.DisplayInvalidInputMessage(e);
                }
            } while (true);

            Console.Clear();
            return humanPlayers;
        }

        /// <summary>
        /// Gets the amount computer players which will be playing the game.
        /// </summary>
        /// <returns>An integer - amount of computer players.</returns>
        /// <exception cref="InvalidInputException">Checks whether the input is valid.</exception>
        public static int GetCompPlayerNum()
        {
            int compPlayers;
            do
            {
                try
                {
                    // Tries parsing the user input which checks whether they entered an integer or not.
                    // Throws exceptions when user entered something other than an integer or the integer < 0.
                    Console.WriteLine("How many AI players are playing?");
                    if (Int32.TryParse(Console.ReadLine(), out compPlayers) is false)
                    {
                        throw new InvalidInputException("Please enter an integer only.");
                    }

                    if (compPlayers < 0)
                    {
                        throw new InvalidInputException("Please enter either 0, or a positive integer.");
                    }

                    break;
                }
                
                // Writes the message to the console to show the user.
                catch (InvalidInputException e)
                {
                    OutputConsole.DisplayInvalidInputMessage(e);
                }
            } while (true);
            
            Console.Clear();
            return compPlayers;
        }
        
        /// <summary>
        /// Asks whether user would like to play again or quit.
        /// </summary>
        /// <returns>A string - 1 of the 3 available options</returns>
        /// <exception cref="InvalidInputException"></exception>
        public static string PlayAgain()
        {
            do
            {
                try
                {

                    OutputConsole.DisplayPlayAgain();
                    
                    // Removes whitespace from the string and converts it to lowercase
                    string playAgain = Console.ReadLine()?.Trim().ToLower();

                    if (playAgain == "1")
                    {
                        return "1";
                    }

                    if (playAgain == "2")
                    {
                        return "2";
                    }
                    
                    if (playAgain == "3")
                    {
                        return "3";
                    }
                    
                    // Throws exception when something is entered other than 1, 2 or 3.
                    throw new InvalidInputException("Please enter either '1', '2' or '3'.");
                }
                
                // Writes the message to the console.
                catch (InvalidInputException e)
                {
                    OutputConsole.DisplayInvalidInputMessage(e);
                }
            } while (true);
        }
        
        public static string GetPlayerName(int playerCount, bool isHuman)
        {
            if (isHuman)
            {
                string name;
                do
                {
                    try
                    {
                        Console.WriteLine($"Please enter player human {playerCount} name:");
                        name = Console.ReadLine();

                        if (!name.All(Char.IsLetter) || string.IsNullOrWhiteSpace(name))
                        {
                            throw new InvalidInputException("Name must contain letters only.");
                        }

                        if (name.Length < 2)
                        {
                            throw new InvalidInputException("Name must contain more than 1 letter.");
                        }
                        break;

                    }
                    catch (InvalidInputException e)
                    {
                        OutputConsole.DisplayInvalidInputMessage(e);
                    }
                } while (true);

                return name;
            }

            else
            {
                return $"Computer Player {playerCount}";
            }
        }
    }
}