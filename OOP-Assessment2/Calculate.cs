using System.Collections.Generic;
using System.Linq;

namespace OOP_Assessment2
{
    public static class Calculate
    {
        public static int PlayerTurnPoints(int maxDieNumFreq)
        {
            int playerPoints = 0;
            switch (maxDieNumFreq)
            {
                case 1:
                    break;
                case 2:
                    // Does not actually get added to player points
                    playerPoints = 1;
                    break;
                case 3:
                    playerPoints += 3;
                    break;
                case 4:
                    playerPoints += 6;
                    break;
                case 5:
                    playerPoints += 12;
                    break;
            }
        
            return playerPoints;
        }

        public static List<Player> GamePoints(List<Player> playerList)
        {
            List<Player> sortedPointList = playerList.OrderByDescending(x => x.Points).ToList();
            return sortedPointList;
        }
        public static List<Player> OverallWins(List<Player> playerList)
        {
            List<Player> sortedWinList = playerList.OrderByDescending(x => x.TotalWins).ToList();
            return sortedWinList;
        }
        
        public static Dictionary<int, int> DiceNumFreqDict(List<int> diceRolls)
        {
            // Add the number the dice landed on with their corresponding frequency to a dictionary
            Dictionary<int, int> diceNumFreq = diceRolls.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            return diceNumFreq;
        }

        public static int MaxDieNumFreq(Dictionary<int, int> diceNumFreq)
        {
            // Get the die number (value) that appeared most frequently
            int maxDieNumFreq = diceNumFreq.Values.Max();

            return maxDieNumFreq;
        }

        public static int MaxDieNumFace(Dictionary<int, int> diceNumFreq)
        {
            // Get the corresponding key of the most frequent value
            int maxDieNumFace = diceNumFreq.OrderByDescending(x => x.Value).First().Key;

            return maxDieNumFace;
        }
        
                
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