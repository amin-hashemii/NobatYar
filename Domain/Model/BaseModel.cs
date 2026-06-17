using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model;

public class BaseModel <TPrimaryKey> 
{
    public TPrimaryKey Id { get; set; } = default!;

    public DateTime CreateDate { get; set; }

    public DateTime? ModifyDate { get; set; }

    public Guid CreatorUserId { get; set; }
}