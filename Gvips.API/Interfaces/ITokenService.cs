using Gvips.Domain.Models;

namespace Gvips.API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}