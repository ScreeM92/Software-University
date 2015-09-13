namespace Battleships.ConsoleClient.Execution
{
    using System;
    using Interfaces;
    using Utilities;

    public class CommandExecutor
    {
        public CommandExecutor(IUserInterface userInterface)
        {
            this.UserInterface = userInterface;
        }

        public IUserInterface UserInterface { get; set; }

        public void ExecuteCommand(ICommand command, BattleshipsData data)
        {
            switch (command.Name.ToLower())
            {
                case "register":
                    this.ExecuteRegisterCommand(command, data);
                    break;
                case "login":
                    this.ExecuteLoginCommand(command, data);
                    break;
                case "logout":
                    this.ExecuteLogOutCommand(command, data);
                    break;
                case "create-game":
                    this.ExecuteCreateGameCommand(command, data);
                    break;
                case "join-game":
                    this.ExecuteJoinGameCommand(command, data);
                    break;
                case "available-games":
                    this.ExecuteShowAvailableGames(command, data);
                    break;
                case "play":
                    this.ExecutePlayCommand(command, data);
                    break;
                default:
                    throw new InvalidOperationException(Messages.InvalidCommandError);
            }
        }

        private void ExecuteShowAvailableGames(ICommand command, BattleshipsData data)
        {
            this.ValidateParametersLength(command, 0);
            this.ValidateUser(true, data, Messages.NotLoggedError);

            var restQueriesExecutor = new RestQueriesExecutor(this.UserInterface);
            var result = restQueriesExecutor.AvailableGamesAsync(data.LoggedUserAccessToken);
        }

        private void ExecuteRegisterCommand(ICommand command, BattleshipsData data)
        {
            this.ValidateParametersLength(command, 3);
            this.ValidateUser(false, data, Messages.RegistrationWhileLoggedError);

            var restQueriesExecutor = new RestQueriesExecutor(this.UserInterface);
            var result = restQueriesExecutor.RegisterAsync(command);
        }

        private void ExecuteLoginCommand(ICommand command, BattleshipsData data)
        {
            this.ValidateParametersLength(command, 2);
            this.ValidateUser(false, data, Messages.AlreadyLoggedError);

            var restQueriesExecutor = new RestQueriesExecutor(this.UserInterface);
            var result = restQueriesExecutor.LoginAsync(command, data);
        }

        private void ExecuteLogOutCommand(ICommand command, BattleshipsData data)
        {
            this.ValidateParametersLength(command, 0);
            this.ValidateUser(true, data, Messages.NotLoggedError);

            data.LogOutUser();
            this.UserInterface.WriteLine(Messages.LogedOutMessage); 
        }

        private void ExecuteCreateGameCommand(ICommand command, BattleshipsData data)
        {
            this.ValidateParametersLength(command, 0);
            this.ValidateUser(true, data, Messages.NotLoggedError);

            var restQueriesExecutor = new RestQueriesExecutor(this.UserInterface);
            var result = restQueriesExecutor.CreateGameAsync(data.LoggedUserAccessToken);
        }

        private void ExecuteJoinGameCommand(ICommand command, BattleshipsData data)
        {
            this.ValidateParametersLength(command, 1);
            this.ValidateUser(true, data, Messages.NotLoggedError);

            var restQueriesExecutor = new RestQueriesExecutor(this.UserInterface);
            var result = restQueriesExecutor.JoinGameAsync(command, data.LoggedUserAccessToken);
        }

        private void ExecutePlayCommand(ICommand command, BattleshipsData data)
        {
            this.ValidateParametersLength(command, 3);
            this.ValidateUser(true, data, Messages.NotLoggedError);

            var restQueriesExecutor = new RestQueriesExecutor(this.UserInterface);
            var result = restQueriesExecutor.PlayAsync(command, data.LoggedUserAccessToken);
        }

        private void ValidateParametersLength(ICommand command, int expectedCount)
        {
            if (command.Parameters.Count != expectedCount)
            {
                throw new InvalidOperationException(Messages.InvalidCommandError);
            }
        }

        private void ValidateUser(bool isLoggedCheck, BattleshipsData data, string errorMessage)
        {
            if (data.IsLogged != isLoggedCheck)
            {
                throw new InvalidOperationException(errorMessage);
            }
        }
    }
}