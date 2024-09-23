using ProductAPI.Models;

namespace ProductAPI.Services.Interfaces
{
    public interface ITokenService
    {
        string GetToken(User user);
    }
}
