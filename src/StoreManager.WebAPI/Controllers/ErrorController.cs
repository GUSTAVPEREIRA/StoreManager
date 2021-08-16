using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreManager.WebAPI.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;

            Response.StatusCode = 500;
            var errorId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;

            return new ObjectResult(new
            {
                exception?.Message,
                errorId,
                StatusCode = StatusCodes.Status500InternalServerError
            });
        }
    }
}