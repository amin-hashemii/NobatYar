using Application.Configuration.Exceptions;
using Domain.Repository;
using MediatR;

namespace Application.Command.Category;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetAsync(request.Id);
        if (category == null)
            throw new MyApplicationException(ApplicationErrors.CategoryNotFound);
        category.UpdateCategory(request.Name,request.ParentId);
        _categoryRepository.Update(category);
        await _categoryRepository.UnitOfWork.Commit();
        return Unit.Value;
    }
}