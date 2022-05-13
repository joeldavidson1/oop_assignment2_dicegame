namespace OOP_Assessment2
{
    public class ComputerPlayer : Player
    {
        public override void SetPlayerName(int computerCount)
        {
            Name = $"Computer Player {computerCount}";
        }
    }
}