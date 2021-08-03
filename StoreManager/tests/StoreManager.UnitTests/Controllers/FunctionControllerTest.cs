using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bogus;
using e.Interfaces.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using StoreManager.Core.Domain;
using StoreManager.Core.Interfaces.Repositories;
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
    }
}