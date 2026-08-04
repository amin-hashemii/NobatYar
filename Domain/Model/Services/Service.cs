using NetDevPack.Domain;

namespace Domain.Model.Services;

public class Service : BaseModel<int> , IAggregateRoot
{
    public int ProviderId { get; private set; }
    public string Title { get; private set; }
    public string Duration { get; private set; }
    public decimal Price { get; private set; }
    public Provider.Provider provider { get; private set; }

    public Service(int providerId, string title, string duration, decimal price)
    {
        ProviderId = providerId;
        Title = title;
        Duration = duration;
        Price = price;
    }
    private  Service() { }

    public void UpdateService(int providerId , string title , string duration , decimal price)
    {
        Title = title;
        Duration = duration;
        Price = price;
        ProviderId = providerId;
    }
}