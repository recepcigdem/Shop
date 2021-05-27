using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController:Controller
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("login")]
        public ActionResult Login(string userName, string password)
        {
            var user = _userService.Login(userName, password);
            if (!user.Success)
            {
                return BadRequest(user.Message);
            }

            return Ok(user.Message);
        }
    }
}
