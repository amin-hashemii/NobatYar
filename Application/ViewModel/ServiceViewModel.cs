namespace Application.ViewModel;

public class ServiceViewModel
{
    public class CreateServiceInput
    {
        public int ProviderId { get;  set; }
        public string Title { get;  set; }
        public string Duration { get;  set; }
        public decimal Price { get;  set; }
    }
    public class UpdateServiceInput
    {
        public int Id { get;  set; }
        public int ProviderId { get;  set; }
        public string Title { get;  set; }
        public string Duration { get;  set; }
        public decimal Price { get;  set; }
    }
    public class GetAllService
    {
        public int Id { get;  set; }
        public int ProviderId { get;  set; }
        public string Title { get;  set; }
        public string Duration { get;  set; }
        public decimal Price { get;  set; }
    }
}