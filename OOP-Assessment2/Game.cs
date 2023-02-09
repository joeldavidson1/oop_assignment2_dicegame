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
        /// <summary>
        /// The number of points to win.
        /// </summary>
        public const int MaxPoints = 10;
        
        // Encapsulate the following 2 properties only to be used inside the Game class:
        
        /// <summary>
        /// Player object (the winner of the game).
        /// </summary>
        private Player Winner { get; set; }
        
        /// <summary>
        /// Die object - used input to various methods.
        /// </summary>
        private Die Die { get; }
        
        /// <summary>
        /// Constructor which initialises a die object.
        /// </summary>
        public Game()
        {
            Die = new Die();
        }
        
        /// <summary>
        /// Resets all the player's points back to 0.
        /// </summary>
        /// <param name="playerList">The current list of players.</param>
        private void ResetPoints(List<Player> playerList)
        {
            // Iterate through each player in the list and reset their points.
            foreach (Player player in playerList )
            {
                player.ResetPlayerPoints();
            }
        }
        
        /// <summary>
        /// Run the turn for the player for the first and second dice roll (if second is needed).
        /// </summary>
        /// <param name="playerList">The current list of players.</param>
        private void RunPlayerTurn(List<Player> playerList)
        {
            // Initialise bool which allows the while loop to continue if the max number of points hasn't been reached
            bool maxReached = false;
            do
            {
                // Iterate through each player in the Player list
                foreach (Player player in playerList)
                {
                    // Display current player turn
                    OutputConsole.DisplayPlayerTurn(player);
                    
                    // Create a list of dice rolls
                    List<int> diceRolls = ListHandler.CreateDiceRolls(isSecondRoll: false, new List<int>(), Die);
                    
                    // Display the player's roll
                    OutputConsole.DisplayPlayerRoll(isSecondRoll: false, player: player);
                    OutputConsole.DisplayDieFaces(diceRolls, Die);
                    
                    // Add turn to the player
                    player.PlayerTurn(endOfRolls: false);
                    
                    // Create a dictionary from the players dice rolls using the diceRolls list
                    Dictionary<int, int> diceNumFreq = Calculate.DiceNumFreqDict(diceRolls);
                    
                    // Obtain the most frequent die number and it's frequency
                    int maxDieNumFreq = Calculate.MaxDieNumFreq(diceNumFreq);
                    int maxDieNumFace = Calculate.MaxDieNumFace(diceNumFreq);
                    
                    // Obtain the player's points and display the score
                    int points = Calculate.PlayerTurnPoints(maxDieNumFreq);
                    OutputConsole.DisplayScore(player.PlayerTurns, maxDieNumFreq);

                    // If 2 of-a-kind has been found
                    if (maxDieNumFreq is 2)
                    {
                        // Add another turn to the player
                        player.PlayerTurn(endOfRolls: false);
                        
                        // Create a new diceRolls list removing all the non-duplicates and adding 3 now dice rolls to
                        // the list
                        diceRolls = ListHandler.RemoveNonDuplicateRolls(diceRolls, maxDieNumFace);
                        List<int> diceRolls2 = ListHandler.CreateDiceRolls(isSecondRoll: true, diceRolls, Die);
                        
                        // Alter the dictionary to account for the new dice rolls
                        diceNumFreq = Calculate.DiceNumFreqDict(diceRolls2);
                        
                        // Obtain the most frequent die number
                        maxDieNumFreq = Calculate.MaxDieNumFreq(diceNumFreq);
                        
                        // Display the player's second roll
                        OutputConsole.DisplayPlayerRoll(isSecondRoll: true, player: player);
                        OutputConsole.DisplayDieFaces(diceRolls2, Die);
                        
                        // Obtain the player's points and display the score again
                        points = Calculate.PlayerTurnPoints(maxDieNumFreq);
                        OutputConsole.DisplayScore(player.PlayerTurns, maxDieNumFreq);
                    }
                    
                    // Add the number of points to the player's total points and display their points
                    player.AddPlayerPoints(points);
                    OutputConsole.DisplayPlayerPoints(player, player.Points);
                    
                    // End of the players rolls to player turns set back to 0.
                    player.PlayerTurn(endOfRolls: true);
    
                    // Check whether the player's points is => max game points
                    if (Calculate.HasPlayerWon(player))
                    {
                        // If so, player is the current winner and a win gets added
                        Winner = player;
                        player.AddPlayerWins();
                        
                        // Max points has been reached so loop changed to true so it ends.
                        maxReached = true;
                        break;
                    }
                    
                    OutputConsole.NextPlayerLineBreak();
                }
            } while (!maxReached);
        }

        /// <summary>
        /// Runs the whole game from beginning to end.
        /// </summary>
        public void RunGame()
        {
            OutputConsole.WelcomeMessage();
            
            do
            {
                // Obtain the number of human and/or computer players
                int numOfHumans = InputHandler.GetHumanPlayerNum();
                int numOfAi = InputHandler.GetCompPlayerNum();

                // Initialise an empty Player list
                List<Player> playerList;
                
                // If the number of computer players are > 0 then create the list of both human and computer players
                if (numOfAi > 0)
                {
                    playerList = ListHandler.CreatePlayerList(humanPlayers: numOfHumans, computerPlayers: numOfAi);
                }

                // Otherwise just create list of human players.
                else
                {
                    playerList = ListHandler.CreatePlayerList(humanPlayers: numOfHumans);
                }

                Console.Clear();

                // Initialise boolean to check whether to continue to the next game or not
                bool nextGame;
                do
                {
                    // Run each player's turn from the list of players
                    RunPlayerTurn(playerList);
    
                    OutputConsole.NextPlayerLineBreak();
                    
                    // Display the winner and the current game leaderboard and session wins
                    OutputConsole.DisplayWinner(Winner);
                    OutputConsole.DisplayGameLeaderboard(Calculate.GamePoints(playerList));
                    OutputConsole.DisplayOverallWins(Calculate.OverallWins(playerList));
                    
                    // Check whether user wants to play again
                    string option = InputHandler.PlayAgain();

                    // If user wants to play with the same players
                    if (option is "1")
                    {
                        ResetPoints(playerList);
                        Console.Clear();
                        nextGame = false;
                    }
                    
                    // If user wants to play again but with different players.
                    else if  (option is "2")
                    {
                        ResetPoints(playerList);
                        Console.Clear();
                        nextGame = true;
                    }
                    
                    // If user does not want to play again then return nothing and terminate the application.
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