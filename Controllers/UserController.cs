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
        // Cherche si un user existe avec l'email et le mdp renseigner
        User? personne =  _context.Users.FirstOrDefault(i => i.email == email && i.password == password);

        // si il n'y a aucun user 
        if(personne == null)
        {
            // on regarde si il existe un user avec le mail
            User? testemail = _context.Users.FirstOrDefault(i => i.email == email);

            // on regarde si il existe un user avec le mail
            User? testpassword = _context.Users.FirstOrDefault(i => i.password == password);

            Dictionary<string, string> erreur = new Dictionary<string, string>();
            erreur.Add("connexion", "false");

            // si il y a pas d'user avec se mail
            if(testemail == null)
            {
                // erreur mail
                erreur.Add("erreur", "Cette adresse mail n'existe pas !");
            }
            else
            {
                // si il existe un user avec ce mail on verifie le mdp
                if(testpassword == null)
                {
                    // si y en a pas erreur mdp
                    erreur.Add("erreur", "Ce mot de passe ne correspond pas à l'adresse mail saisie !");
                }
            }

            // renvoie l'erreur
            return Ok(erreur);
        }

        // on recup donnée de la relation many_to_many selon l'id de l'user trouvé
        var users = _context.Users
            .Include(x => x.skills)
                .ThenInclude(x => x.Skill)
            .Where(x => x.id == personne.id)
            .ToList();
        
        // format json car sinon impossible a lire les donénes
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

            if(valRecup.id_type_user == 1)
            {
                // on initialise un user filtrer sur etudiant
                StudentDto studentDto = new StudentDto();

                //on met dans le user filtrer les donées que l'on veut recup
                studentDto.connexion = true;
                studentDto.id = valRecup.id;
                studentDto.surname = valRecup.surname;
                studentDto.firstname = valRecup.firstname;
                studentDto.email = valRecup.email;
                studentDto.password = valRecup.password;
                studentDto.picture = valRecup.picture;
                studentDto.is_online = valRecup.is_online;

                Type_User? type_user = _context.Type_Users.FirstOrDefault(i => i.id == valRecup.id_type_user);
                studentDto.id_type_user = type_user;

                studentDto.description = valRecup.description;
                studentDto.web_site = valRecup.web_site;
                studentDto.cv = valRecup.cv;
                studentDto.cp = valRecup.cp;
                studentDto.city = valRecup.city;
                studentDto.birthday = valRecup.birthday;
                studentDto.is_conveyed = valRecup.is_conveyed;

                // pour les skills on créer un dictionnaire pour avoir les skills de type "id": "value"
                Dictionary<Int32, string> skillDico = new Dictionary<Int32, string>();

                foreach(Student_Skill skill in valRecup.skills)
                {
                    skillDico.Add(skill.Skill.id, skill.Skill.title);
                }

                studentDto.skills = skillDico;

                return Ok(studentDto);
            }
            else
            {
                // on initialise un user filtrer sur etudiant
                RecruiterDto recruiterDto = new RecruiterDto();

                //on met dans le user filtrer les donées que l'on veut recup
                recruiterDto.connexion = true;
                recruiterDto.id = valRecup.id;
                recruiterDto.surname = valRecup.surname;
                recruiterDto.firstname = valRecup.firstname;
                recruiterDto.email = valRecup.email;
                recruiterDto.password = valRecup.password;
                recruiterDto.picture = valRecup.picture;
                recruiterDto.is_online = valRecup.is_online;

                Type_User? type_user = _context.Type_Users.FirstOrDefault(i => i.id == valRecup.id_type_user);
                recruiterDto.id_type_user = type_user;

                Company? company = _context.Companies.FirstOrDefault(i => i.siren == valRecup.id_company);
                CompanyDto? companyDto = new CompanyDto();
                companyDto.siren = company.siren;
                companyDto.name = company.name;
                recruiterDto.company = companyDto;

                return Ok(recruiterDto);
            }
        }

        return Ok("Erreur");
    }
    
}