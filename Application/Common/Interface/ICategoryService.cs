using Application.ViewModel;
using Domain.Model.Category;

namespace Application.Common.Interface;

public interface ICategoryService
{
    Task CreateCategory(CategoryViewModel.CreateCategoryInput input);
    Task DeleteCategory(int id);
    Task UpdateCategory(CategoryViewModel.UpdateCategoryInput input);
    Task<List<CategoryViewModel.GetAllCategoryOutput>> GetCategories();
    Task<CategoryViewModel.GetAllCategoryOutput> GetCategoryById(int id);
}