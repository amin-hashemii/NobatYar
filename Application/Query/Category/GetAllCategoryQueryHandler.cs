using Application.ViewModel;
using Domain.Repository;
using MediatR;

namespace Application.Query.Category;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery,List<CategoryViewModel.GetAllCategoryOutput>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryViewModel.GetAllCategoryOutput>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
    var result =  await  _categoryRepository.GetAllAsync();
    return result.Select(x=> new CategoryViewModel.GetAllCategoryOutput
    {
        Id = x.Id,
        Name = x.Name,
        ParentId = x.ParentId,
    }).ToList();
    }
}