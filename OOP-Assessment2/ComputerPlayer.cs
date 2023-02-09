namespace OOP_Assessment2
{
    /// <summary>
    /// A class that handles the computer players, which inherits from the Player class.
    /// </summary>
    public class ComputerPlayer : Player
    {
        /// <summary>
        /// Overrides the base method and sets the name to the name parameter.
        /// </summary>
        /// <param name="name">The name of the computer.</param>
        public override void SetPlayerName(string name)
        {
            Name = name;
        }
    }
}