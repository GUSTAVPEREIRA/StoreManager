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
    public sealed class FunctionRepositoryTest : IDisposable
    {
        private readonly IFunctionRepository functionRepository;
        private readonly StoreContext context;
        private readonly FunctionDataFaker functionDataFaker;

        public FunctionRepositoryTest()
        {
            context = InitializeMemoryContext.Initialize("FunctionRepositoryTest");
            functionRepository = new FunctionRepository(context);
            functionDataFaker = new FunctionDataFaker();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }

        [Fact]
        public async Task InsertFunctionOk()
        {
            //Given
            var function = functionDataFaker.Generate();

            //When
            var insertFunction = await functionRepository.InsertAsync(function);

            //Then
            insertFunction.Should().BeEquivalentTo(function);
        }

        [Fact]
        public async Task UpdateFunctionNotFound()
        {
            //Given                        
            var function = functionDataFaker.Generate();

            //When
            var updatedFunction = await functionRepository.UpdateAsync(function);

            //Then
            updatedFunction.Should().BeNull();
        }

        [Fact]
        public async Task UpdateFunctionOk()
        {
            //Given            
            var functions = await InsertFunctions();
            var functionId = functions.Select(x => x.Id).First();
            var function = new FunctionDataFaker(functionId).Generate();

            //When
            var updatedFunction = await functionRepository.UpdateAsync(function);

            //Then
            updatedFunction.Should().BeEquivalentTo(function);
        }

        [Fact]
        public async Task GetFunctions()
        {
            var functions = await InsertFunctions();

            var searchedFunctions = await functionRepository.GetFunctionsAsync();

            searchedFunctions.Should().BeEquivalentTo(functions);
        }

        [Fact]
        public async Task GetFunction()
        {
            var functions = await InsertFunctions();
            var function = functions.FirstOrDefault();

            var searchedFunction = await functionRepository.GetFunctionAsync(function.Id);

            searchedFunction.Should().BeEquivalentTo(function);
        }

        [Fact]
        public async Task GetFunctionNotFound()
        {
            var searchedFunction = await functionRepository.GetFunctionAsync(1);

            searchedFunction.Should().BeNull();
        }

        private async Task<List<Function>> InsertFunctions()
        {
            var functions = functionDataFaker.Generate(new Faker().PickRandom(1, 100));
            functions.ForEach(x => x.Id = 0);
            await context.Functions.AddRangeAsync(functions);

            await context.SaveChangesAsync();

            return functions;
        }

        [Fact]
        public async Task DeleteFunctionOk()
        {
            var functions = await InsertFunctions();
            var function = functions.First();

            var result = await functionRepository.DeleteFunctionAsync(function.Id);
            var functionDeleted = await functionRepository.GetFunctionAsync(function.Id);

            result.Should().BeEquivalentTo(function);
            functionDeleted.Should().BeNull();
        }

        [Fact]
        public async Task DeleteFunctionNotFound()
        {
            var functions = await InsertFunctions();
            var function = functions.First();

            var result = await functionRepository.DeleteFunctionAsync(-1);

            var functionDeleted = await functionRepository.GetFunctionAsync(function.Id);
            functionDeleted.Should().BeEquivalentTo(function);
            result.Should().BeNull();
        }
    }
}