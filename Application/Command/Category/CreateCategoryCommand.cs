using MediatR;

namespace Application.Command.Category;

public class CreateCategoryCommand : IRequest
{
    public string Name{get;set;}
    public int? ParentId{get;set;}
}