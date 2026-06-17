namespace Application.ViewModel;

public class ProviderViewModel
{
    public class CreateProviderInput
    {
        public string UserId { get; set; }
        public int CategoryId { get;  set; }
        public string Name { get;  set; }
        public string Bio { get;  set; }
        public string Address { get;  set; }
    }
    public class UpdateProviderInput
    {
        public int Id { get;  set; }
        public int CategoryId { get;  set; }
        public string Name { get;  set; }
        public string Bio { get;  set; }
        public string Address { get;  set; }
    }
    public class GetProviderOutput
    { 
        public string UserId { get;  set; }
        public int CategoryId { get;  set; }
        public string Name { get;  set; }
        public string Bio { get;  set; }
        public string Address { get;  set; }
    }
}