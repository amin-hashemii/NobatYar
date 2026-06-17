using Application.ViewModel;
using MediatR;

namespace Application.Query.Category;

public class GetByIdCategoryQuery : IRequest<CategoryViewModel.GetAllCategoryOutput>
{
    public int Id { get; set; }
}