namespace Application.ViewModel;

public class LoginViewModel
{
    public class  LoginInput
    {
        public string UserName{get;set;}
        public string Password {get;set;}
    }
   public record LoginResponseDto(string Token, string UserName, string Email);
}