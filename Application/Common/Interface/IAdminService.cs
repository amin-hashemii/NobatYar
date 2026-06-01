using Application.ViewModel;

namespace Application.Common.Interface;

public interface IAdminService
{
    Task UpdateRole(ChangeRoleViewModel.ChangeRoleInput changeRoleInput);
}