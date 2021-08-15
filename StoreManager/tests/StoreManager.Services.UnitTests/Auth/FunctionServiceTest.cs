using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using StoreManager.Application.Auth.Services;
using StoreManager.Core.Domain;
using StoreManager.Core.Auth.Interfaces;
using StoreManager.Core.Auth.ViewModels;
using StoreManager.FakeData.Auth;
using Xunit;
using AutoMapper;
using StoreManager.Application.Auth.Mappings;

namespace StoreManager.Services.UnitTests.Auth
{
    public class FunctionServiceTest
    {
        private readonly IFunctionService service;
        private readonly IFunctionRepository repositoryMock;
        private readonly IMapper mapper;
        private readonly FunctionDataFaker functionFaker;
        private readonly NewFunctionDataFaker newFunctionDataFaker;
        private readonly UpdateFunctionDataFaker updateFunctionDataFaker;
        private readonly Function function;
        private readonly NewFunctionDTO newFunctionDTO;
        private readonly UpdateFunctionDTO updateFunctionDTO;

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
            newFunctionDataFaker = new NewFunctionDataFaker();
            updateFunctionDataFaker = new UpdateFunctionDataFaker();

            function = functionFaker.Generate();
            newFunctionDTO = newFunctionDataFaker.Generate();
            updateFunctionDTO = updateFunctionDataFaker.Generate();
        }

        [Fact]
        public async Task GetFunctionAsyncSuccess()
        {
            var listaFunctions = functionFaker.Generate(10);
            repositoryMock.GetFunctionsAsync().Returns(listaFunctions);
            var controle = mapper.Map<IEnumerable<FunctionDTO>>(listaFunctions);
            var retorno = await service.GetFunctionsAsync();

            await repositoryMock.Received().GetFunctionsAsync();
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task GetFunctionAsyncEmpty()
        {
            repositoryMock.GetFunctionsAsync().Returns(new List<Function>());

            var retorno = await service.GetFunctionsAsync();

            await repositoryMock.Received().GetFunctionsAsync();
            retorno.Should().BeEquivalentTo(new List<Function>());
        }

        [Fact]
        public async Task GetClientesAsyncNotFound()
        {
            repositoryMock.GetFunctionAsync(Arg.Any<int>()).Returns(new Function());
            var controle = mapper.Map<FunctionDTO>(new Function());
            var retorno = await service.GetFunctionAsync(1);

            await repositoryMock.Received().GetFunctionAsync(Arg.Any<int>());
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task InsertFunctionAsyncSuccess()
        {
            repositoryMock.InsertAsync(Arg.Any<Function>()).Returns(function);
            var controle = mapper.Map<FunctionDTO>(function);
            var retorno = await service.InsertFunctionAsync(newFunctionDTO);

            await repositoryMock.Received().InsertAsync(Arg.Any<Function>());
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task UpdateFunctionAsyncSuccess()
        {
            repositoryMock.UpdateAsync(Arg.Any<Function>()).Returns(function);
            var controle = mapper.Map<FunctionDTO>(function);
            var retorno = await service.UpdateFunctionAsync(updateFunctionDTO);

            await repositoryMock.Received().UpdateAsync(Arg.Any<Function>());
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task UpdateFunctionAsyncNaoEncontrado()
        {
            repositoryMock.UpdateAsync(Arg.Any<Function>()).ReturnsNull();
            var retorno = await service.UpdateFunctionAsync(updateFunctionDTO);

            await repositoryMock.Received().UpdateAsync(Arg.Any<Function>());
            retorno.Should().BeNull();
        }

        [Fact]
        public async Task DeleteFunctionAsyncSuccess()
        {
            var functionDTO = mapper.Map<FunctionDTO>(function);
            repositoryMock.DeleteFunctionAsync(Arg.Any<int>()).Returns(function);

            var result = await service.DeleteFunctionAsync(functionDTO.Id);

            await repositoryMock.Received().DeleteFunctionAsync(functionDTO.Id);
            result.Should().BeEquivalentTo(functionDTO);
        }

        [Fact]
        public async Task DeleteFunctionAsyncNaoEncontradoAsync()
        {
            repositoryMock.DeleteFunctionAsync(Arg.Any<int>()).ReturnsNull();
            var controle = mapper.Map<FunctionDTO>(function);
            var functionDTO = await service.DeleteFunctionAsync(function.Id);

            await repositoryMock.Received().DeleteFunctionAsync(function.Id);
            functionDTO.Should().BeNull();
        }
    }
}