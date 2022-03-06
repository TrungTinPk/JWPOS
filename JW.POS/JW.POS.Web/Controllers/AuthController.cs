using JW.POS.User;
using JW.POS.User.Models;
using JW.POS.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace JW.POS.Web.Controllers
{
    public class AuthController : ApplicationBaseController
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin user)
        {
            var valid = await _userService.IsValidUserAccountAsync(user);

            if (valid)
            {
                var userToken = new UserToken();
                var token = _tokenService.GetToken(userToken, 0);

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
