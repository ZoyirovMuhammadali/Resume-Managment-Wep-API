using Resume_Managment_Wep_API.Core.Enums;

namespace Resume_Managment_Wep_API.Core.Dtos.Company;

public class CompanyCreateDto
{
    public string Name { get; set; }
    public CompanySize Size { get; set; }
}
