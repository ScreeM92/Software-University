namespace News.Services.Infrastructure
{
    public interface IUserProvider
    {
        bool IsAuthenticated { get; }

        string GetUserId();
    }
}