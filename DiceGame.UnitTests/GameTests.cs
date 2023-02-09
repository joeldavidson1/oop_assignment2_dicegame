using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;
using NUnit.Framework;
using OOP_Assessment2;

namespace DiceGame.UnitTests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void MaxDieNumFreq_12345DiceValues_Returns1()
        {
            List<int> diceRolls = new List<int>();
            
            // Adding dice rolls 1, 2, 3, 4, 5
            for (int i = 1; i < 6; i++)
            {
                diceRolls.Add(i);
            }

            Dictionary<int, int> diceNumFreq = Calculate.DiceNumFreqDict(diceRolls);
            int maxDieNumFreq = Calculate.MaxDieNumFreq(diceNumFreq);

            Assert.AreEqual(maxDieNumFreq, 1);
        }
        
        [Test]
        public void PlayerTurnPoints_DiffDiceValues_Returns0Points()
        {
            List<int> diceRolls = new List<int>();
            
            // Adding dice rolls 1, 2, 3, 4, 5
            for (int i = 1; i < 6; i++)
            {
                diceRolls.Add(i);
            }

            Dictionary<int, int> diceNumFreq = Calculate.DiceNumFreqDict(diceRolls);
            int maxDieNumFreq = Calculate.MaxDieNumFreq(diceNumFreq);
            int points = Calculate.PlayerTurnPoints(maxDieNumFreq);
            
            Assert.AreEqual(points, 0);
        }

        [Test]
        [Repeat(100)]
        public void CreateDiceRolls_DieBetween1And6_ReturnsNumListBetween1And6()
        {
            Die die = new Die();
            List<int> diceRolls = ListHandler.CreateDiceRolls(false, new List<int>(), die);
            
            foreach (int diceNum in diceRolls)
            {
                Assert.LessOrEqual(diceNum, 6);
                Assert.GreaterOrEqual(diceNum, 1);
            }
        }
        
        [Test]
        [Repeat(100)]
        public void CreateDiceRolls_RandomDieNumsAdded_ReturnsListCount5()
        {
            Die die = new Die();
            List<int> diceRolls = ListHandler.CreateDiceRolls(false, new List<int>(), die);

            int numOfDice = diceRolls.Count;
            
            Assert.AreEqual(numOfDice, 5);
        }
        
        [Test]
        [Repeat(100)]
        public void CreateDiceRolls_RandomDieNumsAddedAdded_ReturnsDifferentListEachTime()
        {
            Die die = new Die();
            List<int> diceRolls1 = ListHandler.CreateDiceRolls(false, new List<int>(), die);
            List<int> diceRolls2 = ListHandler.CreateDiceRolls(false, new List<int>(), die);
            
            CollectionAssert.AreNotEqual(diceRolls1, diceRolls2);
        }

        [Test]
        public void HasPlayerWon_PlayerPointsGreaterThanMax_ReturnsTrue()
        {
            Player humanPlayer = new HumanPlayer();

            humanPlayer.AddPlayerPoints(Game.MaxPoints);
            bool output = Calculate.HasPlayerWon(humanPlayer);

            Assert.True(output);
        }
        
        [Test]
        public void HasPlayerWon_PlayerPointsLessThanMax_ReturnsFalse()
        {
            Player computerPlayer = new ComputerPlayer();
            
            computerPlayer.AddPlayerPoints(Game.MaxPoints - 1);
            bool output = Calculate.HasPlayerWon(computerPlayer);

            Assert.False(output);
        }
    }
}