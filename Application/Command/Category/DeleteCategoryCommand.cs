using MediatR;
using NetDevPack.SimpleMediator.Core.Interfaces;

namespace Application.Command.Category;

public class DeleteCategoryCommand : IRequest
{
    public int Id{get;set;}
}