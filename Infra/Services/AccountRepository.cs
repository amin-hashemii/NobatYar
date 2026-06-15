using Application.Common.Interface;
using Application.ViewModel;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Services;

public class AccountRepository : IAccountRepository
{
    
    private readonly AppDbContext _context;

    public AccountRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<AccountViewModel.MyProfileOutPut> GetAccount(string userid)
    {
        return await _context.Users.Where(a => a.Id == userid)
            .Select(u => new AccountViewModel.MyProfileOutPut
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Username = u.UserName,
            })
            .FirstOrDefaultAsync();
    }
    
}