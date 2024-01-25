using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Base;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}