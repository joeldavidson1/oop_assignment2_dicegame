using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace OOP_Assessment2
{
    internal class Program 
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            game.RunGame();
        }
    }
}