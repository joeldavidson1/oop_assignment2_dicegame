using System;
using System.Data;
using System.Linq;

namespace OOP_Assessment2
{
    /// <summary>
    /// A class that handles the human players, which inherits from the Player class.
    /// </summary>
    public class HumanPlayer : Player
    {
        /// <summary>
        /// Overrides the base method and sets the name to the name parameter after formatting it.
        /// </summary>
        /// <param name="name">The name of the human.</param>
        public override void SetPlayerName(string name)
        {
            // Convert name to lower case and capitalise the first letter.
            name = name.ToLower();
            name = char.ToUpper(name[0]) + name.Substring(1);
            Name = name;
        }
    }
}