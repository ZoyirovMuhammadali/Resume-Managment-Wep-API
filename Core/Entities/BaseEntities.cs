using System.ComponentModel.DataAnnotations;

namespace Resume_Managment_Wep_API.Core.Entities;

public abstract class BaseEntities
{
    [Key]
    public long ID { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime updatedAt { get; set; } = DateTime.UtcNow;
    public bool isActive { get; set; } = true;



}
