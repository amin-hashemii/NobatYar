using Domain.Repository;
using MediatR;

namespace Application.Command.Category;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Domain.Model.Category.Category(request.Name, request.ParentId);
       await _categoryRepository.AddAsync(category);
      await  _categoryRepository.UnitOfWork.Commit();
      return Unit.Value;
    }
}