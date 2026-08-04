using Application.ViewModel;

namespace Application.Common.Interface;

public interface IServiceService
{
    Task CreateService(ServiceViewModel.CreateServiceInput input);
    Task DeleteService(int id);
    Task UpdateService(ServiceViewModel.UpdateServiceInput input);
    Task<List<ServiceViewModel.GetAllService>> GetService();
    Task<ServiceViewModel.GetAllService> GetServiceById(int id);
}