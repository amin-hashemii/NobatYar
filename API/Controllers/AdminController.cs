using Application.Command.ChangeRole;
using Application.Common.Interface;
using Application.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")] 
public class AdminController : ControllerBase
{
   private readonly IAdminService  _adminService;

   public AdminController(IAdminService adminService)
   {
       _adminService = adminService;
   }

   [HttpPut("change-role")]
    public async Task<IActionResult> ChangeRole(ChangeRoleViewModel.ChangeRoleInput request)
    {
       await _adminService.UpdateRole(request);
        return Ok(new { message = "User role updated successfully." });
    }
}