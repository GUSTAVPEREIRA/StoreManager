using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManager.SharedKernel.ViewModels;

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

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FunctionDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFunctions()
        {
            var functions = await functionService.GetFunctionsAsync();

            if (functions.Any())
            {
                return Ok(functions);
            }

            return NotFound();
        }
    }
}