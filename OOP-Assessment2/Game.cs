using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace OOP_Assessment2
{
    public class Game
    { 
        private List<Player> PlayerList { get; } = new List<Player>();
        public List<int> DiceRolls { get; } = new List<int>();
        public const int MaxPoints = 7;
        private int MaxValue { get; set; }
        public static Player Winner { get; private set; }
        private Die Die { get; }
        private bool RollAgain { get; set; }

        public Game()
        {
            Die = new Die();
        }

        private void ResetDice()
        {
            DiceRolls.Clear();
        }

        private void ResetGame()
        {
            //DiceNumFreq.Clear();
            DiceRolls.Clear();
            RollAgain = false;

            foreach (Player player in PlayerList )
            {
                player.ResetPlayerPoints();
            }
        }

        private void ResetPlayers()
        {
            PlayerList.Clear();
        }

        // static polymorphism examples....
        private void MakePlayerList(int humanPlayers)
        {
            int humanPlayerCount = 1;
            for (int i = 0; i < humanPlayers; i++)
            {
                Player human = new HumanPlayer();
                human.SetPlayerName(humanPlayerCount);
                PlayerList.Add(human);
                humanPlayerCount++;
            }
        }
        
        private void MakePlayerList(int humanPlayers, int computerPlayers)
        {
            int humanPlayerCount = 1;
            for (int i = 0; i < humanPlayers; i++)
            {
                Player human = new HumanPlayer();
                human.SetPlayerName(humanPlayerCount);
                PlayerList.Add(human);
                humanPlayerCount++;
            }

            int computerPlayerCount = 1;
            for (int i = 1; i <= computerPlayers; i++)
            {
                Player computer = new ComputerPlayer();
                computer.SetPlayerName(computerPlayerCount);
                PlayerList.Add(computer);
                computerPlayerCount++;
            }
        }
        
        private int CalculatePlayerTurnPoints(int playerTurns)
        {
            Dictionary<int, int> DiceNumFreq;
            // Add the number the dice landed on with their corresponding frequency to a dictionary
            DiceNumFreq = DiceRolls.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            
            // Get the die number (value) that appeared most frequently
            MaxValue = DiceNumFreq.Values.Max();
            
            // Get the corresponding key of the most frequent value
            int maxValueKey = DiceNumFreq.OrderByDescending(x => x.Value).First().Key;
        
            int playerPoints = 0;
            switch (MaxValue)
            {
                case 1:
                    break;
                case 2:
                    if (playerTurns < 2)
                    {
                        RollAgain = true;
                    }
        
                    // Remove all dice except the 2-of-a-kind pair
                    DiceRolls.RemoveAll(x => x != maxValueKey);
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

        private List<Player> CalculateGamePoints(List<Player> playerList)
        {
            List<Player> sortedPointList = playerList.OrderByDescending(x => x.Points).ToList();
            return sortedPointList;
        }

        private List<Player> CalculateOverallWins(List<Player> playerList)
        {
            List<Player> sortedWinList = playerList.OrderByDescending(x => x.TotalWins).ToList();
            return sortedWinList;
        }
        

        private void CreateDiceRolls(bool isSecondRoll)
        {
            if (!isSecondRoll)
            {
                for (int i = 0; i < 5; i++)
                {
                    DiceRolls.Add(Die.Roll());
                }
            }
      
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    DiceRolls.Add(Die.Roll());
                }
            }
        }

        private void RunPlayerTurn(List<Player> playerList)
        {
            bool maxReached = false;
            do
            {
                foreach (Player player in playerList)
                {
                    Output.DisplayPlayerTurn(player);
                    CreateDiceRolls(isSecondRoll: false);
                    Output.DisplayPlayerRoll(isSecondRoll: false, player: player, DiceRolls);
                    Output.DisplayDieFaces(DiceRolls, Die);

                    player.PlayerTurns += 1;

                    int points = CalculatePlayerTurnPoints(player.PlayerTurns);
                    Output.DisplayScore(player.PlayerTurns, MaxValue);

                    if (RollAgain)
                    {
                        player.PlayerTurns += 1;
                        CreateDiceRolls(isSecondRoll: true);
                        Output.DisplayPlayerRoll(isSecondRoll: true, player: player, DiceRolls);
                        Output.DisplayDieFaces(DiceRolls, Die);
                        points = CalculatePlayerTurnPoints(player.PlayerTurns);
                        Output.DisplayScore(player.PlayerTurns, MaxValue);
                    }

                    player.AddPlayerPoints(points);
                    player.PlayerTurns = 0;
                    RollAgain = false;

                    player.GetPoints();

                    if (player.Points >= MaxPoints)
                    {
                        Winner = player;
                        player.AddPlayerWins();
                        maxReached = true;
                        break;
                    }
                    
                    ResetDice();
                    Output.NextPlayerLineBreak();
                }
            } while (!maxReached);
        }

        public void RunGame()
        {
            Output.WelcomeMessage();
            
            do
            {
                int numOfHumans = Input.GetHumanPlayerNum();
                int numOfAi = Input.GetCompPlayerNum();

                if (numOfAi != 0)
                {
                    MakePlayerList(humanPlayers: numOfHumans, computerPlayers: numOfAi);
                }

                else
                {
                    MakePlayerList(humanPlayers: numOfHumans);
                }

                Console.Clear();

                bool nextGame;
                do
                {
                    RunPlayerTurn(PlayerList);

                    Output.NextPlayerLineBreak();
                    Output.DisplayWinner(Winner);

                    Output.DisplayGameLeaderboard(CalculateGamePoints(PlayerList));
                    Output.DisplayOverallWins(CalculateOverallWins(PlayerList));

                    string option = Input.PlayAgain();

                    if (option == "1")
                    {
                        ResetGame();
                        Console.Clear();
                        nextGame = false;
                    }
                    else if  (option == "2")
                    {
                        ResetGame();
                        ResetPlayers();
                        Console.Clear();
                        nextGame = true;
                    }
                    else
                    {
                        Output.DisplayGoodbye();
                        return;
                    }
                } while (!nextGame);
            } while (true);
        }
    }
}