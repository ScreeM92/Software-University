namespace Battlefield.Interfaces
{
    /// <summary>
    /// Represents an abstraction for RandomNumber generators.
    /// </summary>
    public interface IRandomNumberGenerator
    {
        /// <summary>
        /// Gets a random number in a specified range.
        /// </summary>
        /// <param name="minRange">The minimal value the RandomGenerator should return.</param>
        /// <param name="maxRange">The maximal value the RandomGenerator should return.</param>
        /// <returns>A random number in the specified range.</returns>
        int GetRandomNumber(int minRange, int maxRange);
    }
}
