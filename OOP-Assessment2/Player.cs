using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace OOP_Assessment2
{
    /// <summary>
    /// An abstract class that is used as the base class (parent) for all the games players.
    /// </summary>
    public abstract class Player
    {
        // Protected set access control so only derived members can set the Name property
        /// <summary>
        /// Player name.
        /// </summary>
        public string Name { get; protected set; }
        
        // Private points, turns and wins set so they can only be changed inside of a Player derived class:
        
        /// <summary>
        /// The number of points the player has.
        /// </summary>
        public int Points { get; private set; }
        
        /// <summary>
        /// The number of turns the player has.
        /// </summary>
        public int PlayerTurns { get; private set; }
        
        /// <summary>
        /// The total wins the player has in the session.
        /// </summary>
        public int TotalWins { get; private set; }

        // Method which demonstrates dynamic polymorphism
        /// <summary>
        /// Abstract method which sets the name of the player.
        /// </summary>
        /// <param name="name">A string - name of the player.</param>
        public abstract void SetPlayerName(string name);

        /// <summary>
        /// Adds the number of points to the player's total points.
        /// </summary>
        /// <param name="points">The points that have been calculated to be added.</param>
        public void AddPlayerPoints(int points)
        {
            Points += points;
        }

        /// <summary>
        /// Reset the player's points back to 0 for the next game.
        /// </summary>
        public void ResetPlayerPoints()
        {
            Points = 0;
        }

        /// <summary>
        /// Adds a turn to the player during the first and second rolls, otherwise it resets the turns back to 0 ready
        /// for the next round.
        /// </summary>
        /// <param name="endOfRolls">A boolean - whether they have finished their rolls or not.</param>
        public void PlayerTurn(bool endOfRolls)
        {
            if (!endOfRolls)
            {
                PlayerTurns++;
            }
            else
            {
                PlayerTurns = 0;
            }
        }
        
        /// <summary>
        /// Adds a win to the total wins of the player.
        /// </summary>
        public void AddPlayerWins()
        {
            TotalWins++;
        }
    }
}