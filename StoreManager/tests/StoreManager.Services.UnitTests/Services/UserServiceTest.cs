using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bogus;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using StoreManager.Application.Services;
using StoreManager.Core.Domain;
using StoreManager.Core.Interfaces.Repositories;
using StoreManager.Core.Interfaces.Services;
using StoreManager.Core.ViewModels.Users;
using StoreManager.FakeData.Users;
using StoreManager.SharedKernel.Mappings.Functions;
using StoreManager.SharedKernel.Mappings.Users;
using Xunit;

namespace StoreManager.Services.UnitTests.Services
{
    public class UserServiceTest
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepositoryMock;
        private readonly IJwtService jwtServiceMock;
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

            userRepositoryMock = Substitute.For<IUserRepository>();
            jwtServiceMock = Substitute.For<IJwtService>();

            userService = new UserService(userRepositoryMock, mapper, jwtServiceMock);
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

            userRepositoryMock.InsertAsync(Arg.Any<User>()).Returns(user.TypedClone());

            //When
            var result = await userService.InsertAsync(newUser);

            //Then
            await userRepositoryMock.Received().InsertAsync(Arg.Any<User>());
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

            userRepositoryMock.UpdateAsync(Arg.Any<User>()).Returns(user.TypedClone());

            //When
            var result = await userService.UpdateUserAsync(updateUser);

            //Then
            await userRepositoryMock.Received().UpdateAsync(Arg.Any<User>());
            result.Should().BeEquivalentTo(userDTO);
        }

        [Fact]
        public async Task GetUserAsync()
        {
            //Given
            var user = users.First();
            var userDTO = mapper.Map<UserDTO>(user);
            userRepositoryMock.GetAsync(Arg.Any<int>()).Returns(user);

            //When
            var result = await userService.GetUserAsync(1);

            //Then
            await userRepositoryMock.Received().GetAsync(Arg.Any<int>());
            result.Should().BeEquivalentTo(userDTO);
        }

        [Fact]
        public async Task GetUserNotFoundAsync()
        {
            //Given            
            userRepositoryMock.GetAsync(Arg.Any<int>()).ReturnsNull();

            //When
            var result = await userService.GetUserAsync(1);

            //Then
            await userRepositoryMock.Received().GetAsync(Arg.Any<int>());
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetUsersAsync()
        {
            //Given
            var userListDTO = mapper.Map<List<UserDTO>>(users);
            userRepositoryMock.GetUsersAsync().Returns(users);

            //When
            var result = await userService.GetUsersAsync();

            //Then
            await userRepositoryMock.Received().GetUsersAsync();
            result.Should().BeEquivalentTo(userListDTO);
        }

        [Fact]
        public async Task GetUsersNotFoundAsync()
        {
            //Given            
            userRepositoryMock.GetUsersAsync().ReturnsNull();

            //When
            var result = await userService.GetUsersAsync();

            //Then
            await userRepositoryMock.Received().GetUsersAsync();
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task DeleteUser()
        {
            //Given
            var user = users.First();
            userRepositoryMock.GetAsync(Arg.Any<int>()).Returns(user);
            userRepositoryMock.UpdateAsync(Arg.Any<User>()).Returns(user);

            //When
            await userService.DeleteUserAsync(user.Id);

            //Then
            await userRepositoryMock.Received().GetAsync(Arg.Any<int>());
            await userRepositoryMock.Received().UpdateAsync(Arg.Any<User>());
        }

        [Fact]
        public async Task UnDeleteUser()
        {
            //Given
            var user = users.First();
            userRepositoryMock.GetAsync(Arg.Any<int>()).Returns(user);
            userRepositoryMock.UpdateAsync(Arg.Any<User>()).Returns(user);

            //When
            await userService.UndeleteUserAsync(user.Id);

            //Then
            await userRepositoryMock.Received().GetAsync(Arg.Any<int>());
            await userRepositoryMock.Received().UpdateAsync(Arg.Any<User>());
        }
    }
}