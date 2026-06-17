using Application.Common.Interface;
using Application.Service;
using Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "CanManageUsers")] 
public class CategoryController : ControllerBase
{
   private readonly ICategoryService _categoryService;

   public CategoryController(ICategoryService categoryService)
   {
      _categoryService = categoryService;
   }

   [HttpPost]
   public async Task<ActionResult> Create(CategoryViewModel.CreateCategoryInput category)
   {
    await  _categoryService.CreateCategory(category);
    return Ok();
   } 
   [HttpPut]
   public async Task<ActionResult> Update(CategoryViewModel.UpdateCategoryInput category)
   {
       await  _categoryService.UpdateCategory(category);
       return Ok();
   } 
   [HttpDelete]
   public async Task<ActionResult> Delete(int id)
   {
       await  _categoryService.DeleteCategory(id);
       return Ok();
   } 
   [HttpGet]
   public async Task<ActionResult<List<CategoryViewModel.GetAllCategoryOutput>>> GetAll()
   {
       var result = await  _categoryService.GetCategories();
       return Ok(result);
   } 
   [HttpGet("{id}")]
   public async Task<ActionResult<CategoryViewModel.GetAllCategoryOutput>> GetById(int id)
   {
      var result = await  _categoryService.GetCategoryById(id);
       return Ok(result);
   } 
   
   
   
}