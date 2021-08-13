using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManager.Core.Auth.Interfaces;
using StoreManager.Core.ViewModels;
using StoreManager.Core.Auth.ViewModels;

namespace StoreManager.WebAPI.Controllers
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
        /// Retorna todas as funções
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FunctionDTO>), StatusCodes.Status200OK)]
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
        /// Retorna uma função pelo ID
        /// </summary>
        /// <param name="id" example="5"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FunctionDTO), StatusCodes.Status200OK)]
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
        /// 
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(FunctionDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(UpdateFunctionDTO function)
        {
            var foundFundction = await functionService.UpdateFunctionAsync(function);
            if (foundFundction is null)
            {
                return NotFound();
            }

            return Ok(foundFundction);
        }

        [HttpPost]
        [ProducesResponseType(typeof(FunctionDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NewFunctionDTO function)
        {
            var insertedFunction = await functionService.InsertFunctionAsync(function);
            return CreatedAtAction(nameof(Get), new { Id = insertedFunction.Id }, insertedFunction);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await functionService.DeleteFunctionAsync(id);
            return NoContent();
        }
    }
}