using Application.Common.Interface;
using Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("api/[controller]")]
[Authorize(Policy = "CanManageUsers")] 
public class ServiceController : ControllerBase
{
 private readonly IServiceService _service;

 public ServiceController(IServiceService service)
 {
  _service = service;
 }

 public async Task<IActionResult> Create(ServiceViewModel.CreateServiceInput input)
 {
  await _service.CreateService(input);
  return Ok();
 }
 public async Task<IActionResult> Update(ServiceViewModel.UpdateServiceInput input)
 {
  await _service.UpdateService(input);
  return Ok();
 }
 public async Task<IActionResult> delete(int id)
 {
  await _service.DeleteService(id);
  return Ok();
 }
}