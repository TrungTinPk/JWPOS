using JW.POS.User;
using JW.POS.User.Models;
using Microsoft.AspNetCore.Mvc;

namespace JW.POS.Web.Controllers
{
    public class AuthController : ApplicationBaseController
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin user)
        {
            var valid = await _userService.IsValidUserAccountAsync(user);

            if (valid)
            {
                var token = "";

                return Ok(token);
            }
            else
            {
                return BadRequest(new
                {
                    statusCode = "invalid_user_account"
                });
            }
        }
    }
}
