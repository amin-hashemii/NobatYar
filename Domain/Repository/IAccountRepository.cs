using Domain.Model;

namespace Domain.Repository;

public interface IAccountRepository
{
    Task<ApplicationUser> GetAccount(string userid);
    
}