using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StoreManager.Application.Interfaces.Services;
using StoreManager.Core.Domain;
using StoreManager.Core.Interfaces.Repositories;
using StoreManager.SharedKernel.ViewModels.Users;
using System;

namespace StoreManager.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapping;

        public UserService(IUserRepository userRepository, IMapper mapping)
        {
            this.userRepository = userRepository;
            this.mapping = mapping;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {

            var users = await userRepository.GetUsersAsync();
            var usersDTO = mapping.Map<IEnumerable<UserDTO>>(users);

            return usersDTO;
        }

        public async Task<UserDTO> GetUserAsync(int id)
        {
            var user = await userRepository.GetAsync(id);

            return mapping.Map<UserDTO>(user);
        }

        public async Task<UserDTO> InsertAsync(NewUserDTO userDTO)
        {
            var user = mapping.Map<NewUserDTO, User>(userDTO);
            ConvertPasswordToHash(user);
            user = await userRepository.InsertAsync(user);

            return mapping.Map<UserDTO>(user);
        }

        public async Task<UserDTO> UpdateUserAsync(UpdateUserDTO userDTO)
        {
            var user = mapping.Map<User>(userDTO);
            ConvertPasswordToHash(user);
            user.UpdatedAt = DateTime.UtcNow;
            user = await userRepository.UpdateAsync(user);

            return mapping.Map<UserDTO>(user);
        }

        private void ConvertPasswordToHash(User user)
        {
            var hasher = new PasswordHasher<User>();
            user.Password = hasher.HashPassword(user, user.Password);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await userRepository.GetAsync(id);
            user.DeleteUser();
            await userRepository.UpdateAsync(user);
        }

        public async Task UndeleteUserAsync(int id)
        {
            var user = await userRepository.GetAsync(id);
            user.UnDeleteUser();
            await userRepository.UpdateAsync(user);
        }
    }
}