using Domain.Model.Services;
using Domain.Repository;
using Infra.Context;

namespace Infra.Repository;

public class ServiceRepository : Repository<Service,AppDbContext> , IServiceRepository
{
    public ServiceRepository(AppDbContext db) : base(db)
    {
    }
}
