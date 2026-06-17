using Microsoft.AspNetCore.Identity;

namespace Domain.Model;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public ICollection<Provider.Provider> Providers { get; set; } = new List<Provider.Provider>();
}