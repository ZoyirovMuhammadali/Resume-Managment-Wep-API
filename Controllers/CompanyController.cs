using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume_Managment_Wep_API.Core.Context;
using Resume_Managment_Wep_API.Core.Dtos.Company;
using Resume_Managment_Wep_API.Core.Entities;

namespace Resume_Managment_Wep_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private ApplicationDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public CompanyController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    //Create 
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateCompany([FromBody] CompanyCreateDto dto)
    {
        Company newCompany = _mapper.Map<Company>(dto);

        if (newCompany == null)
        {
            return NotFound();
        }

        await _context.Companys.AddAsync(newCompany);
        await _context.SaveChangesAsync();

        return Ok("Companty Created Successfully");
    }
    [HttpGet]
    [Route("Get")]
    public async Task<ActionResult<IEnumerable<CompanyGetDto>>> GetCompanies()
    {
        var companies = await _context.Companys.OrderByDescending(q => q.CreatedAt).ToListAsync();
        var convertedCompanies = _mapper.Map<IEnumerable<CompanyGetDto>>(companies);

        return Ok(convertedCompanies);
    }



}
