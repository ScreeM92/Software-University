namespace XmlFinished_Games
{
    using System.Collections.Generic;

    public class FinishedGame
    {
        public string Name { get; set; }

        public int? Duration { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}