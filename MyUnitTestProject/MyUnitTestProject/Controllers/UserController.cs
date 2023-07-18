using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyUnitTestProject.Service;

namespace MyUnitTestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult? GetUserByName(string name)
        {
            var result = _userService.GetUsersByName(name);
            if(result?.Count > 0)
            {
                return Ok(result);
            }
            return null;
        }
    }
}
