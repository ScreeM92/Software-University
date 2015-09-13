namespace Battleships.ConsoleClient.Models
{
    public class AvailableGamesView
    {
        public string Id { get; set; }

        public override string ToString()
        {
            return this.Id;
        }
    }
}