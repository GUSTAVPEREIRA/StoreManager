using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StoreManager.Core.Domain;
using StoreManager.Core.Interfaces.Repositories;
using System;
using StoreManager.Core.Interfaces.Services;
using StoreManager.Core.ViewModels.Users;

namespace StoreManager.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IJwtService jwtService;
        private readonly IMapper mapping;

        public UserService(IUserRepository userRepository, IMapper mapping, IJwtService jwtService)
        {
            this.userRepository = userRepository;
            this.mapping = mapping;
            this.jwtService = jwtService;
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

        public async Task<String> LoginIn(BaseUserDTO baseUser)
        {
            var foundUser = await userRepository.GetByUsernameAsync(baseUser.Login);
            var token = "";

            if (foundUser != null)
            {
                token = jwtService.GenerateToken(foundUser);
            }

            return token;
        }

        private bool HashValidateAsync(User user, string hash)
        {
            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, hash, user.Password);

            return PasswordHashValidate(result);
        }

        private bool PasswordHashValidate(PasswordVerificationResult result) => result switch
        {
            PasswordVerificationResult.Failed => false,
            PasswordVerificationResult.Success => true,
            PasswordVerificationResult.SuccessRehashNeeded => true,
            _ => false
        };
    }
}