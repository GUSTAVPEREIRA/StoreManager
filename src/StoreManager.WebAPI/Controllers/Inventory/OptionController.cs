using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManager.Core.Error;
using StoreManager.Core.Inventory.Interface;
using StoreManager.Core.Inventory.ViewModels;

namespace StoreManager.WebAPI.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly IOptionService optionService;

        public OptionController(IOptionService optionService)
        {
            this.optionService = optionService;
        }

        /// <summary>
        /// Alter one option
        /// </summary>
        /// <param name="optionDto"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(OptionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateOptionAsync(OptionDto optionDto)
        {
            var option = await optionService.UpdateOptionAsync(optionDto);

            if (option == null)
            {
                return NotFound();
            }

            return Ok(option);
        }


        /// <summary>
        /// Get one Option
        /// </summary>
        /// <param name="id" example="1"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OptionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            var option = await optionService.GetOptionAsync(id);

            if (option == null)
            {
                return NotFound();
            }

            return Ok(option);
        }

        /// <summary>
        /// Get All Options
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(OptionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var options = await optionService.GetOptionsAsync();

            if (!options.Any())
            {
                return NotFound();
            }

            return Ok(options);
        }

        /// <summary>
        /// Delete one Options
        /// </summary>
        /// <param name="id" example="2"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(OptionDto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteOptionAsync(int id)
        {
            await optionService.DeleteOptionAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Insert new option
        /// </summary>
        /// <param name="newOptionDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(OptionDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertOptionAsync(NewOptionDto newOptionDto)
        {
            var option = await optionService.InsertOptionAsync(newOptionDto);

            return CreatedAtAction(nameof(Get), new { option.Id }, option);
        }
    }
}