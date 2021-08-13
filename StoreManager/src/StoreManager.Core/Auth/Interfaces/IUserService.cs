using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManager.Core.Auth.ViewModels;

namespace StoreManager.Core.Auth.Interfaces
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