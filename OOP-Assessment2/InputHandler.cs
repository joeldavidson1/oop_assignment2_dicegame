using System;
using System.Data;
using System.Linq;

namespace OOP_Assessment2
{
    public static class InputHandler
    {
        public static int GetHumanPlayerNum()
        {
            int humanPlayers;
            do
            {
                try
                {
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
                
                catch (InvalidInputException e)
                {
                    Console.WriteLine($"\n{e.Message}");
                }
            } while (true);

            Console.Clear();
            return humanPlayers;
        }

        public static int GetCompPlayerNum()
        {
            int compPlayers;
            do
            {
                try
                {
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
                catch (InvalidInputException e)
                {
                    Console.WriteLine($"\n{e.Message}");
                }
            } while (true);
            
            Console.Clear();
            return compPlayers;
        }
        
        public static string PlayAgain()
        {
            do
            {
                try
                {
                    Console.WriteLine("\nPlease pick one of the following options: \n1) Play again with the same players" +
                                      "\n2) Play again with different players \n3) Quit");
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
                    
                    throw new InvalidInputException("Please enter either '1', '2' or '3'.");
                }
                catch (InvalidInputException e)
                {
                    Console.WriteLine($"\n{e.Message}");
                }
            } while (true);
        }
    }
}