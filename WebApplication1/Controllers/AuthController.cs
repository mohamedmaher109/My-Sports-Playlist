using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySportsPlaylist.Application.DTOs.Auth;
using MySportsPlaylist.Application.Interfaces;
using MySportsPlaylist.Application.Models;
using System.Net;

namespace MySportsPlaylist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse<string>.FailResponse("Validation failed", (int)HttpStatusCode.BadRequest,
                    ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))));

            var result = await _userService.RegisterAsync(model);

            if (!result.IsSuccessful)
                return BadRequest(ApiResponse<string>.FailResponse("Registration failed", (int)HttpStatusCode.BadRequest, result.Errors));

            return Ok(ApiResponse<string>.SuccessResponse(null, (int)HttpStatusCode.OK, "User registered successfully"));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var result = await _userService.LoginAsync(model);

            if (!result.IsSuccessful)
                return Unauthorized(ApiResponse<string>.FailResponse(result.ErrorMessage, (int)HttpStatusCode.Unauthorized));

            return Ok(ApiResponse<string>.SuccessResponse(result.Token, (int)HttpStatusCode.OK, "Login successful"));
        }

    }
}
