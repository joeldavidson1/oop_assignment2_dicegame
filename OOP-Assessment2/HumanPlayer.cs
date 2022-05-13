using System;
using System.Linq;

namespace OOP_Assessment2
{
    public class HumanPlayer : Player
    {
        public override void SetPlayerName(int humanCount)
        {
            do
            {
                try
                {
                    Console.WriteLine($"Please enter player human {humanCount} name:");
                    string name = Console.ReadLine();

                    if (!name.All(Char.IsLetter) || string.IsNullOrWhiteSpace(name))
                    {
                        throw new InvalidInputException("Name must contain letters only.");
                    }

                    if (name.Length < 2)
                    {
                        throw new InvalidInputException("Name must contain more than 1 letter.");
                    }

                    name = name.ToLower();
                    Console.WriteLine();
                    Name = char.ToUpper(name[0]) + name.Substring(1);
                    break;

                }
                catch (InvalidInputException e)
                {
                    Console.WriteLine($"\n{e.Message}");
                }
            } while (true);
        }
    }
}