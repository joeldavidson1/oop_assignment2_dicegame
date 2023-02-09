using System;
using System.Collections.Generic;
using System.Threading;

namespace OOP_Assessment2
{
   
    /// <summary>
    /// A class which handles the rolls of the dice and the number (face) it lands on. Implements the IRoll interface.
    /// </summary>
    public class Die : IRoll
    {
        // Can only be used inside the Die class (encapsulation)
        /// <summary>
        /// Creates only one random object, as if a new random object is called each time, it can produce identical
        /// sequences of numbers due to using the same seed.
        /// </summary>
        private static Random _randomGenerator = new Random();
        
        /// <summary>
        /// Random object returns a random integer from 1 - 6.
        /// </summary>
        /// <returns>An integer - 1 to 6.</returns>
        public int Roll()
        {
            return _randomGenerator.Next(1, 7);
        }

        /// <summary>
        /// Holds the faces of the die as ascii art and returns the corresponding face to the number the die landed on. 
        /// Faces held as string arrays as to display them horizontally in the console.
        /// </summary>
        /// <param name="dieNum">The number the die landed on.</param>
        /// <returns>A string[] - ascii art of the die face.</returns>
        public string[] Face(int dieNum)
        {
            string[] die1 =
            {
                "+———————+",
                "|       |",
                "|   o   |",
                "|       |",
                "+———————+"
            };
            
            string[] die2 =
            {
                "+———————+",
                "| o     |",
                "|       |",
                "|     o |",
                "+———————+"
            };

            string[] die3 =
            {
                "+———————+",
                "| o     |",
                "|   o   |",
                "|     o |",
                "+———————+"
            };

            string[] die4 =
            {
                "+———————+",
                "| o   o |",
                "|       |",
                "| o   o |",
                "+———————+"
            };

            string[] die5 =
            {
                "+———————+",
                "| o   o |",
                "|   o   |",
                "| o   o |",
                "+———————+"
            };

            string[] die6 =
            {
                "+———————+",
                "| o   o |",
                "| o   o |",
                "| o   o |",
                "+———————+"
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
            
            // Returns an empty string if the number is not between 1-6. This would need amending if a dice with more
            // faces were added.
            return new string[] { };
        }
    }
}