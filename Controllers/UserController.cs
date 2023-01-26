using ShippeeAPI.Context;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ShippeeAPI.Controllers;

[ApiController]
[Route(template:"api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<UserController> _logger;
    private readonly IMapper _mapper; 


    public UserController(ILogger<UserController> logger, ApplicationDbContext dbContext, IMapper mapper)
    {
        _logger = logger;
        _context = dbContext;
        _mapper = mapper;
    }


    [HttpGet("Student by mail/passWord")]
    public async Task<IActionResult> GetStudentByMailPassword(string email, string password)
    {
        User? user = _context.Users.FirstOrDefault(p => p.email == email && p.password == password);

        // List<Student_Skill> student_skills = await _context.Student_skills.Where(i => i.Userid == 1).ToListAsync();

        // List<Skill> skills = new List<Skill>();
        // foreach(Student_Skill skill_student in student_skills)
        // {
        //     Skill? newskills = _context.Skills.FirstOrDefault(p => p.id == skill_student.Skillid);
        //     skills.Add(newskills);
        //     return Ok(newskills);
        // }

        return Ok(user);
    }
    
}