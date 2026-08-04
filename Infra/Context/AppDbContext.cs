using Domain.Model;
using Domain.Model.Category;
using Domain.Model.Provider;
using Domain.Model.Services;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;

namespace Infra.Context;

public class AppDbContext : IdentityDbContext<ApplicationUser> , IUnitOfWork
{
    private readonly IMediator _mediator;

    public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator) 
        : base(options)
    {
        _mediator = mediator;
    }

       public DbSet<ApplicationUser> ApplicationUsers { get; set; }
       public DbSet<Category> Categories { get; set; }
       public DbSet<Provider> Providers { get; set; }
       public DbSet<Service>  Services { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<bool> Commit()
    {
        return await SaveChangesAsync() > 0;
    }
}