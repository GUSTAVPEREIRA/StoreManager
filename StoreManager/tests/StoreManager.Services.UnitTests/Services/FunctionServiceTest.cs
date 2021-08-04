using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using StoreManager.Application.Interfaces.Services;
using StoreManager.Application.Services;
using StoreManager.Core.Domain;
using StoreManager.Core.Interfaces.Repositories;
using StoreManager.Core.Mappings.Functions;
using StoreManager.FakeData.Functions;
using StoreManager.SharedKernel.ViewModels;
using Xunit;

namespace StoreManager.Services.UnitTests.Services
{
    public class FunctionServiceTest
    {
        private readonly IFunctionService service;
        private readonly IFunctionRepository repository;
        private readonly IMapper mapper;
        private readonly FunctionDataFaker functionFaker;
        private readonly NewFunctionDataFaker newFunctionDataFaker;
        private readonly UpdateFunctionDataFaker updateFunctionDataFaker;
        private readonly Function function;
        private readonly NewFunctionDTO newFunctionDTO;
        private readonly UpdateFunctionDTO updateFunctionDTO;

        public FunctionServiceTest()
        {
            repository = Substitute.For<IFunctionRepository>();

            mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<FunctionMappingProfile>();
                p.AddProfile<NewFunctionMappingProfile>();
                p.AddProfile<UpdateFunctionMappingProfile>();
            }).CreateMapper();

            service = new FunctionService(repository, mapper);
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
            repository.GetFunctionsAsync().Returns(listaFunctions);
            var controle = mapper.Map<IEnumerable<FunctionDTO>>(listaFunctions);
            var retorno = await service.GetFunctionsAsync();

            await repository.Received().GetFunctionsAsync();
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task GetFunctionAsyncEmpty()
        {
            repository.GetFunctionsAsync().Returns(new List<Function>());

            var retorno = await service.GetFunctionsAsync();

            await repository.Received().GetFunctionsAsync();
            retorno.Should().BeEquivalentTo(new List<Function>());
        }

        [Fact]
        public async Task GetClientesAsyncNotFound()
        {
            repository.GetFunctionAsync(Arg.Any<int>()).Returns(new Function());
            var controle = mapper.Map<FunctionDTO>(new Function());
            var retorno = await service.GetFunctionAsync(1);

            await repository.Received().GetFunctionAsync(Arg.Any<int>());
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task InsertFunctionAsyncSuccess()
        {
            repository.InsertAsync(Arg.Any<Function>()).Returns(function);
            var controle = mapper.Map<FunctionDTO>(function);
            var retorno = await service.InsertFunctionAsync(newFunctionDTO);

            await repository.Received().InsertAsync(Arg.Any<Function>());
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task UpdateFunctionAsyncSuccess()
        {
            repository.UpdateAsync(Arg.Any<Function>()).Returns(function);
            var controle = mapper.Map<FunctionDTO>(function);
            var retorno = await service.UpdateFunctionAsync(updateFunctionDTO);

            await repository.Received().UpdateAsync(Arg.Any<Function>());
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task UpdateFunctionAsyncNaoEncontrado()
        {
            repository.UpdateAsync(Arg.Any<Function>()).ReturnsNull();
            var retorno = await service.UpdateFunctionAsync(updateFunctionDTO);

            await repository.Received().UpdateAsync(Arg.Any<Function>());
            retorno.Should().BeNull();
        }

        [Fact]
        public async Task DeleteFunctionAsyncSuccess()
        {
            repository.DeleteFunctionAsync(Arg.Any<int>()).Returns(function);
            var controle = mapper.Map<FunctionDTO>(function);
            var functionDTO = await service.DeleteFunctionAsync(function.Id);

            await repository.Received().DeleteFunctionAsync(function.Id);
            functionDTO.Should().BeEquivalentTo(function);
        }

        [Fact]
        public async Task DeleteFunctionAsyncNaoEncontradoAsync()
        {
            repository.DeleteFunctionAsync(Arg.Any<int>()).ReturnsNull();
            var controle = mapper.Map<FunctionDTO>(function);
            var functionDTO = await service.DeleteFunctionAsync(function.Id);

            await repository.Received().DeleteFunctionAsync(function.Id);
            functionDTO.Should().BeNull();
        }
    }
}