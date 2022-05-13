using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Schema;

namespace OOP_Assessment2
{
    public static class Output
    {
        public static void WelcomeMessage()
        {
            string welcome = @"
           ___       __   ___  ___     __   __            __   __   ___ 
            |  |__| |__) |__  |__     /  \ |__)     |\/| /  \ |__) |__  
            |  |  | |  \ |___ |___    \__/ |  \     |  | \__/ |  \ |___ ";
            
            Console.WriteLine(welcome);
            Console.WriteLine("\nPlease see 'Three or More' rules online on how to play.");
            Console.WriteLine("For this game you can either play by yourself, with other people, with AI, or with both!");
            Console.WriteLine($"The first player to {Game.MaxPoints} points wins the game. Good luck.\n");
            Console.WriteLine("Press any key to begin playing...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void DisplayDieFaces(List<int> diceRollList, Die die)
        {
            List<string[]> dieFaces = new List<string[]>();

            foreach (int dice in diceRollList)
            {
                dieFaces.Add(die.Face(dice));
            }
            
            Thread.Sleep(1000);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{dieFaces[0][i]}  {dieFaces[1][i]}  {dieFaces[2][i]}  {dieFaces[3][i]}  " +
                                  $"{dieFaces[4][i]}");
            }

        }
        public static void NextPlayerLineBreak()
        {
            Console.WriteLine("\nPress any key to continue to the next player.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void DisplayWinner(Player winner)
        {
            Console.WriteLine($"\nCongratulations, {winner.Name} has won with {winner.Points} points!");
        }
        
        public static void DisplayGameLeaderboard(List<Player> sortedPlayerList)
        {
            Console.WriteLine("\n—————————————————— GAME LEADERBOARD ——————————————————");
            foreach (Player player in sortedPlayerList)
            {
                Console.WriteLine($"[{player.Name}] points: {player.Points}");
            }
        }
        
        public static void DisplayOverallWins(List<Player> sortedPlayerList)
        {
            Console.WriteLine("\n——————————————— OVERALL WIN LEADERBOARD ———————————————");
            foreach (Player player in sortedPlayerList)
            {
                Console.WriteLine($"[{player.Name}] wins: {player.TotalWins}");
            }
        }

        public static void DisplayPlayerTurn(Player player)
        {
            Console.WriteLine($"———————————— {player.Name}'s turn ————————————");
        }
        
        public static void DisplayPlayerRoll(bool isSecondRoll, Player player, List<int> diceRolls)
        {
            if (!isSecondRoll && player is HumanPlayer)
            {
                Console.Write("\nPress any key to roll the dice...");
                Console.ReadKey();
                Console.WriteLine("\nRolling dice... ");
            }
            
            else if (!isSecondRoll)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Rolling dice... ");
            }

            else if (player is HumanPlayer)
            {

                Console.Write("\nPress any key to roll the dice...");
                Console.ReadKey();
                Console.WriteLine("\nRolling 2nd dice roll... ");
            }
            
            else
            { 
                Thread.Sleep(1000);
                Console.WriteLine("\nRolling 2nd dice roll... ");
            }
        }
        
        public static void DisplayScore(int playerTurns, int maxValue)
        {
            Console.WriteLine();
            switch (maxValue)
            {
                case 1:
                    Console.WriteLine("No matches found.");
                    break;
                case 2:
                    if (playerTurns < 2)
                    {
                        Console.WriteLine("2 of-a-kind. Re-rolling...");
                    }
                    else
                    {
                        Console.WriteLine("Nothing above 2 of-a-kind found on 2nd roll, unlucky.");
                    }
                    break;
                case 3:
                    Console.WriteLine("3-of-a-kind, +3 points!");
                    break;
                case 4:
                    Console.WriteLine("4 of-a-kind, +6 points!");
                    break;
                case 5:
                    Console.WriteLine("5-of-a-kind, +12 points!");
                    break;
            }
        }

        public static void DisplayGoodbye()
        {
            Console.WriteLine("\nThank you for playing. Goodbye.");
        }
    }
}