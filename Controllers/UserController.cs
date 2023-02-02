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
            
            if(valRecup != null)
            {
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
                    studentDto.picture = valRecup.picture;
                    studentDto.is_online = valRecup.is_online;

                    Type_User? type_user = _context.Type_Users.FirstOrDefault(i => i.id == valRecup.id_type_user);
                    studentDto.type_user = type_user;

                    studentDto.description = valRecup.description;
                    studentDto.web_site = valRecup.web_site;
                    studentDto.cv = valRecup.cv;
                    studentDto.cp = valRecup.cp;
                    studentDto.city = valRecup.city;
                    studentDto.birthday = valRecup.birthday;
                    studentDto.is_conveyed = valRecup.is_conveyed;

                    // pour les skills on créer un dictionnaire pour avoir les skills de type "id": "value"
                    Dictionary<Int32, string> skillDico = new Dictionary<Int32, string>();

                    if(valRecup.skills != null)
                    {
                        foreach(Student_Skill skill in valRecup.skills)
                        {
                            if(skill.Skill != null)
                            {
                                skillDico.Add(skill.Skill.id, skill.Skill.title!);
                            }
                        }
                    }

                    studentDto.skills = skillDico;

                    List<Annoucement>? annonce = await _context.Annoucements.Where(a => a.id_user == valRecup.id).ToListAsync();
                    List<AnnoucementStudentDto> annonceDto = _mapper.Map<List<AnnoucementStudentDto>>(annonce);
                    
                    foreach(Annoucement pseudoannonce in annonce)
                    {
                        Annoucement_State? state = _context.Annoucement_Status.FirstOrDefault(i => i.id == pseudoannonce.id_status);
                        Naf_Division? naf_div = _context.Naf_Divisions.FirstOrDefault(n => n.id == pseudoannonce.id_naf_division);
                        Job? job = _context.Jobs.FirstOrDefault(j => j.id == pseudoannonce.id_job);

                        foreach(AnnoucementStudentDto dtoAnn in annonceDto)
                        {
                            if(dtoAnn.id == pseudoannonce.id)
                            {
                                dtoAnn.status = state;
                                if(naf_div != null)
                                {
                                    dtoAnn.naf_division_title = naf_div.title;
                                }
                                if(job != null)
                                {
                                    dtoAnn.job_title = job.title;
                                }
                                
                            }
                        }
                    }

                    studentDto.annonce = annonceDto;

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
                    recruiterDto.picture = valRecup.picture;
                    recruiterDto.is_online = valRecup.is_online;

                    Type_User? type_user = _context.Type_Users.FirstOrDefault(i => i.id == valRecup.id_type_user);
                    recruiterDto.id_type_user = type_user;

                    Company? company = _context.Companies.FirstOrDefault(i => i.siren == valRecup.id_company);
                    CompanyDto? companyDto = _mapper.Map<CompanyDto>(company);

                    recruiterDto.company = companyDto;

                    var qualification = _context.Annoucements
                        .Include(x => x.skills)
                            .ThenInclude(x => x.Skill)
                        .Where(x => x.id_user == valRecup.id)
                        .ToList();
                    
                    // format json car sinon impossible a lire les donénes
                    var options2 = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.IgnoreCycles
                    };

                    var json2 = System.Text.Json.JsonSerializer.Serialize(qualification, options2);

                    var jsonDoc2 = JsonDocument.Parse(json2);
                    var root2 = jsonDoc2.RootElement;

                    List<AnnoucementRecruiterDto>? listAnnonceRecruiter = new List<AnnoucementRecruiterDto>();

                    foreach (var qualif in root2.EnumerateArray())
                    {
                        var valRecupQualif = System.Text.Json.JsonSerializer.Deserialize<Annoucement>(qualif);

                        if(valRecupQualif != null)
                        {
                            AnnoucementRecruiterDto? annonceRecruiter = new AnnoucementRecruiterDto();
                            annonceRecruiter.id = valRecupQualif.id;
                            annonceRecruiter.title = valRecupQualif.title;
                            annonceRecruiter.description = valRecupQualif.description;
                            annonceRecruiter.publish_date = valRecupQualif.publish_date;

                            Annoucement_State? state = _context.Annoucement_Status.FirstOrDefault(s => s.id == valRecupQualif.id_status);
                            annonceRecruiter.status = state;
                            
                            Naf_Division? naf_div = _context.Naf_Divisions.FirstOrDefault(naf => naf.id == valRecupQualif.id_naf_division);
                            if(naf_div != null)
                            {
                                annonceRecruiter.naf_division_title = naf_div.title;
                            }

                            Job? job = _context.Jobs.FirstOrDefault(job => job.id == valRecupQualif.id_job);
                            if(job != null)
                            {
                                annonceRecruiter.job_title = job.title;
                            }

                            // pour les skills on créer un dictionnaire pour avoir les skills de type "id": "value"
                            Dictionary<Int32, string> skillDico = new Dictionary<Int32, string>();

                            if(valRecupQualif.skills != null)
                            {
                                foreach(Qualification skill in valRecupQualif.skills)
                                {
                                    if(skill.Skill != null)
                                    {
                                        skillDico.Add(skill.Skill.id, skill.Skill.title!);
                                    }
                                }
                            }
                            
                            if(skillDico != null)
                            {
                                annonceRecruiter.qualifications = skillDico;
                            }
                            
                            listAnnonceRecruiter.Add(annonceRecruiter);
                        }
                    }

                    recruiterDto.annonce = listAnnonceRecruiter;

                    return Ok(recruiterDto);
                }
            }
        }

        return Ok("Erreur");
    }
    
}