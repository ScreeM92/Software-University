namespace Battlefield.Models
{
    using System;
    using Interfaces;

    /// <summary>
    /// A class representing a random number generator for a battlefield
    /// </summary>
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        /// <summary>
        /// An instance of the Random class which provides the basic functionality of the generator
        /// </summary>
        private readonly Random randomGenerator;

        /// <summary>
        /// Initializes a new instance of the RandomNumberGenerator class. 
        /// </summary>
        public RandomNumberGenerator()
        {
            this.randomGenerator = new Random();
        }

        /// <summary>
        /// Gets a random number in a specified range.
        /// </summary>
        /// <param name="minRange">The minimal value the RandomGenerator should return.</param>
        /// <param name="maxRange">The maximal value the RandomGenerator should return.</param>
        /// <returns>A random number in the specified range.</returns>
        public int GetRandomNumber(int minRange, int maxRange)
        {
            return this.randomGenerator.Next(minRange, maxRange);
        }
    }
}
