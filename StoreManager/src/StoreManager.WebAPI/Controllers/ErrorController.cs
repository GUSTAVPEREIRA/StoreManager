using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StoreManager.SharedKernel.ViewModels;

namespace StoreManager.WebAPI.Controllers
{

    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public ErrorResponse Error()
        {
            var contexto = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = contexto?.Error;

            Response.StatusCode = 500;
            var errorId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;

            return new ErrorResponse(errorId);
        }
    }
}