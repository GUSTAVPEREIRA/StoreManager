using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using FluentAssertions;
using StoreManager.Core.Domain;
using StoreManager.Core.Interfaces.Repositories;
using StoreManager.FakeData.Users;
using StoreManager.Infrastructure.Context;
using StoreManager.Infrastructure.Repositories;
using Xunit;

namespace StoreManager.Repositories.UnitTests.Repositories
{
    public class UserRepositoryTest : IDisposable
    {
        private readonly IUserRepository userRepository;
        private readonly StoreContext context;
        private readonly List<User> users;

        public UserRepositoryTest()
        {
            context = InitializeMemoryContext.Initialize();
            userRepository = new UserRepository(context);
            users = new UserDataFaker().Generate(new Faker().Random.Int(1, 100));            
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }

        [Fact]
        public async Task GetUserAsync()
        {
            //Given
            await InsertUsersAsync();
            var user = users.First();

            //When
            var foundUser = await userRepository.GetAsync(user.Id);

            //Then
            foundUser.Should().BeEquivalentTo(user);
        }

        [Fact]
        public async Task GetUsers()
        {
            //Given
            await InsertUsersAsync();

            //When
            var userList = await userRepository.GetUsersAsync();

            //Then
            userList.Should().BeEquivalentTo(users);
        }

        [Fact]
        public async Task InsertUserAsync()
        {
            //Given
            var user = users.First();

            //When
            var resultUser = await userRepository.InsertAsync(user);

            //Then
            resultUser.Should().BeEquivalentTo(user);
        }

        [Fact]
        public async Task UpdateUserAsync()
        {
            //Given
            var user = users.First();

            //When
            var resultUser = await userRepository.InsertAsync(user);

            //Then
            resultUser.Should().BeEquivalentTo(user);
        }

        private async Task InsertUsersAsync()
        {
            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }
}