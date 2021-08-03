using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using StoreManager.Core.Domain;
using StoreManager.Core.Interfaces.Repositories;
using StoreManager.FakeData.Functions;
using StoreManager.Infrastructure.Context;
using StoreManager.Infrastructure.Repositories;
using Xunit;

namespace StoreManager.UnitTests.Repositories.Functions
{
    public class FunctionRepositoryTest : IDisposable
    {        
        private readonly IFunctionRepository functionRepository;
        private readonly StoreContext context;
        private readonly FunctionDataFaker functionDataFaker;

        public FunctionRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
            optionsBuilder.UseInMemoryDatabase("DBTest");

            this.context = new StoreContext(optionsBuilder.Options);
            this.functionRepository = new FunctionRepository(context);
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
            var functions = await InsertDatas();
            var functionId = functions.Select(x => x.Id).FirstOrDefault();
            var function = new FunctionDataFaker(functionId).Generate();

            //When
            var updatedFunction = await functionRepository.UpdateAsync(function);

            //Then
            updatedFunction.Should().BeEquivalentTo(function);
        }

        [Fact]
        public async Task GetFunctions()
        {
            //Given
            var functions = await InsertDatas();

            //When
            var searchedFunctions = await functionRepository.GetFunctionsAsync();

            //Then
            searchedFunctions.Should().BeEquivalentTo(functions);
        }

        [Fact]
        public async Task GetFunction()
        {
            //Given
            var functions = await InsertDatas();
            var function = functions.FirstOrDefault();

            //When
            var searchedFunction = await functionRepository.GetFunctionAsync(function.Id);

            //Then
            searchedFunction.Should().BeEquivalentTo(function);
        }

        [Fact]
        public async Task GetFunctionNotFound()
        {                        
            //When
            var searchedFunction = await functionRepository.GetFunctionAsync(1);

            //Then
            searchedFunction.Should().BeNull();
        }

        private async Task<List<Function>> InsertDatas()
        {
            var functions = functionDataFaker.Generate(new Faker().PickRandom(1, 100));
            functions.ForEach(x => x.Id = 0);
            await context.Functions.AddRangeAsync(functions);

            await context.SaveChangesAsync();

            return functions;
        }
    }
}