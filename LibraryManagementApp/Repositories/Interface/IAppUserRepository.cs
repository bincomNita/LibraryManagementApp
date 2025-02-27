using LibraryManagementApp.Model;

namespace LibraryManagementApp.Repositories.Interface
{
    public interface IAppUserRepository
    {
        Task<string> Register(AppUser user);
        Task<string> Login(AppUser user);
        string GenerateJwtToken(AppUser user);
    }
}
