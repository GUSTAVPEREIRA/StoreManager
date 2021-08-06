using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bogus;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using StoreManager.Application.Interfaces.Services;
using StoreManager.Application.Services;
using StoreManager.Core.Domain;
using StoreManager.Core.Interfaces.Repositories;
using StoreManager.FakeData.Users;
using StoreManager.SharedKernel.Mappings.Functions;
using StoreManager.SharedKernel.Mappings.Users;
using StoreManager.SharedKernel.ViewModels.Users;
using Xunit;

namespace StoreManager.Services.UnitTests.Services
{
    public class UserServiceTest
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly IUserService userService;
        private readonly List<User> users;

        public UserServiceTest()
        {
            mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<UserMappingProfile>();
                p.AddProfile<NewUserMappingProfile>();
                p.AddProfile<UpdateUserMappingProfile>();
                p.AddProfile<FunctionMappingProfile>();
            }).CreateMapper();

            userRepository = Substitute.For<IUserRepository>();
            userService = new UserService(userRepository, mapper);
            users = new UserDataFaker().Generate(new Faker().Random.Int(1, 100));
        }

        [Fact]
        public async Task UserInsertAsync()
        {
            //Given
            var user = users.First();
            var newUser = new NewUserDTO();
            newUser.Password = user.Password;
            var userDTO = mapper.Map<UserDTO>(user);

            userRepository.InsertAsync(Arg.Any<User>()).Returns(user.TypedClone());

            //When
            var result = await userService.InsertAsync(newUser);

            //Then
            await userRepository.Received().InsertAsync(Arg.Any<User>());
            result.Should().BeEquivalentTo(userDTO);
        }

        [Fact]
        public async Task UserUpdateAsync()
        {
            //Given
            var user = users.First();
            var updateUser = new UpdateUserDTO();
            updateUser.Password = user.Password;
            var userDTO = mapper.Map<UserDTO>(user);

            userRepository.UpdateAsync(Arg.Any<User>()).Returns(user.TypedClone());

            //When
            var result = await userService.UpdateUserAsync(updateUser);

            //Then
            await userRepository.Received().UpdateAsync(Arg.Any<User>());
            result.Should().BeEquivalentTo(userDTO);
        }

        [Fact]
        public async Task GetUserAsync()
        {
            //Given
            var user = users.First();
            var userDTO = mapper.Map<UserDTO>(user);
            userRepository.GetAsync(Arg.Any<int>()).Returns(user);

            //When
            var result = await userService.GetUserAsync(1);

            //Then
            await userRepository.Received().GetAsync(Arg.Any<int>());
            result.Should().BeEquivalentTo(userDTO);
        }

        [Fact]
        public async Task GetUserNotFoundAsync()
        {
            //Given            
            userRepository.GetAsync(Arg.Any<int>()).ReturnsNull();

            //When
            var result = await userService.GetUserAsync(1);

            //Then
            await userRepository.Received().GetAsync(Arg.Any<int>());
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetUsersAsync()
        {
            //Given
            var userListDTO = mapper.Map<List<UserDTO>>(users);
            userRepository.GetUsersAsync().Returns(users);

            //When
            var result = await userService.GetUsersAsync();

            //Then
            await userRepository.Received().GetUsersAsync();
            result.Should().BeEquivalentTo(userListDTO);
        }

        [Fact]
        public async Task GetUsersNotFoundAsync()
        {
            //Given            
            userRepository.GetUsersAsync().ReturnsNull();

            //When
            var result = await userService.GetUsersAsync();

            //Then
            await userRepository.Received().GetUsersAsync();
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task DeleteUser()
        {
            //Given
            var user = users.First();
            userRepository.GetAsync(Arg.Any<int>()).Returns(user);
            userRepository.UpdateAsync(Arg.Any<User>()).Returns(user);

            //When
            await userService.DeleteUserAsync(user.Id);

            //Then
            await userRepository.Received().GetAsync(Arg.Any<int>());
            await userRepository.Received().UpdateAsync(Arg.Any<User>());
        }

        [Fact]
        public async Task UnDeleteUser()
        {
            //Given
            var user = users.First();
            userRepository.GetAsync(Arg.Any<int>()).Returns(user);
            userRepository.UpdateAsync(Arg.Any<User>()).Returns(user);

            //When
            await userService.UndeleteUserAsync(user.Id);

            //Then
            await userRepository.Received().GetAsync(Arg.Any<int>());
            await userRepository.Received().UpdateAsync(Arg.Any<User>());
        }
    }
}