using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace OOP_Assessment2
{
    public abstract class Player
    {
        public string Name { get; protected set; }
        public int Points { get; private set; }
        public int PlayerTurns { get; set; }
        public int TotalWins { get; private set; }
        
        public abstract void SetPlayerName(int playerCount);

        public void AddPlayerPoints(int points)
        {
            Points += points;
        }

        public void ResetPlayerPoints()
        {
            Points = 0;
        }

        public void GetPoints()
        {
            if (Points < 1)
            {
                Console.WriteLine($"{Name}'s points: 0");
            }
            else
            {
                Console.WriteLine($"{Name}'s points: {Points}");
            }
        }

        public void AddPlayerWins()
        {
            TotalWins++;
        }
    }
}