using Domain.Model.Provider;
using Domain.Repository;
using Infra.Context;

namespace Infra.Repository;

public class ProviderRepository : Repository<Provider, AppDbContext>, IProviderRepository
{
    public ProviderRepository(AppDbContext db) : base(db)
    {
    }
}