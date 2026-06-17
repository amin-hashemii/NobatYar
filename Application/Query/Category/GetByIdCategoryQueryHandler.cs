using Application.Configuration.Exceptions;
using Application.ViewModel;
using Domain.Repository;
using MediatR;

namespace Application.Query.Category;

public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryViewModel.GetAllCategoryOutput>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryViewModel.GetAllCategoryOutput> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
    {
        var result =  await _categoryRepository.GetAsync(request.Id);
        if (result == null)
            throw new MyApplicationException(ApplicationErrors.CategoryNotFound);
      return new CategoryViewModel.GetAllCategoryOutput
      {
          Id = result.Id,
          Name = result.Name,
          ParentId = result.ParentId,
      };
    }
}