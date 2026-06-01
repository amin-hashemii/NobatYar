using Domain.Enum;

namespace Application.ViewModel;

public class ChangeRoleViewModel
{
    public class ChangeRoleInput
    {
        public string UserId  { get; set; }
        public AppRole Role { get; set; }
    }
}