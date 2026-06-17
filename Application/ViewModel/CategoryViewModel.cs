namespace Application.ViewModel;

public class CategoryViewModel
{
    public class CreateCategoryInput
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
    public class UpdateCategoryInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
    public class GetAllCategoryOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}