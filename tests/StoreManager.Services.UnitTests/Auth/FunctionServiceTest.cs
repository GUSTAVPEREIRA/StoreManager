using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using StoreManager.Application.Auth.Services;
using StoreManager.Core.Auth.Interfaces;
using StoreManager.Core.Auth.ViewModels;
using StoreManager.FakeData.Auth;
using Xunit;
using AutoMapper;
using StoreManager.Application.Auth.Mappings;
using StoreManager.Core.Auth;

namespace StoreManager.Services.UnitTests.Auth
{
    public class FunctionServiceTest
    {
        private readonly IFunctionService service;
        private readonly IFunctionRepository repositoryMock;
        private readonly IMapper mapper;
        private readonly FunctionDataFaker functionFaker;
        private readonly Function function;
        private readonly NewFunctionDto newFunctionDto;
        private readonly UpdateFunctionDto updateFunctionDto;

        public FunctionServiceTest()
        {
            repositoryMock = Substitute.For<IFunctionRepository>();

            mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<FunctionMappingProfile>();
                p.AddProfile<NewFunctionMappingProfile>();
                p.AddProfile<UpdateFunctionMappingProfile>();
            }).CreateMapper();

            service = new FunctionService(repositoryMock, mapper);
            functionFaker = new FunctionDataFaker();
            var newFunctionDataFaker = new NewFunctionDataFaker();
            var updateFunctionDataFaker = new UpdateFunctionDataFaker();

            function = functionFaker.Generate();
            newFunctionDto = newFunctionDataFaker.Generate();
            updateFunctionDto = updateFunctionDataFaker.Generate();
        }

        [Fact]
        public async Task GetFunctionAsyncSuccess()
        {
            var functions = functionFaker.Generate(10);
            repositoryMock.GetFunctionsAsync().Returns(functions);
            var control = mapper.Map<IEnumerable<FunctionDto>>(functions);
            var result = await service.GetFunctionsAsync();

            await repositoryMock.Received().GetFunctionsAsync();
            result.Should().BeEquivalentTo(control);
        }

        [Fact]
        public async Task GetFunctionAsyncEmpty()
        {
            repositoryMock.GetFunctionsAsync().Returns(new List<Function>());

            var result = await service.GetFunctionsAsync();

            await repositoryMock.Received().GetFunctionsAsync();
            result.Should().BeEquivalentTo(new List<Function>());
        }

        [Fact]
        public async Task GetClientsAsyncNotFound()
        {
            repositoryMock.GetFunctionAsync(Arg.Any<int>()).Returns(new Function());
            var control = mapper.Map<FunctionDto>(new Function());
            var result = await service.GetFunctionAsync(1);

            await repositoryMock.Received().GetFunctionAsync(Arg.Any<int>());
            result.Should().BeEquivalentTo(control);
        }

        [Fact]
        public async Task InsertFunctionAsyncSuccess()
        {
            repositoryMock.InsertAsync(Arg.Any<Function>()).Returns(function);
            var control = mapper.Map<FunctionDto>(function);
            var result = await service.InsertFunctionAsync(newFunctionDto);

            await repositoryMock.Received().InsertAsync(Arg.Any<Function>());
            result.Should().BeEquivalentTo(control);
        }

        [Fact]
        public async Task UpdateFunctionAsyncSuccess()
        {
            repositoryMock.UpdateAsync(Arg.Any<Function>()).Returns(function);
            var control = mapper.Map<FunctionDto>(function);
            var result = await service.UpdateFunctionAsync(updateFunctionDto);

            await repositoryMock.Received().UpdateAsync(Arg.Any<Function>());
            result.Should().BeEquivalentTo(control);
        }

        [Fact]
        public async Task UpdateFunctionAsyncNotFound()
        {
            repositoryMock.UpdateAsync(Arg.Any<Function>()).ReturnsNull();
            var result = await service.UpdateFunctionAsync(updateFunctionDto);

            await repositoryMock.Received().UpdateAsync(Arg.Any<Function>());
            result.Should().BeNull();
        }

        [Fact]
        public async Task DeleteFunctionAsyncSuccess()
        {
            var functionDto = mapper.Map<FunctionDto>(function);
            repositoryMock.DeleteFunctionAsync(Arg.Any<int>()).Returns(function);

            var result = await service.DeleteFunctionAsync(functionDto.Id);

            await repositoryMock.Received().DeleteFunctionAsync(functionDto.Id);
            result.Should().BeEquivalentTo(functionDto);
        }

        [Fact]
        public async Task DeleteFunctionAsyncNotFoundAsync()
        {
            repositoryMock.DeleteFunctionAsync(Arg.Any<int>()).ReturnsNull();
            var functionDto = await service.DeleteFunctionAsync(function.Id);

            await repositoryMock.Received().DeleteFunctionAsync(function.Id);
            functionDto.Should().BeNull();
        }
    }
}