namespace Application.Configuration.Exceptions;

public class MyApplicationException : Exception
{
    public int ErroCode { get; }
    public string Details { get; }
    public string Name { get; }
    public IEnumerable<string>? Errors { get; }
    public MyApplicationException(ErrorCode error ,  IEnumerable<string>? errors = null) : base(error.Desc)
    {
        Details = error.Desc;
        ErroCode = error.Id;
        Name = error.Name;
        Errors = errors;
    }
}