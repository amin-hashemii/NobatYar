using NetDevPack.Domain;

namespace Domain.Model.Provider;

public class Provider : BaseModel<int> , IAggregateRoot
{
    public string UserId { get; private set; }
    public int CategoryId { get; private set; }
    public string Name { get; private set; }
    public string Bio { get; private set; }
    public string Address { get; private set; }
    
    public virtual ApplicationUser User { get; private set; }
    public virtual Category.Category Category { get; private set; }


    public Provider(string userId, int categoryId, string name, string bio, string address)
    {
        UserId = userId;
        CategoryId = categoryId;
        Name = name;
        Bio = bio;
        Address = address;
    }

    private Provider()
    {
        
    }

    public void Update(int categoryId, string name, string bio, string address)
    {
        CategoryId = categoryId;
        Name = name;
        Bio = bio;
        Address = address;
    }
}