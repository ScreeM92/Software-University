namespace Battleships.ConsoleClient.Utilities
{
    public class Messages
    {
        public const string Legend = 
            "Register\t|register {email} {password} {confirmPassword}|\n" +
            "Login\t\t|login {email} {password}|\n" +
            "Logout\t\t|logout|\n" + 
            "Create game\t|create-game|\n" + 
            "Available games\t|available-games|\n" + 
            "Join game\t|join-game {gameId}|\n" +
            "Play turn\t|play {gameId} {PositionX} {PositionY}|\n" + 
            "Exit\t\t|exit|";
        
        public const string MessagePrefix = "\n=> ";
        public const string RegisteredMessage = MessagePrefix + "User with email {0} successfully registered.";
        public const string LogedInMessage = MessagePrefix + "User {0} successfully logged in.";
        public const string LogedOutMessage = MessagePrefix + "Successfully logged out.";
        public const string CreatedGameMessage = MessagePrefix + "Successfully created game with id {0}.";
        public const string JoinedGameMessage = MessagePrefix + "Successfully joined the game.";
        public const string PositionBombedMessage = MessagePrefix + "Position {0} {1} successfully bombed.";
        public const string NoAvailableGamesMessage = MessagePrefix + "There is no available games.";

        public const string RegistrationFailedError = MessagePrefix + "Registration failed.";
        public const string CreateGameFailedError = MessagePrefix + "Create game failed.";
        public const string InvalidCommandError = MessagePrefix + "Invalid command.";
        public const string NotLoggedError = MessagePrefix + "There is no user logged.";
        public const string AlreadyLoggedError = MessagePrefix + "There is already logged user.";
        public const string NonExistingGameError = MessagePrefix + "There is no game with id {0}.";
        public const string RegistrationWhileLoggedError = MessagePrefix + "Can't register while logged in.";

    }
}