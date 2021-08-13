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
using StoreManager.FakeData.Users;
using StoreManager.WebAPI.Controllers;
using Xunit;

namespace StoreManager.Controllers.UnitTests.Auth
{
    public class UserControllerTest
    {
        private readonly IUserService userServiceMock;
        private readonly UserController userController;
        private readonly List<UserDTO> userDTOs;

        public UserControllerTest()
        {
            userServiceMock = Substitute.For<IUserService>();
            userController = new UserController(userServiceMock);
            userDTOs = new UserDTODataFaker().Generate(new Faker().PickRandom(1, 100));
        }

        [Fact]
        public async Task GetUsersOkAsync()
        {
            //Given
            userServiceMock.GetUsersAsync().Returns(userDTOs);

            //When
            var result = (ObjectResult)await userController.Get();

            //Then
            await userServiceMock.Received().GetUsersAsync();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task GetUsersNotFoundAsync()
        {
            //Given
            userServiceMock.GetUsersAsync().Returns(new List<UserDTO>());

            //When
            var result = (StatusCodeResult)await userController.Get();

            //Then
            await userServiceMock.Received().GetUsersAsync();
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task GetUserOkAsync()
        {
            var userDTO = userDTOs.First();

            //Given
            userServiceMock.GetUserAsync(Arg.Any<int>()).Returns(userDTO);

            //When
            var result = (ObjectResult)await userController.Get(1);

            //Then
            await userServiceMock.Received().GetUserAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task GetUserNotFoundAsync()
        {
            var userDTO = userDTOs.First();

            //Given
            userServiceMock.GetUserAsync(Arg.Any<int>()).ReturnsNull();

            //When
            var result = (StatusCodeResult)await userController.Get(1);

            //Then
            await userServiceMock.Received().GetUserAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task PostUserCreatedAsync()
        {
            //Given
            var user = userDTOs.First();
            userServiceMock.InsertAsync(Arg.Any<NewUserDTO>()).Returns(user);

            //When
            var result = (ObjectResult)await userController.Post(new NewUserDTO());

            //Then
            await userServiceMock.Received().InsertAsync(Arg.Any<NewUserDTO>());
            result.StatusCode.Should().Be(StatusCodes.Status201Created);
        }

        [Fact]
        public async Task PutUserOkAsync()
        {
            //Given
            var user = userDTOs.First();
            userServiceMock.UpdateUserAsync(Arg.Any<UpdateUserDTO>()).Returns(user);

            //When
            var result = (ObjectResult)await userController.Put(new UpdateUserDTO());

            //Then
            await userServiceMock.Received().UpdateUserAsync(Arg.Any<UpdateUserDTO>());
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task PutUserNotFoundAsync()
        {
            //Given            
            userServiceMock.UpdateUserAsync(Arg.Any<UpdateUserDTO>()).ReturnsNull();

            //When
            var result = (StatusCodeResult)await userController.Put(new UpdateUserDTO());

            //Then
            await userServiceMock.Received().UpdateUserAsync(Arg.Any<UpdateUserDTO>());
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task DeleteUserNoContentAsync()
        {
            //Given            
            await userServiceMock.DeleteUserAsync(Arg.Any<int>());

            //When
            var result = (StatusCodeResult)await userController.Delete(1);

            //Then
            await userServiceMock.Received().DeleteUserAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }
    }
}