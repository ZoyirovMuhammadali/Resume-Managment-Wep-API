using Resume_Managment_Wep_API.Core.Enums;

namespace Resume_Managment_Wep_API.Core.Entities;

public class Company : BaseEntities
{
    public string Name { get; set; }
    public CompanySize Size { get; set; }
    public ICollection<Job> Jobs { get; set; }



}
