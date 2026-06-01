using Application.Common.Interface;
using Application.ViewModel;
using Domain.Model;
using Infra;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
   private readonly IAuthService _authService;

   public AuthController(IAuthService authService)
   {
       _authService = authService;
   }

   [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterViewModel.RegisterInput registerDto)
    {
        await _authService.Register(registerDto);
        return Ok(new { Message = "User registered successfully!" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginViewModel.LoginInput loginDto)
    {
       var result = await _authService.Login(loginDto);
        return Ok(result);
    }
    
}
    