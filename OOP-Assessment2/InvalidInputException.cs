using System;

namespace OOP_Assessment2
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message){}
    }
}