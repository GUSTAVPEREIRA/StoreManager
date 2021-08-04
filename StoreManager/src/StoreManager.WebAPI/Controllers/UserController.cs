using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreManager.Application.Interfaces.Services;

namespace StoreManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Get()
        {
            var functions = await userService.GetUsersAsync();

            if (functions.Any())
            {
                return Ok(functions);
            }

            return NotFound();
        }

        public async Task<IActionResult> Get(int id)
        {
            var user = await userService.GetUserAsync(id);

            if (user == null)
            {
                return NotFound();                
            }
            
            return Ok(user);
        }
    }
}