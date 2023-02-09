using System.Collections.Generic;
using System.Linq;

namespace OOP_Assessment2
{
    /// <summary>
    /// Performs all the calculations required for the game to work correctly.
    /// </summary>
    public static class Calculate
    {
        /// <summary>
        /// Calculates how many points the player should receive depending on the number of dice matches.
        /// </summary>
        /// <param name="maxDieNumFreq">The amount of matching dice from the rolls.</param>
        /// <returns>Integer (player's points)</returns>
        public static int PlayerTurnPoints(int maxDieNumFreq)
        {
            int playerPoints = 0;
            switch (maxDieNumFreq)
            {
                // No matches
                case 1:
                    break;
                
                // 2 of-a-kind
                case 2:
                    break;
                
                // 3 of-a-kind
                case 3:
                    playerPoints += 3;
                    break;
                
                // 4 of-a-kind
                case 4:
                    playerPoints += 6;
                    break;
                
                // 5 of-a-kind
                case 5:
                    playerPoints += 12;
                    break;
            }
        
            return playerPoints;
        }
        
        /// <summary>
        /// Sorts a Player list into descending order using the number of points of the players.
        /// </summary>
        /// <param name="playerList">A list of players.</param>
        /// <returns>A sorted Player list by points.</returns>
        public static List<Player> GamePoints(List<Player> playerList)
        {
            // Uses LINQ to organise the list by total points of players
            List<Player> sortedPointList = playerList.OrderByDescending(x => x.Points).ToList();
            
            return sortedPointList;
        }
        
        /// <summary>
        /// Sorts a Player list into descending order using the number of wins of the players.
        /// </summary>
        /// <param name="playerList">A list of players.</param>
        /// <returns>A sorted Player list by wins.</returns>
        public static List<Player> OverallWins(List<Player> playerList)
        {
            // Uses LINQ to organise the list by total wins of the players
            List<Player> sortedWinList = playerList.OrderByDescending(x => x.TotalWins).ToList();
            
            return sortedWinList;
        }
        
        /// <summary>
        /// Calculates the dice number (face) to the number of times it appears in the 5 rolls and creates a
        /// dictionary.
        /// </summary>
        /// <param name="diceRolls">An integer list of 5 dice rolls.</param>
        /// <returns>An int, int dictionary of dice numbers and their frequency.</returns>
        public static Dictionary<int, int> DiceNumFreqDict(List<int> diceRolls)
        {
            // Add the number the dice landed on with their corresponding frequency to a dictionary
            Dictionary<int, int> diceNumFreq = diceRolls.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            return diceNumFreq;
        }

        /// <summary>
        /// Calculates the highest amount of die rolls that were the same..
        /// </summary>
        /// <param name="diceNumFreq">A dictionary of dice numbers and their frequency.</param>
        /// <returns>An integer - the highest amount of the same rolls.</returns>
        public static int MaxDieNumFreq(Dictionary<int, int> diceNumFreq)
        {
            // Get the die number (face) that appeared most frequently
            int maxDieNumFreq = diceNumFreq.Values.Max();

            return maxDieNumFreq;
        }

        /// <summary>
        /// Calculates the die number (face) that appeared most frequently.
        /// </summary>
        /// <param name="diceNumFreq">A dictionary of dice numbers and their frequency.</param>
        /// <returns>An integer - the most frequent die number.</returns>
        public static int MaxDieNumFace(Dictionary<int, int> diceNumFreq)
        {
            // Get the corresponding die number of the most frequently appeared dice
            int maxDieNumFace = diceNumFreq.OrderByDescending(x => x.Value).First().Key;

            return maxDieNumFace;
        }
        
        /// <summary>
        /// Calculates whether the game has been won by comparing the player points with the max Game points.
        /// </summary>
        /// <param name="player">Player object</param>
        /// <returns>Boolean</returns>
        public static bool HasPlayerWon(Player player)
        {
            if (player.Points >= Game.MaxPoints)
            {
                return true;
            }

            return false;
        }
    }
}