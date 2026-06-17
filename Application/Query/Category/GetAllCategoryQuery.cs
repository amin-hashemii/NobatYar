using Application.ViewModel;
using MediatR;

namespace Application.Query.Category;

public class GetAllCategoryQuery : IRequest<List<CategoryViewModel.GetAllCategoryOutput>>
{
    
}