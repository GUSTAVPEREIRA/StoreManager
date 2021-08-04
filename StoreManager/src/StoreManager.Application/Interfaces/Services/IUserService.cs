using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManager.SharedKernel.ViewModels.Users;

namespace StoreManager.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task DeleteUserAsync(int id);
        Task<UserDTO> GetUserAsync(int id);
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> InsertAsync(NewUserDTO userDTO);
        Task<UserDTO> UpdateUserAsync(UpdateUserDTO userDTO);
    }
}