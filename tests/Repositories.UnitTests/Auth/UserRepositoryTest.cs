using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Core.Auth;
using Core.Auth.Interfaces;
using FluentAssertions;
using FakeData.Auth;
using Infrastructure.Context;
using Infrastructure.Repositories.Auth;
using Xunit;

namespace Repositories.UnitTests.Auth
{
    public sealed class UserRepositoryTest : IDisposable
    {
        private readonly IUserRepository userRepository;
        private readonly StoreContext context;
        private readonly UserDataFaker userDataFaker;

        public UserRepositoryTest()
        {
            context = InitializeMemoryContext.Initialize("UserRepositoryTest");
            userRepository = new UserRepository(context);
            userDataFaker = new UserDataFaker();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }

        [Fact]
        public async Task GetUserAsync()
        {

            //Given
            var users = await InsertUsersDataAsync();
            var user = users.FirstOrDefault();

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
            var result = await userRepository.GetUsersAsync();

            //Then
            result = result.ToList();
            result.Should().HaveCount(users.Count);
            result.Should().BeEquivalentTo(users);
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
            user = await userRepository.InsertAsync(user);

            var userId = user.Id;
            user = new UserDataFaker().Generate();
            user.Id = userId;
            
            //When
            var resultUser = await userRepository.UpdateAsync(user);

            //Then
            resultUser.Should().BeEquivalentTo(user);
        }

        private async Task<List<User>> InsertUsersDataAsync()
        {
            var listUsers = userDataFaker.Generate(new Faker().Random.Int(1, 100));
            listUsers.ForEach(x => x.Id = 0);

            await context.Users.AddRangeAsync(listUsers);
            await context.SaveChangesAsync();

            return listUsers;
        }
    }
}