using Domain.Model;

namespace Application.Common.Interface;

public interface ITokenService
{
    string CreateToken(ApplicationUser user, IList<string> roles);
}