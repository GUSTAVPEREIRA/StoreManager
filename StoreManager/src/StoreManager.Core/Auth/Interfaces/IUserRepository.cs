using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManager.Core.Domain;

namespace StoreManager.Core.Auth.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetAsync(int id);
        Task<User> GetByUsernameAsync(string username);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> InsertAsync(User user);
        Task<User> UpdateAsync(User user);
    }
}