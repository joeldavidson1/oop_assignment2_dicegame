using System.Collections.Generic;

namespace OOP_Assessment2
{
    public class ListHandler
    {
        private Die Die { get; }
        
        public ListHandler()
        {
            Die = new Die();
        }

        public List<int> CreateDiceRolls(bool isSecondRoll, List<int> diceRolls)
        {
            if (!isSecondRoll)
            {
                for (int i = 0; i < 5; i++)
                {
                    diceRolls.Add(Die.Roll());
                }
            }
      
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    diceRolls.Add(Die.Roll());
                }
            }

            return diceRolls;
        }
        
        
        // static polymorphism examples....
        public List<Player> CreatePlayerList(int humanPlayers)
        {
            List<Player> playerList = new List<Player>();
            
            int humanPlayerCount = 1;
            for (int i = 0; i < humanPlayers; i++)
            {
                Player human = new HumanPlayer();
                human.SetPlayerName(humanPlayerCount);
                playerList.Add(human);
                humanPlayerCount++;
            }

            return playerList;
        }
        
        public List<Player> CreatePlayerList(int humanPlayers, int computerPlayers)
        {
            List<Player> playerList = new List<Player>();
            
            int humanPlayerCount = 1;
            for (int i = 0; i < humanPlayers; i++)
            {
                Player human = new HumanPlayer();
                human.SetPlayerName(humanPlayerCount);
                playerList.Add(human);
                humanPlayerCount++;
            }

            int computerPlayerCount = 1;
            for (int i = 1; i <= computerPlayers; i++)
            {
                Player computer = new ComputerPlayer();
                computer.SetPlayerName(computerPlayerCount);
                playerList.Add(computer);
                computerPlayerCount++;
            }

            return playerList;
        }
        
        public List<int> RemoveNonDuplicateRolls(List<int> diceRolls, int maxDieNumFace)
        {
            // Remove all dice except the 2-of-a-kind pair
            diceRolls.RemoveAll(x => x != maxDieNumFace);

            return diceRolls;
        }
    }
}