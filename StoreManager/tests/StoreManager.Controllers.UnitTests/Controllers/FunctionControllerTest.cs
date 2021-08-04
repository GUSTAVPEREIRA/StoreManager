using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using StoreManager.Application.Interfaces.Services;
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
        private readonly IFunctionService functionServiceMock;
        private readonly FunctionController functionController;
        private readonly List<FunctionDTO> functions;
        private readonly FunctionDTO functionDTO;

        public FunctionControllerTest()
        {
            functionServiceMock = Substitute.For<IFunctionService>();

            mapper = mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<FunctionMappingProfile>();
            }).CreateMapper();

            functionController = new FunctionController(functionServiceMock);
            var functions = new FunctionDataFaker().Generate(100);
            this.functions = mapper.Map<List<FunctionDTO>>(functions);
            functionDTO = mapper.Map<FunctionDTO>(new FunctionDataFaker().Generate());
        }

        [Fact]
        public async Task GetOkAsync()
        {
            //Given
            functionServiceMock.GetFunctionsAsync().Returns(functions);

            //When
            var result = (ObjectResult)await functionController.Get();

            //Then
            await functionServiceMock.Received().GetFunctionsAsync();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task GetNotFound()
        {
            functionServiceMock.GetFunctionsAsync().Returns(new List<FunctionDTO>());

            var result = (StatusCodeResult)await functionController.Get();

            await functionServiceMock.Received().GetFunctionsAsync();
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task GetByIdOk()
        {
            functionServiceMock.GetFunctionAsync(Arg.Any<int>()).Returns(functionDTO);

            var result = (ObjectResult)await functionController.Get(functionDTO.Id);

            await functionServiceMock.Received().GetFunctionAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status200OK);            
        }

        [Fact]
        public async Task GetByIdNotFound()
        {
            functionServiceMock.GetFunctionAsync(Arg.Any<int>()).ReturnsNull();

            var result = (StatusCodeResult)await functionController.Get(1);

            await functionServiceMock.Received().GetFunctionAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task PostCreated()
        {
            functionServiceMock.InsertFunctionAsync(Arg.Any<NewFunctionDTO>()).Returns(functionDTO);

            var result = (ObjectResult)await functionController.Post(new NewFunctionDTO());

            await functionServiceMock.Received().InsertFunctionAsync(Arg.Any<NewFunctionDTO>());
            result.StatusCode.Should().Be(StatusCodes.Status201Created);
        }

        [Fact]
        public async Task DeleteNoContentAsync()
        {
            //Given
            functionServiceMock.DeleteFunctionAsync(Arg.Any<int>()).Returns(functionDTO);

            //When
            var result = (StatusCodeResult)await functionController.Delete(1);

            //Then
            await functionServiceMock.Received().DeleteFunctionAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }

        [Fact]
        public async Task PutFunctionOkAsync()
        {
            //Given
            functionServiceMock.UpdateFunctionAsync(Arg.Any<UpdateFunctionDTO>()).Returns(functionDTO);

            //When
            var result = (ObjectResult)await functionController.Put(new UpdateFunctionDTO());

            //Then
            await functionServiceMock.Received().UpdateFunctionAsync(Arg.Any<UpdateFunctionDTO>());
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task PutFunctionNotFoundAsync()
        {
            //Given
            functionServiceMock.UpdateFunctionAsync(Arg.Any<UpdateFunctionDTO>()).ReturnsNull();

            //When
            var result = (StatusCodeResult)await functionController.Put(new UpdateFunctionDTO());

            //Then
            await functionServiceMock.Received().UpdateFunctionAsync(Arg.Any<UpdateFunctionDTO>());
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
    }
}