using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Core.Auth;
using Core.Auth.Interfaces;
using Core.Auth.ViewModels;

namespace Application.Auth.Services
{
    public class UserService : IUserService
    {
        private readonly IJwtService jwtService;
        private readonly IMapper mapping;
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository, IMapper mapping, IJwtService jwtService)
        {
            this.userRepository = userRepository;
            this.mapping = mapping;
            this.jwtService = jwtService;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await userRepository.GetUsersAsync();
            var usersDto = mapping.Map<IEnumerable<UserDto>>(users);

            return usersDto;
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            var user = await userRepository.GetAsync(id);

            return mapping.Map<UserDto>(user);
        }

        public async Task<UserDto> InsertAsync(NewUserDto usersDto)
        {
            var user = mapping.Map<NewUserDto, User>(usersDto);
            ConvertPasswordToHash(user);
            user = await userRepository.InsertAsync(user);

            return mapping.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateUserAsync(UpdateUserDto usersDto)
        {
            var user = mapping.Map<User>(usersDto);
            ConvertPasswordToHash(user);
            user.UpdatedAt = DateTime.UtcNow;
            user = await userRepository.UpdateAsync(user);

            return mapping.Map<UserDto>(user);
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

        public async Task<string> LoginIn(BaseUserDto baseUser)
        {
            var foundUser = await userRepository.GetByUsernameAsync(baseUser.Login);

            var token = "";

            if (foundUser != null && HashValidateAsync(foundUser, baseUser.Password))
            {
                token = jwtService.GenerateToken(foundUser);
            }

            return token;
        }

        private static void ConvertPasswordToHash(User user)
        {
            var hasher = new PasswordHasher<User>();
            user.Password = hasher.HashPassword(user, user.Password);
        }

        private bool HashValidateAsync(User user, string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, user.Password, password);

            return PasswordHashValidate(result);
        }

        private static bool PasswordHashValidate(PasswordVerificationResult result)
        {
            return result switch
            {
                PasswordVerificationResult.Failed => false,
                PasswordVerificationResult.Success => true,
                PasswordVerificationResult.SuccessRehashNeeded => true,
                _ => false
            };
        }
    }
}