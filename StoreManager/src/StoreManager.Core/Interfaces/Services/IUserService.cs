using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManager.Core.ViewModels.Users;

namespace StoreManager.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task DeleteUserAsync(int id);
        Task<UserDTO> GetUserAsync(int id);
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> InsertAsync(NewUserDTO userDTO);
        Task<string> LoginIn(BaseUserDTO baseUser);
        Task UndeleteUserAsync(int id);
        Task<UserDTO> UpdateUserAsync(UpdateUserDTO userDTO);
    }
}