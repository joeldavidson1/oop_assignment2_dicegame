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
    /// <summary>
    /// A class which handles the output to the console.
    /// </summary>
    public static class OutputConsole
    {
        /// <summary>
        /// Writes to console a welcome message.
        /// </summary>
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

        /// <summary>
        /// Writes to console the ascii art die faces of the 5 dice rolls.
        /// </summary>
        /// <param name="diceRollList">List of integers of the 5 dice rolls</param>
        /// <param name="die">Die object</param>
        public static void DisplayDieFaces(List<int> diceRollList, Die die)
        {
            // Create an empty string[]
            List<string[]> dieFaces = new List<string[]>();

            // Iterate through the list of dice rolls and add the corresponding string[] Face to the string[] of
            // dieFaces
            foreach (int diceNum in diceRollList)
            {
                dieFaces.Add(die.Face(diceNum));
            }
            
            // Wait for 1 second then display to console the string[] of each dice number with it's corresponding 
            // ascii art
            Thread.Sleep(1000);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{dieFaces[0][i]}  {dieFaces[1][i]}  {dieFaces[2][i]}  {dieFaces[3][i]}  " +
                                  $"{dieFaces[4][i]}");
            }
        }

        /// <summary>
        /// Writes to console the current number of the player's points.
        /// </summary>
        /// <param name="player">Player object</param>
        /// <param name="points">The current of points the player has.</param>
        public static void DisplayPlayerPoints(Player player, int points)
        {
            // Writes to console 0 points to the player's name  if player has less than 1 point
            if (points < 1)
            {
                Console.WriteLine($"{player.Name}'s points: 0");
            }
            // Otherwise writes the player's name and their corresponding current points
            else
            {
                Console.WriteLine($"{player.Name}'s points: {points}");
            }
        }
        
        /// <summary>
        /// Writes to console to continue to the next player.
        /// </summary>
        public static void NextPlayerLineBreak()
        {
            Console.WriteLine("\nPress any key to continue to the next player.");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Writes to console the current game winner.
        /// </summary>
        /// <param name="winner">A player object (the winner).</param>
        public static void DisplayWinner(Player winner)
        {
            Console.WriteLine($"\nCongratulations, {winner.Name} has won with {winner.Points} points!");
        }
        
        /// <summary>
        /// Writes to console the list of player's with their corresponding game points.
        /// </summary>
        /// <param name="sortedPlayerList">A sorted list of Players by points.</param>
        public static void DisplayGameLeaderboard(List<Player> sortedPlayerList)
        {
            Console.WriteLine("\n—————————————————— GAME LEADERBOARD ——————————————————");
            foreach (Player player in sortedPlayerList)
            {
                Console.WriteLine($"[{player.Name}] points: {player.Points}");
            }
        }
        
        /// <summary>
        /// Writes to console the list of player's with their corresponding game wins.
        /// </summary>
        /// <param name="sortedPlayerList">A sorted list of Players by wins.</param>
        public static void DisplayOverallWins(List<Player> sortedPlayerList)
        {
            Console.WriteLine("\n——————————————— SESSION WINS LEADERBOARD ———————————————");
            foreach (Player player in sortedPlayerList)
            {
                Console.WriteLine($"[{player.Name}] wins: {player.TotalWins}");
            }
        }

        /// <summary>
        /// Writes to console the current player's turn.
        /// </summary>
        /// <param name="player">Player object (current player).</param>
        public static void DisplayPlayerTurn(Player player)
        {
            Console.WriteLine($"———————————— {player.Name}'s turn ————————————");
        }
        
        /// <summary>
        /// Writes to console indicating whether it's the first or second dice roll for the player.
        /// </summary>
        /// <param name="isSecondRoll">Boolean - whether it's the second dice roll or not.</param>
        /// <param name="player">Player object (current player).</param>
        public static void DisplayPlayerRoll(bool isSecondRoll, Player player)
        {
            // Not the second roll and it's the human player
            if (!isSecondRoll && player is HumanPlayer)
            {
                Console.Write("\nPress any key to roll the dice...");
                Console.ReadKey();
                Console.WriteLine("\nRolling dice... ");
            }
            
            // Not the second roll and it's the computer player
            else if (!isSecondRoll)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Rolling dice... ");
            }

            // Second roll and the human player
            else if (player is HumanPlayer)
            {

                Console.Write("\nPress any key to roll the dice...");
                Console.ReadKey();
                Console.WriteLine("\nRolling 2nd dice roll... ");
            }
            
            // Second roll and the computer player
            else
            { 
                Thread.Sleep(1000);
                Console.WriteLine("\nRolling 2nd dice roll... ");
            }
        }
        
        /// <summary>
        /// Writes to console the current player turns points.
        /// </summary>
        /// <param name="playerTurns">Number of turns the player has.</param>
        /// <param name="maxValue">The number of dice which are the same in the dice rolls.</param>
        public static void DisplayScore(int playerTurns, int maxValue)
        {
            Console.WriteLine();
            switch (maxValue)
            {
                // No matches
                case 1:
                    Console.WriteLine("No matches found.");
                    break;
                
                // 2 of-a-kind
                case 2:
                    
                    // 1st player turn
                    if (playerTurns < 2)
                    {
                        Console.WriteLine("2 of-a-kind. Re-rolling...");
                    }
                    
                    // 2nd player turn
                    else
                    {
                        Console.WriteLine("Nothing above 2 of-a-kind found on 2nd roll, unlucky.");
                    }
                    break;
                
                // 3 of-a-kind
                case 3:
                    Console.WriteLine("3-of-a-kind, +3 points!");
                    break;
                
                // 4 of-a-kind
                case 4:
                    Console.WriteLine("4 of-a-kind, +6 points!");
                    break;
                
                // 5 of-a-kind
                case 5:
                    Console.WriteLine("5-of-a-kind, +12 points!");
                    break;
            }
        }

        /// <summary>
        /// Writes to console a goodbye message.
        /// </summary>
        public static void DisplayGoodbye()
        {
            Console.WriteLine("\nThank you for playing. Goodbye.");
        }

        /// <summary>
        /// Writes to console the options the player must pick to continue the game.
        /// </summary>
        public static void DisplayPlayAgain()
        {
            Console.WriteLine("\nPlease pick one of the following options: \n1) Play again with the same players" +
                              "\n2) Play again with different players \n3) Quit");
        }

        /// <summary>
        /// Writes to console the message of the InvalidInputException.
        /// </summary>
        /// <param name="invalid">InvalidInputException</param>
        public static void DisplayInvalidInputMessage(InvalidInputException invalid)
        {
            Console.WriteLine($"\n {invalid.Message}");
        }
    }
}