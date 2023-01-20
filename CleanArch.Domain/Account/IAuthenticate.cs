
namespace CleanArch.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task<bool> RegisterUser(string email, string password);
        Task Logout();
    }
}
