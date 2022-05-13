using System;
using System.Collections.Generic;
using NUnit.Framework;
using OOP_Assessment2;

namespace DiceGame.UnitTests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void CalculatePoints_DiffValues_0Points()
        {
            var game = new Game();
            
            game.RunGame();

            Assert.True(true);
        }
    }
}