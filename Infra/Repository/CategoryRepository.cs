using Domain.Model.Category;
using Domain.Repository;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository;

public class CategoryRepository : Repository<Category,AppDbContext>, ICategoryRepository
{
    public CategoryRepository(AppDbContext db) : base(db) 
    {
        
    }
}