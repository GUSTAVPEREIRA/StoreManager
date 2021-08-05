using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using StoreManager.Application.Interfaces.Services;
using StoreManager.Application.Services;
using StoreManager.Core.Domain;
using StoreManager.Core.Interfaces.Repositories;
using StoreManager.Core.Mappings.Functions;
using StoreManager.FakeData.Users;
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
    }
}