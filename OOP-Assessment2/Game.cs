using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Threading;

namespace OOP_Assessment2
{
    public class Game
    {
        public const int MaxPoints = 50;
        private Player Winner { get; set; }
        private Die Die { get; }
        private ListHandler ListHandler { get; set; }
        public Game()
        {
            Die = new Die();
            ListHandler = new ListHandler();
        }
        
        private void ResetPoints(List<Player> playerList)
        {
            foreach (Player player in playerList )
            {
                player.ResetPlayerPoints();
            }
        }

        private void RunPlayerTurn(List<Player> playerList)
        {
            bool maxReached = false;
            do
            {
                foreach (Player player in playerList)
                {
                    OutputConsole.DisplayPlayerTurn(player);
                    List<int> diceRolls = ListHandler.CreateDiceRolls(isSecondRoll: false, new List<int>());
                    OutputConsole.DisplayPlayerRoll(isSecondRoll: false, player: player);
                    OutputConsole.DisplayDieFaces(diceRolls, Die);

                    player.PlayerTurns += 1;

                    Dictionary<int, int> diceNumFreq = Calculate.DiceNumFreqDict(diceRolls);
                    int maxDieNumFreq = Calculate.MaxDieNumFreq(diceNumFreq);
                    int maxDieNumFace = Calculate.MaxDieNumFace(diceNumFreq);
                    
                    int points = Calculate.PlayerTurnPoints(maxDieNumFreq);
                    
                    OutputConsole.DisplayScore(player.PlayerTurns, maxDieNumFreq);

                    if (points is 1)
                    {
                        player.PlayerTurns += 1;
                        
                        diceRolls = ListHandler.RemoveNonDuplicateRolls(diceRolls, maxDieNumFace);
                        List<int> diceRolls2 = ListHandler.CreateDiceRolls(isSecondRoll: true, diceRolls);
                        
                        diceNumFreq = Calculate.DiceNumFreqDict(diceRolls2);
                        maxDieNumFreq = Calculate.MaxDieNumFreq(diceNumFreq);
                        
                        OutputConsole.DisplayPlayerRoll(isSecondRoll: true, player: player);
                        OutputConsole.DisplayDieFaces(diceRolls2, Die);

                        points = Calculate.PlayerTurnPoints(maxDieNumFreq);
                        OutputConsole.DisplayScore(player.PlayerTurns, maxDieNumFreq);
                    }

                    if (points > 1)
                    {
                        player.AddPlayerPoints(points);
                    }
                    else
                    {
                        player.AddPlayerPoints(0);
                    }
                    
                    player.PlayerTurns = 0;

                    player.GetPoints();

                    if (Calculate.HasPlayerWon(player))
                    {
                        Winner = player;
                        player.AddPlayerWins();
                        maxReached = true;
                        break;
                    }
                    
                    OutputConsole.NextPlayerLineBreak();
                }
            } while (!maxReached);
        }

        public void RunGame()
        {
            OutputConsole.WelcomeMessage();
            
            do
            {
                int numOfHumans = InputHandler.GetHumanPlayerNum();
                int numOfAi = InputHandler.GetCompPlayerNum();

                List<Player> playerList;
                if (numOfAi != 0)
                {
                    playerList = ListHandler.CreatePlayerList(humanPlayers: numOfHumans, computerPlayers: numOfAi);
                }

                else
                {
                    playerList = ListHandler.CreatePlayerList(humanPlayers: numOfHumans);
                }

                Console.Clear();

                bool nextGame;
                do
                {
                    RunPlayerTurn(playerList);

                    OutputConsole.NextPlayerLineBreak();
                    OutputConsole.DisplayWinner(Winner);

                    OutputConsole.DisplayGameLeaderboard(Calculate.GamePoints(playerList));
                    OutputConsole.DisplayOverallWins(Calculate.OverallWins(playerList));

                    string option = InputHandler.PlayAgain();

                    if (option is "1")
                    {
                        ResetPoints(playerList);
                        Console.Clear();
                        nextGame = false;
                    }
                    else if  (option is "2")
                    {
                        ResetPoints(playerList);
                        Console.Clear();
                        nextGame = true;
                    }
                    else
                    {
                        OutputConsole.DisplayGoodbye();
                        return;
                    }
                } while (!nextGame);
            } while (true);
        }
    }
}