using System;

namespace OOP_Assessment2
{
    /// <summary>
    /// Custom exception class which creates a template for invalid user input.
    /// </summary>
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message){}
    }
}