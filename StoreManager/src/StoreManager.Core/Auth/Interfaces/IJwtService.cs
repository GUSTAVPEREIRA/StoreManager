using StoreManager.Core.Domain;

namespace StoreManager.Core.Auth.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}