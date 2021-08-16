using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using StoreManager.Core.Auth.Interfaces;
using StoreManager.Core.Auth.ViewModels;
using StoreManager.FakeData.Auth;
using StoreManager.WebAPI.Controllers.Auth;
using Xunit;

namespace StoreManager.Controllers.UnitTests.Auth
{
    public class UserControllerTest
    {
        private readonly UserController userController;
        private readonly List<UserDto> userDtos;
        private readonly IUserService userServiceMock;

        public UserControllerTest()
        {
            userServiceMock = Substitute.For<IUserService>();
            userController = new UserController(userServiceMock);
            userDtos = new UserDtoDataFaker().Generate(new Faker().PickRandom(1, 100));
        }

        [Fact]
        public async Task GetUsersOkAsync()
        {
            //Given
            userServiceMock.GetUsersAsync().Returns(userDtos);

            //When
            var result = (ObjectResult) await userController.Get();

            //Then
            await userServiceMock.Received().GetUsersAsync();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task GetUsersNotFoundAsync()
        {
            //Given
            userServiceMock.GetUsersAsync().Returns(new List<UserDto>());

            //When
            var result = (StatusCodeResult) await userController.Get();

            //Then
            await userServiceMock.Received().GetUsersAsync();
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task GetUserOkAsync()
        {
            var userDto = userDtos.First();

            //Given
            userServiceMock.GetUserAsync(Arg.Any<int>()).Returns(userDto);

            //When
            var result = (ObjectResult) await userController.Get(1);

            //Then
            await userServiceMock.Received().GetUserAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task GetUserNotFoundAsync()
        {
            //Given
            userServiceMock.GetUserAsync(Arg.Any<int>()).ReturnsNull();

            //When
            var result = (StatusCodeResult) await userController.Get(1);

            //Then
            await userServiceMock.Received().GetUserAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task PostUserCreatedAsync()
        {
            //Given
            var user = userDtos.First();
            userServiceMock.InsertAsync(Arg.Any<NewUserDto>()).Returns(user);

            //When
            var result = (ObjectResult) await userController.Post(new NewUserDto());

            //Then
            await userServiceMock.Received().InsertAsync(Arg.Any<NewUserDto>());
            result.StatusCode.Should().Be(StatusCodes.Status201Created);
        }

        [Fact]
        public async Task PutUserOkAsync()
        {
            //Given
            var user = userDtos.First();
            userServiceMock.UpdateUserAsync(Arg.Any<UpdateUserDto>()).Returns(user);

            //When
            var result = (ObjectResult) await userController.Put(new UpdateUserDto());

            //Then
            await userServiceMock.Received().UpdateUserAsync(Arg.Any<UpdateUserDto>());
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task PutUserNotFoundAsync()
        {
            //Given            
            userServiceMock.UpdateUserAsync(Arg.Any<UpdateUserDto>()).ReturnsNull();

            //When
            var result = (StatusCodeResult) await userController.Put(new UpdateUserDto());

            //Then
            await userServiceMock.Received().UpdateUserAsync(Arg.Any<UpdateUserDto>());
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task DeleteUserNoContentAsync()
        {
            //Given            
            await userServiceMock.DeleteUserAsync(Arg.Any<int>());

            //When
            var result = (StatusCodeResult) await userController.Delete(1);

            //Then
            await userServiceMock.Received().DeleteUserAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }

        [Fact]
        public async Task AuthenticateUserOk()
        {
            //Given
            userServiceMock.LoginIn(Arg.Any<BaseUserDto>()).Returns("eyap.xpasp,dmasodmamxoimasmxams");

            //When
            var result = (ObjectResult) await userController.Login(new BaseUserDto());

            //Then
            await userServiceMock.Received().LoginIn(Arg.Any<BaseUserDto>());
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task UnauthorizedUser()
        {
            userServiceMock.LoginIn(Arg.Any<BaseUserDto>()).Returns("");

            var result = (StatusCodeResult) await userController.Login(new BaseUserDto());

            await userServiceMock.Received().LoginIn(Arg.Any<BaseUserDto>());
            result.StatusCode.Should().Be(StatusCodes.Status401Unauthorized);
        }
    }
}