using NetDevPack.Domain;

namespace Domain.Model.Category;

public class Category : BaseModel<int> , IAggregateRoot
{
    public string Name { get; private set; }
    public int? ParentId { get; private set; }
    public ICollection<Provider.Provider> Providers { get; set; } = new List<Provider.Provider>();

    public Category(string name, int? parentId)
    {
        Name = name;
        ParentId = parentId;
    }

    private Category()
    {
        
    }

    public void UpdateCategory(string name , int? parentId)
    {
        Name = name;
        ParentId = parentId;
    }
}
