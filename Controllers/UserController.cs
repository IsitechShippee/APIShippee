using ShippeeAPI.Context;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        User? personne =  _context.Users.FirstOrDefault(i => i.email == email && i.password == password);

        var users = _context.Users
            .Include(x => x.skills)
                .ThenInclude(x => x.Skill)
            .Where(x => x.id == personne.id)
            .ToList();
            
        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        var json = System.Text.Json.JsonSerializer.Serialize(users, options);

        var jsonDoc = JsonDocument.Parse(json);
        var root = jsonDoc.RootElement;
        foreach (var user in root.EnumerateArray())
        {
            var valRecup = System.Text.Json.JsonSerializer.Deserialize<User>(user);

            StudentDto userDto = new StudentDto();
            userDto.id = valRecup.id;
            userDto.surname = valRecup.surname;
            userDto.firstname = valRecup.firstname;
            userDto.email = valRecup.email;
            userDto.password = valRecup.password;
            userDto.picture = valRecup.picture;
            userDto.is_online = valRecup.is_online;
            userDto.type_user = valRecup.type_user;
            userDto.description = valRecup.description;
            userDto.web_site = valRecup.web_site;
            userDto.cv = valRecup.cv;
            userDto.city = valRecup.city;
            userDto.birthday = valRecup.birthday;

            List<SkillDto> skillDto = new List<SkillDto>();

            foreach(Student_Skill skill in valRecup.skills)
            {
                SkillDto newSkill = new SkillDto();
                newSkill.id = skill.Skill.id;
                newSkill.title = skill.Skill.title;

                skillDto.Add(newSkill);
            }

            userDto.skills = skillDto;


            return Ok(userDto);
        }

        return Ok("erreur");
    }
    
}