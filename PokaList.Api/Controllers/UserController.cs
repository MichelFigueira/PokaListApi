using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokaList.Api.Extensions;
using PokaList.Application.Contracts;
using PokaList.Application.Dtos;
using System;
using System.Threading.Tasks;

namespace PokaList.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var userName = User.GetUserName();
                var user = await _userService.GetUserByUserNameAsync(userName);
                
                return Ok(user);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            try
            {
                if (await _userService.UserExists(userDto.UserName))
                    return BadRequest("User already exists!");

                var user = await _userService.CreateAccountAsync(userDto);
                if (user != null)
                    return Ok(new
                    {
                        userName = user.UserName,
                        name = user.Name,
                        token = _tokenService.CreateToken(user).Result
                    });

                return BadRequest("User not created!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLogin)
        {
            try
            {
                var user = await _userService.GetUserByUserNameAsync(userLogin.UserName);
                if (user == null) return Unauthorized("Invalid Username or Password!");

                var result = await _userService.CheckUserPasswordAsync(user, userLogin.Password);
                if (!result.Succeeded) return Unauthorized();

                return Ok(new
                {
                    userName = user.UserName,
                    name = user.Name,
                    token = _tokenService.CreateToken(user).Result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userUpdate)
        {
            try
            {
                if (userUpdate.UserName != User.GetUserName())
                    return Unauthorized("Invalid Username!");

                var user = await _userService.GetUserByUserNameAsync(User.GetUserName());
                if (user == null) return Unauthorized("Invalid Username!");

                var userReturn = await _userService.UpdateAccount(userUpdate);
                if (userReturn == null) return NoContent();

                return Ok(new
                {
                    userName = userReturn.UserName,
                    name = userReturn.Name,
                    token = _tokenService.CreateToken(userReturn).Result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }


    }
}
