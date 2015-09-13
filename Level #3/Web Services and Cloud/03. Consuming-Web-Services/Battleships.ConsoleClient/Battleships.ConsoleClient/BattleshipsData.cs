namespace Battleships.ConsoleClient
{
    public class BattleshipsData
    {
        public string LoggedUserAccessToken { get; private set; }

        public bool IsLogged {
            get
            {
                return !string.IsNullOrEmpty(this.LoggedUserAccessToken);
            }
        }

        public void LogUser(string accessToken)
        {
            this.LoggedUserAccessToken = accessToken;
        }

        public void LogOutUser()
        {
            this.LoggedUserAccessToken = null;
        }
    }
}