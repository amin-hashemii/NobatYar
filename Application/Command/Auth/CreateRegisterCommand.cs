using MediatR;

namespace Application.Command.Auth;

public class CreateRegisterCommand : IRequest<bool>
{
    public string Email{get;set;}
    public string UserName{get;set;}
    public string Password {get;set;}
    public string FirstName {get;set;}
    public string LastName {get;set;}
}