using System.Collections.Generic;

namespace OOP_Assessment2
{
    /// <summary>
    /// A class which handles all the list alterations and creations during the game.
    /// </summary>
    public static class ListHandler
    {
        /// <summary>
        /// Creates an integer list of the dice rolls. If it's the first roll then 5 dice rolls are added, otherwise
        /// only 3 are added.
        /// </summary>
        /// <param name="isSecondRoll">Boolean - whether it's the players second roll or not.</param>
        /// <param name="diceRolls">Integer list - either an empty list or a previous one to add to.</param>
        /// <param name="die">A Die object.</param>
        /// <returns>A list of integers - the dice rolls.</returns>
        public static List<int> CreateDiceRolls(bool isSecondRoll, List<int> diceRolls, Die die)
        {
            // Checks whether it's the second roll
            if (!isSecondRoll)
            {
                // Adds 5 dice rolls to the list
                for (int i = 0; i < 5; i++)
                {
                    diceRolls.Add(die.Roll());
                }
            }
      
            else
            {
                // Is the second roll so only 3 dice are added to the list
                for (int i = 0; i < 3; i++)
                {
                    diceRolls.Add(die.Roll());
                }
            }

            return diceRolls;
        }
        

        // An example of static polymorphism
        /// <summary>
        /// Creates a Player list of human players.
        /// </summary>
        /// <param name="humanPlayers">The amount of human players to be added to the list.</param>
        /// <returns>A Player list.</returns>
        public static List<Player> CreatePlayerList(int humanPlayers)
        {
            // Create an empty Player list
            List<Player> playerList = new List<Player>();
            
            // Must be at least 1 human player so set to 1
            int humanPlayerCount = 1;
            for (int i = 0; i < humanPlayers; i++)
            {
                Player human = new HumanPlayer();
                
                // After creating HumanPlayer object, use the InputHandler to get the player's name 
                string name = InputHandler.GetPlayerName(humanPlayerCount, isHuman: true);
                
                // Set the player name to InputHandler output and add it to the list of Players.
                human.SetPlayerName(name);
                playerList.Add(human);
                humanPlayerCount++;
            }

            return playerList;
        }
        
        // If computer players are playing then the CreatePlayerList is overloaded
        /// <summary>
        /// Creates a Player list of human and computer players.
        /// </summary>
        /// <param name="humanPlayers">The amount of human players to be added to the list</param>
        /// <param name="computerPlayers">The amount of computer players to be added to the list</param>
        /// <returns>A Player list.</returns>
        public static List<Player> CreatePlayerList(int humanPlayers, int computerPlayers)
        {
            // Create an empty player list
            List<Player> playerList = new List<Player>();
            
            // Initialise the name to be added to the players
            string name;
            
            // Must be at least 1 human player so set to 1
            int humanPlayerCount = 1;
            for (int i = 0; i < humanPlayers; i++)
            {
                Player human = new HumanPlayer();
                    
                // After creating HumanPlayer object, use the InputHandler to get the player's name 
                name = InputHandler.GetPlayerName(humanPlayerCount, isHuman: true);
                
                // Set the player name to InputHandler output and add it to the list of Players.
                human.SetPlayerName(name);
                playerList.Add(human);
                humanPlayerCount++;
            }
            
            // Must also be at least 1 computer player if this method has been called, so set to 1
            int computerPlayerCount = 1;
            for (int i = 1; i <= computerPlayers; i++)
            {
                Player computer = new ComputerPlayer();
                
                // After creating HumanPlayer object, use the InputHandler to get the player's name 
                name = InputHandler.GetPlayerName(computerPlayerCount, isHuman: false);
                
                // Set the player name to InputHandler output and add it to the list of Players.
                computer.SetPlayerName(name);
                playerList.Add(computer);
                computerPlayerCount++;
            }

            return playerList;
        }
        
        /// <summary>
        /// Removes all the non-duplicate rolls from the list of dice rolls.
        /// </summary>
        /// <param name="diceRolls">The current list of dice rolls.</param>
        /// <param name="maxDieNumFace">The dice number which appears twice.</param>
        /// <returns></returns>
        public static List<int> RemoveNonDuplicateRolls(List<int> diceRolls, int maxDieNumFace)
        {
            // Remove all dice except the 2-of-a-kind pair
            diceRolls.RemoveAll(x => x != maxDieNumFace);

            return diceRolls;
        }
    }
}