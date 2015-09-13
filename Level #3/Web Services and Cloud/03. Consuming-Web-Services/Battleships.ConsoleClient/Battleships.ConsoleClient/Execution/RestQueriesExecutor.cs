namespace Battleships.ConsoleClient.Execution
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;
    using Utilities;

    public class RestQueriesExecutor
    {
        public RestQueriesExecutor(IUserInterface userInterface)
        {
            this.UserInterface = userInterface;
        }

        public IUserInterface UserInterface { get; set; }

        public async Task RegisterAsync(ICommand command)
        {
            using (var httpClient = new HttpClient())
            {
                var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Email", command.Parameters[0]), 
                    new KeyValuePair<string, string>("Password", command.Parameters[1]), 
                    new KeyValuePair<string, string>("ConfirmPassword", command.Parameters[2]), 
                });
                var response = await httpClient.PostAsync(RestEndpoints.RegisterEndpoint, bodyData);

                string result;
                if (!response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    result = string.Format(Messages.RegisteredMessage, command.Parameters[0]);
                }

                this.UserInterface.WriteLine(result);
            }
        }

        public async Task LoginAsync(ICommand command, BattleshipsData data)
        {
            using (var httpClient = new HttpClient())
            {
                var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Username", command.Parameters[0]), 
                    new KeyValuePair<string, string>("Password", command.Parameters[1]), 
                    new KeyValuePair<string, string>("grant_type", "password"), 
                });
                var response = await httpClient.PostAsync(RestEndpoints.LoginEndpoint, bodyData);

                string result;
                if (!response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    var accessToken = (await response.Content.ReadAsAsync<LoginDTO>()).Access_Token;
                    data.LogUser(accessToken);
                    result = string.Format(Messages.LogedInMessage, command.Parameters[0]);
                }

                this.UserInterface.WriteLine(result);
            }
        }

        public async Task CreateGameAsync(string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                var response = await httpClient.PostAsync(RestEndpoints.CreateGameEndpoint, null);

                string result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    result = string.Format(Messages.CreatedGameMessage, result);
                }

                this.UserInterface.WriteLine(result);
            }
        }

        public async Task AvailableGamesAsync(string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                var response = await httpClient.GetAsync(RestEndpoints.GetAvailableGamesEndpoint);

                string result;
                if (!response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    var availablegames = await response.Content.ReadAsAsync<ICollection<AvailableGamesView>>();

                    if (availablegames.Count > 0)
                    {
                        result = "=> " + string.Join("\n=> ", availablegames);
                    }
                    else
                    {
                        result = Messages.NoAvailableGamesMessage;
                    }
                }

                this.UserInterface.WriteLine(result);
            }
        }

        public async Task JoinGameAsync(ICommand command, string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("GameId", command.Parameters[0])
                });
                var response = await httpClient.PostAsync(RestEndpoints.JoinGameEndpoint, bodyData);

                string result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    result = string.Format(Messages.JoinedGameMessage);
                }

                this.UserInterface.WriteLine(result);
            }
        }

        public async Task PlayAsync(ICommand command, string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("GameId", command.Parameters[0]),
                    new KeyValuePair<string, string>("PositionX", command.Parameters[1]),
                    new KeyValuePair<string, string>("PositionY", command.Parameters[2])
                });

                var response = await httpClient.PostAsync(RestEndpoints.PlayTurnEndpoint, bodyData);

                string result = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    result = string.Format(Messages.NonExistingGameError, command.Parameters[0]);
                }

                if (response.IsSuccessStatusCode)
                {
                    result = string.Format(Messages.PositionBombedMessage, command.Parameters[1], command.Parameters[2]);
                }

                this.UserInterface.WriteLine(result);
            }
        }
    }
}