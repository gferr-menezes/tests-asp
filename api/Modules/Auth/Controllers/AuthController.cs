
using Api.Common.Middlewares;
using Api.Modules.Auth.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Modules.Auth.Controllers;

[ApiController]
[Authorize]
[Route("api/auth")]
public class AuthController : ControllerBase
{

    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<LoginResponseDto> Login([FromBody] LoginRequestDto loginRequestDto)
    {
       return await _service.DoLogin(loginRequestDto);
    }

    [ClaimsAuthorize("admin", "true")]
    [HttpGet("check-auth")]
    public string checkAuth()
    {
        return "ok";
    }
}