using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManager.Core.Domain;

namespace StoreManager.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> InsertAsync(User user);
        Task<User> UpdateAsync(User user);
    }
}