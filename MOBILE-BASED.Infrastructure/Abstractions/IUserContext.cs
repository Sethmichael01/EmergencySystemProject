namespace MOBILE_BASED.Infrastructure.Abstractions
{
    public interface IUserContext
    {
        bool IsInRole(string role);
        bool IsAuthenticated();
        string GetUserId();
        string GetUserEmail();
    }
}
