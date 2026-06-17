using MediatR;

namespace Application.Command.Category;

public class UpdateCategoryCommand : IRequest
{
    public int Id {get;set;}
    public string Name{get;set;}
    public int? ParentId{get;set;}
}