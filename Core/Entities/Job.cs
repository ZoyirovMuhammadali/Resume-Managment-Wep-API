using Resume_Managment_Wep_API.Core.Enums;

namespace Resume_Managment_Wep_API.Core.Entities;

public class Job : BaseEntities
{
    public string Title { get; set; }
    public JobLevel Level { get; set; }
    public long CompanyId { get; set; }
    public Company Company { get; set; }
    public ICollection<Candidate> Candidates { get; set; }
}
