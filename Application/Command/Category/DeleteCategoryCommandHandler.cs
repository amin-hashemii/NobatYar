using Application.Configuration.Exceptions;
using Domain.Repository;
using MediatR;

namespace Application.Command.Category;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetAsync(request.Id);
        if (category == null)
            throw new MyApplicationException(ApplicationErrors.CategoryNotFound);
        _categoryRepository.Remove(category);
        await  _categoryRepository.UnitOfWork.Commit();
        return Unit.Value;
    }
}