using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume_Managment_Wep_API.Core.Context;
using Resume_Managment_Wep_API.Core.Dtos.Job;
using Resume_Managment_Wep_API.Core.Entities;

namespace Resume_Managment_Wep_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobController : ControllerBase
{
    private ApplicationDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public JobController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // Create
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateJob([FromBody] JobCreateDto dto)
    {
        var newJob = _mapper.Map<Job>(dto);
        await _context.Jobs.AddAsync(newJob);
        await _context.SaveChangesAsync();

        return Ok("Job Created Successfully");
    }

    [HttpGet]
    [Route("Get")]
    public async Task<ActionResult<IEnumerable<JobGetDto>>> GetJobs()
    {
        var jobs = await _context.Jobs.Include(job => job.Company).OrderByDescending(q => q.CreatedAt).ToListAsync();
        var convertdJobs = _mapper.Map<IEnumerable<JobGetDto>>(jobs);
         
        return Ok(convertdJobs);
    }
}
