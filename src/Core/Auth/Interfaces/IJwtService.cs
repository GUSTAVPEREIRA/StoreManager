namespace Core.Auth.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}