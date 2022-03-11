using JW.POS.User.Models;
using JW.POS.User.Services;
using JW.POS.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace JW.POS.Web.Controllers
{
    [ApiController]
    public class AuthController : ApplicationBaseController
    {
        private readonly IUserService _userService;
        private readonly ITokenGeneratorService _tokenService;
        public AuthController(IUserService userService, ITokenGeneratorService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var valid = await _userService.IsValidUserAccountAsync(user);

            if (valid)
            {
                var userInfo = await _userService.GetUserInfoAsync(user.UserName);
                var token = _tokenService.GetToken(userInfo, 0);

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
