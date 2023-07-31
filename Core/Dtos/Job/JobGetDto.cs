using Resume_Managment_Wep_API.Core.Entities;
using Resume_Managment_Wep_API.Core.Enums;

namespace Resume_Managment_Wep_API.Core.Dtos.Job;

public class JobGetDto
{
    public long ID { get; set; }
    public string Title { get; set; }
    public JobLevel Level { get; set; }
    public long CompanyId { get; set; }
    public string CompanyName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


 }
