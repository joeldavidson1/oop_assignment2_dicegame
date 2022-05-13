using System;
using System.Collections.Generic;
using System.Threading;

namespace OOP_Assessment2
{
    // creates only one random object, as if a new random object is called each time, it can produce identical sequences
    // of numbers due to using the same seed.
    public class Die : IRoll
    {
        private static Random _randomGenerator;
        public int Roll()
        {
            return _randomGenerator.Next(1, 7);
        }

        public string[] Face(int dieNum)
        {
            string[] die1 =
            {
                "+-------+",
                "|       |",
                "|   o   |",
                "|       |",
                "+-------+"
            };
            
            string[] die2 =
            {
                "+-------+",
                "| o     |",
                "|       |",
                "|     o |",
                "+-------+"
            };

            string[] die3 =
            {
                "+-------+",
                "| o     |",
                "|   o   |",
                "|     o |",
                "+-------+"
            };

            string[] die4 =
            {
                "+-------+",
                "| o   o |",
                "|       |",
                "| o   o |",
                "+-------+"
            };

            string[] die5 =
            {
                "+-------+",
                "| o   o |",
                "|   o   |",
                "| o   o |",
                "+-------+"
            };

            string[] die6 =
            {
                "+-------+",
                "| o   o |",
                "| o   o |",
                "| o   o |",
                "+-------+"
            };

            if (dieNum is 1)
            {
                return die1;
            }

            if (dieNum is 2)
            {
                return die2;
            }

            if (dieNum is 3)
            {
                return die3;
            }

            if (dieNum is 4)
            {
                return die4;
            }

            if (dieNum is 5)
            {
                return die5;
            }

            if (dieNum is 6)
            {
                return die6;
            }
            
            return new string[] { };
        }

        public Die()
        {
            _randomGenerator = new Random();
        }
    }
}