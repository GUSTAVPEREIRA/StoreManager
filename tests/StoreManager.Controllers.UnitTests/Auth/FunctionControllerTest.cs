using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using StoreManager.Application.Auth.Mappings;
using StoreManager.Core.Auth.Interfaces;
using StoreManager.Core.Auth.ViewModels;
using StoreManager.FakeData.Auth;
using StoreManager.WebAPI.Controllers.Auth;
using Xunit;

namespace StoreManager.Controllers.UnitTests.Auth
{
    public class FunctionControllerTest
    {
        private readonly IFunctionService functionServiceMock;
        private readonly FunctionController functionController;
        private readonly List<FunctionDto> functionsDto;
        private readonly FunctionDto functionDto;

        public FunctionControllerTest()
        {
            functionServiceMock = Substitute.For<IFunctionService>();

            var mapper = new MapperConfiguration(p => { p.AddProfile<FunctionMappingProfile>(); }).CreateMapper();

            functionController = new FunctionController(functionServiceMock);
            var functions = new FunctionDataFaker().Generate(100);
            functionsDto = mapper.Map<List<FunctionDto>>(functions);
            functionDto = mapper.Map<FunctionDto>(new FunctionDataFaker().Generate());
        }

        [Fact]
        public async Task GetOkAsync()
        {
            //Given
            functionServiceMock.GetFunctionsAsync().Returns(functionsDto);

            //When
            var result = (ObjectResult) await functionController.Get();

            //Then
            await functionServiceMock.Received().GetFunctionsAsync();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task GetNotFound()
        {
            functionServiceMock.GetFunctionsAsync().Returns(new List<FunctionDto>());

            var result = (StatusCodeResult) await functionController.Get();

            await functionServiceMock.Received().GetFunctionsAsync();
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task GetByIdOk()
        {
            functionServiceMock.GetFunctionAsync(Arg.Any<int>()).Returns(functionDto);

            var result = (ObjectResult) await functionController.Get(functionDto.Id);

            await functionServiceMock.Received().GetFunctionAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task GetByIdNotFound()
        {
            functionServiceMock.GetFunctionAsync(Arg.Any<int>()).ReturnsNull();

            var result = (StatusCodeResult) await functionController.Get(1);

            await functionServiceMock.Received().GetFunctionAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task PostCreated()
        {
            functionServiceMock.InsertFunctionAsync(Arg.Any<NewFunctionDto>()).Returns(functionDto);

            var result = (ObjectResult) await functionController.Post(new NewFunctionDto());

            await functionServiceMock.Received().InsertFunctionAsync(Arg.Any<NewFunctionDto>());
            result.StatusCode.Should().Be(StatusCodes.Status201Created);
        }

        [Fact]
        public async Task DeleteNoContentAsync()
        {
            //Given
            functionServiceMock.DeleteFunctionAsync(Arg.Any<int>()).Returns(functionDto);

            //When
            var result = (StatusCodeResult) await functionController.Delete(1);

            //Then
            await functionServiceMock.Received().DeleteFunctionAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }

        [Fact]
        public async Task PutFunctionOkAsync()
        {
            //Given
            functionServiceMock.UpdateFunctionAsync(Arg.Any<UpdateFunctionDto>()).Returns(functionDto);

            //When
            var result = (ObjectResult) await functionController.Put(new UpdateFunctionDto());

            //Then
            await functionServiceMock.Received().UpdateFunctionAsync(Arg.Any<UpdateFunctionDto>());
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task PutFunctionNotFoundAsync()
        {
            //Given
            functionServiceMock.UpdateFunctionAsync(Arg.Any<UpdateFunctionDto>()).ReturnsNull();

            //When
            var result = (StatusCodeResult) await functionController.Put(new UpdateFunctionDto());

            //Then
            await functionServiceMock.Received().UpdateFunctionAsync(Arg.Any<UpdateFunctionDto>());
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
    }
}