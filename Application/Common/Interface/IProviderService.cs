using Application.ViewModel;

namespace Application.Common.Interface;

public interface IProviderService
{
    Task CreateProvider(ProviderViewModel.CreateProviderInput input);
    Task DeleteProvider(int id);
    Task UpdateProvider(ProviderViewModel.UpdateProviderInput input);
    Task<List<ProviderViewModel.GetProviderOutput>> GetAllProviders();
    Task<ProviderViewModel.GetProviderOutput> GetProviderById(int id);
}