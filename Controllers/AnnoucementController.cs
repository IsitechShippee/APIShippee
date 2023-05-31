using ShippeeAPI.Context;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ShippeeAPI.Controllers;

[ApiController]
[Route(template: "api/[controller]")]
public class AnnoucementController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AnnoucementController> _logger;
    private readonly IMapper _mapper;


    public AnnoucementController(ILogger<AnnoucementController> logger, ApplicationDbContext dbContext, IMapper mapper)
    {
        _logger = logger;
        _context = dbContext;
        _mapper = mapper;
    }

    [HttpGet("listannouncement")]
    public async Task<IActionResult> GetAnnouncement()
    {
        List<Annoucement> annonce = await _context.Annoucements.Where(i => i.id_status == 2).ToListAsync();

        var _annonce = _mapper.Map<IEnumerable<AnnoucementStudentDto>>(annonce);

        return Ok(_annonce);
    }

}