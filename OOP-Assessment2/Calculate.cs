using System.Collections.Generic;
using System.Linq;

namespace OOP_Assessment2
{
    public static class Calculate
    {
        // public static int CalculatePlayerTurnPoints(int playerTurns)
        // {
        //     Dictionary<int, int> DiceNumFreq;
        //     // Add the number the dice landed on with their corresponding frequency to a dictionary
        //     DiceNumFreq = Game.DiceRolls.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        //     
        //     // Get the die number (value) that appeared most frequently
        //     MaxValue = DiceNumFreq.Values.Max();
        //     
        //     // Get the corresponding key of the most frequent value
        //     int maxValueKey = DiceNumFreq.OrderByDescending(x => x.Value).First().Key;
        //
        //     int playerPoints = 0;
        //     switch (MaxValue)
        //     {
        //         case 1:
        //             break;
        //         case 2:
        //             if (playerTurns < 2)
        //             {
        //                 RollAgain = true;
        //             }
        //
        //             // Remove all dice except the 2-of-a-kind pair
        //             DiceRolls.RemoveAll(x => x != maxValueKey);
        //             break;
        //         case 3:
        //             playerPoints += 3;
        //             break;
        //         case 4:
        //             playerPoints += 6;
        //             break;
        //         case 5:
        //             playerPoints += 12;
        //             break;
        //     }
        //
        //     return playerPoints;
        // }
        //

        public static List<Player> CalculateGamePoints(List<Player> playerList)
        {
            List<Player> sortedPointList = playerList.OrderByDescending(x => x.Points).ToList();
            return sortedPointList;
        }

        public static List<Player> CalculateOverallWins(List<Player> playerList)
        {
            List<Player> sortedWinList = playerList.OrderByDescending(x => x.TotalWins).ToList();
            return sortedWinList;
        }
    }
}