using Resume_Managment_Wep_API.Core.Enums;

namespace Resume_Managment_Wep_API.Core.Dtos.Job;

public class JobCreateDto
{
    public string Title { get; set; }
    public JobLevel Level { get; set; }
    public long CompanyId { get; set; }
}
