namespace Battleships.ConsoleClient.Utilities
{
    public static class RestEndpoints
    {
        public const string RegisterEndpoint = @"http://localhost:62858/api/account/register";
        public const string LoginEndpoint = @"http://localhost:62858/Token";
        public const string JoinGameEndpoint = @"http://localhost:62858/api/games/join";
        public const string PlayTurnEndpoint = @"http://localhost:62858/api/games/play";
        public const string CreateGameEndpoint = @"http://localhost:62858/api/games/create";
        public const string GetAvailableGamesEndpoint = @"http://localhost:62858/api/games/available";
    }
}