using Application.Common.Interface;
using Application.ViewModel;
using Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
//[Authorize(Policy = "CanManageAppointments")] 
public class ProviderController : ControllerBase
{
    private readonly IProviderService _providerService;

    public ProviderController(IProviderService providerService)
    {
        _providerService = providerService;
    }


    [HttpPost]
    public async Task<ActionResult> Create(ProviderViewModel.CreateProviderInput category)
    {
        await  _providerService.CreateProvider(category);
        return Ok();
    } 
    [HttpPut]
    public async Task<ActionResult> Update(ProviderViewModel.UpdateProviderInput category)
    {
        await  _providerService.UpdateProvider(category);
        return Ok();
    } 
    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        await  _providerService.DeleteProvider(id);
        return Ok();
    } 
    [HttpGet]
    public async Task<ActionResult<List<ProviderViewModel.GetProviderOutput>>> GetAll()
    {
        var result = await  _providerService.GetAllProviders();
        return Ok(result);
    } 
    [HttpGet("{id}")]
    public async Task<ActionResult<ProviderViewModel.GetProviderOutput>> GetById(int id)
    {
        var result = await  _providerService.GetProviderById(id);
        return Ok(result);
    } 

}