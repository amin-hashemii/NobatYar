using Application.ViewModel;
using AutoMapper;
using Domain.Model.Category;

namespace Application.Mapper;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryViewModel.GetAllCategoryOutput>().ReverseMap();
    }
}