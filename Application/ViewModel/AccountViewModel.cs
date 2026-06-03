using System.Security.Claims;

namespace Application.ViewModel;

public class AccountViewModel
{
    public class MyProfileOutPut
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string Username { get; set; } = string.Empty;
    }
    public class ChangePassInput
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}