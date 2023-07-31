using AutoMapper;
using Resume_Managment_Wep_API.Controllers;
using Resume_Managment_Wep_API.Core.Dtos.Candidate;
using Resume_Managment_Wep_API.Core.Dtos.Company;
using Resume_Managment_Wep_API.Core.Dtos.Job;
using Resume_Managment_Wep_API.Core.Entities;

namespace Resume_Managment_Wep_API.Core.AutoMapperConfig;

public class AutomapperConfigProfile : Profile
{
    public AutomapperConfigProfile()
    {
        // company
        CreateMap<CompanyCreateDto, Company>();
        CreateMap<Company, CompanyGetDto>();

        //job
        CreateMap<JobCreateDto, Job>();
        CreateMap<Job, JobGetDto>()
            .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));
        // candidate
        CreateMap<CandidateCreateDto, Candidate>();
        CreateMap<Candidate, CandidateGetDto>()
            .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.Job.Title));

    }
}
