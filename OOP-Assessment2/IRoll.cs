namespace OOP_Assessment2
{
    /// <summary>
    /// Interface which implements two methods associated with rolling a die.
    /// </summary>
    public interface IRoll
    {
        int Roll();
        string[] Face(int dieNum);
    }
}