using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Auth.Interfaces;
using Core.Auth.ViewModels;
using Core.Error;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionController : ControllerBase
    {
        private readonly IFunctionService functionService;

        public FunctionController(IFunctionService functionService)
        {
            this.functionService = functionService;
        }

        /// <summary>
        /// Get all functions.
        /// </summary>        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FunctionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var functions = await functionService.GetFunctionsAsync();

            if (functions.Any())
            {
                return Ok(functions);
            }

            return NotFound();
        }

        /// <summary>
        /// Get one function by id.
        /// </summary>
        /// <param name="id" example="5"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FunctionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            var function = await functionService.GetFunctionAsync(id);

            if (function == null)
            {
                return NotFound();
            }

            return Ok(function);
        }


        /// <summary>
        /// Update one function.
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(FunctionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(UpdateFunctionDto function)
        {
            var foundFundction = await functionService.UpdateFunctionAsync(function);
            if (foundFundction is null)
            {
                return NotFound();
            }

            return Ok(foundFundction);
        }

        /// <summary>
        /// Inser new function.
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(FunctionDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NewFunctionDto function)
        {
            var insertedFunction = await functionService.InsertFunctionAsync(function);
            return CreatedAtAction(nameof(Get), new {insertedFunction.Id}, insertedFunction);
        }

        
        /// <summary>
        /// Delete one function by id.
        /// </summary>
        /// <param name="id" example="2"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await functionService.DeleteFunctionAsync(id);
            return NoContent();
        }
    }
}