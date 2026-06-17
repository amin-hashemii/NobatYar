using Application.Command.Category;
using Application.Common.Interface;
using Application.Query.Category;
using Application.ViewModel;
using MediatR;

namespace Application.Service;

public class CategoryService:ICategoryService
{
    private readonly IMediator _mediator;

    public CategoryService(IMediator mediator)
    {
        _mediator = mediator;
    }
             
    public async Task CreateCategory(CategoryViewModel.CreateCategoryInput input)
    {
     await  _mediator.Send(new CreateCategoryCommand()
        {
            Name = input.Name, 
            ParentId = input.ParentId
        });
    }

    public async Task DeleteCategory(int id)
    {
        await _mediator.Send(new DeleteCategoryCommand()
        {
            Id = id
        });
    }

    public async Task UpdateCategory(CategoryViewModel.UpdateCategoryInput input)
    {
        await _mediator.Send(new UpdateCategoryCommand()
        {
            Id = input.Id,
            Name = input.Name,
            ParentId = input.ParentId
        });
    }

    public async Task<List<CategoryViewModel.GetAllCategoryOutput>> GetCategories()
    {
       var result =  await _mediator.Send(new GetAllCategoryQuery()
        {
        });
        return result;
    }

    public async Task<CategoryViewModel.GetAllCategoryOutput> GetCategoryById(int id)
    {
        var result = await _mediator.Send(new GetByIdCategoryQuery()
        {
            Id = id
        });
        return result;
    }
}