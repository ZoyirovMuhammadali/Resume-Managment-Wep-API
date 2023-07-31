using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume_Managment_Wep_API.Core.Context;
using Resume_Managment_Wep_API.Core.Dtos.Candidate;
using Resume_Managment_Wep_API.Core.Entities;

namespace Resume_Managment_Wep_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CandidateConroller : ControllerBase
{
    private ApplicationDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public CandidateConroller(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    // Create
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateCandidate([FromForm] CandidateCreateDto dto, IFormFile pdfFile)
    {
        
        var fiveMegaByte = 5 * 1024 * 1024;
        var pdfMimeType = "application/pdf";

        if (pdfFile.Length > fiveMegaByte || pdfFile.ContentType != pdfMimeType)
        {
            return BadRequest("File is not valid");
        }

        var resumeUrl = Guid.NewGuid().ToString() + ".pdf";
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdfs", resumeUrl);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await pdfFile.CopyToAsync(stream);
        }
        var newCandidate = _mapper.Map<Candidate>(dto);
        newCandidate.ResumeUrl = resumeUrl;
        await _context.Candidates.AddAsync(newCandidate);
        await _context.SaveChangesAsync();

        return Ok("Candidate Saved Successfully");
    }

    [HttpGet]
    [Route("Get")]
    public async Task<ActionResult<IEnumerable<CandidateGetDto>>> GetCandidates()
    {
        var candidates = await _context.Candidates.Include(c => c.Job).OrderByDescending(q => q.CreatedAt).ToListAsync();
        var convertedCandidates = _mapper.Map<IEnumerable<CandidateGetDto>>(candidates);

        return Ok(convertedCandidates);
    }

    [HttpGet]
    [Route("download/{pdf}")]
    public IActionResult DownloadPdfFile(string url)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdfs", url);

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound("File Not Found");
        }

        var pdfBytes = System.IO.File.ReadAllBytes(filePath);
        var file = File(pdfBytes, "application/pdf", url);
        return file;
    }


}
