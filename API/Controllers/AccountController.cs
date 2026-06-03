using Application.Command.Account;
using Application.Common.Interface;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    
    private readonly ICurrentUserService _currentUserService;
    private readonly IAccountService _accountService;

    public AccountController(ICurrentUserService currentUserService, IAccountService accountService)
    {
        _currentUserService = currentUserService;
        _accountService = accountService;
    }

    [HttpGet("get")]
    public async Task<ActionResult<AccountViewModel.MyProfileOutPut>> Register()
    {
        var userid = _currentUserService.UserId;
        var result = await _accountService.GetMyProfile(userid);
        return Ok(result);
    }

    [HttpPut("change password")]
    public async Task<ActionResult> ChangePassword(AccountViewModel.ChangePassInput request)
    {
        await _accountService.UpdateMyProfile(request);
        return Ok("success");
    }
}