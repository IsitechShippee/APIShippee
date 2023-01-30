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


    [HttpGet("testconnect")]
    public async Task<IActionResult> GetStudentByMailPassword(string email, string password)
    {
        User? personne =  _context.Users.FirstOrDefault(i => i.email == email && i.password == password);

        if(personne == null)
        {
            User? testemail = _context.Users.FirstOrDefault(i => i.email == email);
            User? testpassword = _context.Users.FirstOrDefault(i => i.password == password);

            Dictionary<string, string> erreur = new Dictionary<string, string>();
            erreur.Add("connexion", "false");

            if(testemail == null)
            {
                erreur.Add("erreur", "Cette adresse mail n'existe pas !");
            }
            else
            {
                if(testpassword == null)
                {
                    erreur.Add("erreur", "Ce mot de passe ne correspond pas à l'adresse mail saisie !");
                }
            }

            return Ok(erreur);
        }

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
            userDto.connexion = true;
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
            userDto.cp = valRecup.cp;
            userDto.city = valRecup.city;
            userDto.birthday = valRecup.birthday;
            userDto.is_conveyed = valRecup.is_conveyed;

            Dictionary<Int32, string> skillDto = new Dictionary<Int32, string>();

            foreach(Student_Skill skill in valRecup.skills)
            {
                skillDto.Add(skill.Skill.id, skill.Skill.title);
            }

            userDto.skills = skillDto;


            return Ok(userDto);
        }

        return Ok("erreur");
    }
    
}