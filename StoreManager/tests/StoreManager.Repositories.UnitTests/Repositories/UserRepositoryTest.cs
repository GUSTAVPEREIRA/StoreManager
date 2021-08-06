using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
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
        private readonly UserDataFaker userDataFaker;

        public UserRepositoryTest()
        {
            context = InitializeMemoryContext.Initialize();
            userRepository = new UserRepository(context);
            userDataFaker = new UserDataFaker();
        }

        [Fact]
        public async Task GetUserAsync()
        {

            //Given
            var users = await InsertUsersDataAsync();
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
            var users = await InsertUsersDataAsync();

            //When
            var userList = await userRepository.GetUsersAsync();

            //Then
            userList.Should().HaveCount(users.Count);
            userList.Should().BeEquivalentTo(users);
        }

        [Fact]
        public async Task InsertUserAsync()
        {
            //Given
            var user = new UserDataFaker().Generate();

            //When
            var resultUser = await userRepository.InsertAsync(user);

            //Then
            resultUser.Should().BeEquivalentTo(user);
        }

        [Fact]
        public async Task UpdateUserAsync()
        {
            //Given
            var user = new UserDataFaker().Generate();

            //When
            var resultUser = await userRepository.InsertAsync(user);

            //Then
            resultUser.Should().BeEquivalentTo(user);
        }

        void IDisposable.Dispose()
        {
            context.Database.EnsureDeleted();
        }

        private async Task<List<User>> InsertUsersDataAsync()
        {
            var listUsers = userDataFaker.Generate(new Faker().Random.Int(1, 100));
            listUsers.ForEach(x => x.Id = 0);

            await context.Users.AddRangeAsync(listUsers);
            await context.SaveChangesAsync();
            listUsers = await context.Users.ToListAsync();

            return listUsers;
        }
    }
}