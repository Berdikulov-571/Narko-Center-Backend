using Autorization.Models;

namespace Autorization.Interfaces
{
    public interface IAuthService
    {
        ValueTask<string> GenerateToken(Login login);
    }
}