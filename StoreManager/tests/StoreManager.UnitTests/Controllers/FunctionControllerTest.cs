using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using StoreManager.Core.Interfaces.Repositories;
using StoreManager.Core.Interfaces.Services;
using StoreManager.Core.Mappings.Functions;
using StoreManager.FakeData.Functions;
using StoreManager.SharedKernel.ViewModels;
using StoreManager.WebAPI.Controllers;
using Xunit;

namespace StoreManager.UnitTests.Controllers
{
    public class FunctionControllerTest
    {
        private readonly IMapper mapper;
        private readonly IFunctionService functionService;
        private readonly IFunctionRepository functionRepository;
        private readonly FunctionController functionController;
        private readonly List<FunctionDTO> functions;

        private readonly FunctionDTO functionDTO;

        public FunctionControllerTest()
        {
            functionService = Substitute.For<IFunctionService>();

            mapper = mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<FunctionMappingProfile>();
            }).CreateMapper();

            functionController = new FunctionController(functionService);
            var functions = new FunctionDataFaker().Generate(100);
            this.functions = mapper.Map<List<FunctionDTO>>(functions);
            functionDTO = mapper.Map<FunctionDTO>(new FunctionDataFaker().Generate());
        }

        [Fact]
        public async Task GetOkAsync()
        {
            //Given
            functionService.GetFunctionsAsync().Returns(functions);
            var controle = new List<FunctionDTO>();                        
            functions.ForEach(x => controle.Add(x.TypedClone()));            

            //When
            var result = (ObjectResult) await functionController.Get();

            //Then
            await functionService.Received().GetFunctionsAsync();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task GetNotFound()
        {
            functionService.GetFunctionsAsync().Returns(new List<FunctionDTO>());

            var resultado = (StatusCodeResult) await functionController.Get();

            await functionService.Received().GetFunctionsAsync();
            resultado.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task GetByIdOk()
        {
            functionService.GetFunctionAsync(Arg.Any<int>()).Returns(functionDTO.TypedClone());
            
            var resultado = (ObjectResult) await functionController.Get(functionDTO.Id);

            await functionService.Received().GetFunctionAsync(Arg.Any<int>());
            resultado.Value.Should().BeEquivalentTo(functionDTO);
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task GetByIdNotFound()
        {
            functionService.GetFunctionAsync(Arg.Any<int>()).ReturnsNull();

            var resultado = (ObjectResult) await functionController.Get(1);

            //await functionService.Received().GetFunctionAsync(1);
            resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task PostCreated()
        {
            functionService.InsertFunctionAsync(Arg.Any<NewFunctionDTO>()).Returns(functionDTO.TypedClone());

            var resultado = (ObjectResult) await functionController.Post(new NewFunctionDTO());

            await functionService.Received().InsertFunctionAsync(Arg.Any<NewFunctionDTO>());
            resultado.StatusCode.Should().Be(StatusCodes.Status201Created);
            resultado.Value.Should().BeEquivalentTo(functionDTO);
        }


    }
}