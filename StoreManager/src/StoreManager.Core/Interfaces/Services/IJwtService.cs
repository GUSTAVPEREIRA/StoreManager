using StoreManager.Core.Domain;

namespace StoreManager.Core.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}