using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManager.Core.Auth.ViewModels;

namespace StoreManager.Core.Auth.Interfaces
{
    public interface IUserService
    {
        Task DeleteUserAsync(int id);
        Task<UserDto> GetUserAsync(int id);
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> InsertAsync(NewUserDto usersDto);
        Task<string> LoginIn(BaseUserDto baseUser);
        Task UndeleteUserAsync(int id);
        Task<UserDto> UpdateUserAsync(UpdateUserDto usersDto);
    }
}