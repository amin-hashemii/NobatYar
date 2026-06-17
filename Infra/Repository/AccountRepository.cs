using Domain.Model;
using Domain.Repository;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository;

public class AccountRepository : IAccountRepository
{
    
    private readonly AppDbContext _context;

    public AccountRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<ApplicationUser> GetAccount(string userid)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Id == userid);
    }
}