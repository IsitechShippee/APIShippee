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

        // on initialise un user filtrer sur etudiant
        StudentDto student = new StudentDto();

        // on initialise un user filtrer sur recruteur
        RecruiterDto recruiter = new RecruiterDto();

        if(personne.id_type_user == 1)
        {
            //on met dans le user filtrer les donées que l'on veut recup
            student.connexion = true;
            student.id = personne.id;
            student.surname = personne.surname;
            student.firstname = personne.firstname;
            student.email = personne.email;
            student.picture = personne.picture;
            student.is_online = personne.is_online;
            
            Type_User? type_user = _context.Type_Users.FirstOrDefault(i => i.id == personne.id_type_user);
            student.type_user = type_user;

            student.description = personne.description;
            student.web_site = personne.web_site;
            student.cv = personne.cv;
            student.cp = personne.cp;
            student.city = personne.city;
            student.birthday = personne.birthday;
            student.is_conveyed = personne.is_conveyed;

            // on recup donnée de la relation many_to_many selon l'id de l'user trouvé
            var users = _context.Users
                .Include(x => x.skills)
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
                    // pour les skills on créer un dictionnaire pour avoir les skills de type "id": "value"
                    Dictionary<Int32, string> skillDico = new Dictionary<Int32, string>();

                    if(valRecup.skills != null)
                    {
                        foreach(Student_Skill skill in valRecup.skills)
                        {
                            if(skill != null)
                            {
                                Skill? skillss = _context.Skills.FirstOrDefault(s => s.id == skill.id_skill);
                                if(skillss != null)
                                {
                                    skillDico.Add(skillss.id, skillss.title);
                                }
                            }
                        }
                    }
                    student.skills = skillDico;
                }
            }

            List<Annoucement>? annonce = await _context.Annoucements.Where(a => a.id_user == personne.id).ToListAsync();
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

            student.annoucements = annonceDto;

            var favoris = _context.Users
                .Include(x => x.favorites_annoucements)
                .Where(x => x.id == personne.id)
                .ToList();
            
            // format json car sinon impossible a lire les donénes
            var options2 = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            var json2 = System.Text.Json.JsonSerializer.Serialize(favoris, options2);
            var jsonDoc2 = JsonDocument.Parse(json2);
            var root2 = jsonDoc2.RootElement;

            foreach (var user in root2.EnumerateArray())
            {
                var valRecup = System.Text.Json.JsonSerializer.Deserialize<User>(user);

                if(valRecup != null)
                {
                    // pour les skills on créer un dictionnaire pour avoir les skills de type "id": "value"
                    List<AnnoucementFavoriteRecruiterDto> favorieDico = new List<AnnoucementFavoriteRecruiterDto>();

                    if(valRecup.favorites_annoucements != null)
                    {
                        foreach(Favorite favorie in valRecup.favorites_annoucements)
                        {
                            if(favorie != null)
                            {
                                Annoucement? annoucement = _context.Annoucements.FirstOrDefault(a => a.id == favorie.id_annoucement);
                                if(annoucement != null)
                                {
                                    AnnoucementFavoriteRecruiterDto? annoncefavorie = _mapper.Map<AnnoucementFavoriteRecruiterDto>(annoucement);
                                    favorieDico.Add(annoncefavorie);
                                }
                            }
                        }
                    }
                    student.favorites = favorieDico;
                }
            }

            return Ok(student);
        }
        else
        {
            //on met dans le user filtrer les donées que l'on veut recup
            recruiter.connexion = true;
            recruiter.id = personne.id;
            recruiter.surname = personne.surname;
            recruiter.firstname = personne.firstname;
            recruiter.email = personne.email;
            recruiter.picture = personne.picture;
            recruiter.is_online = personne.is_online;
            
            Type_User? type_user = _context.Type_Users.FirstOrDefault(i => i.id == personne.id_type_user);
            recruiter.type_user = type_user;

            Company? company = _context.Companies.FirstOrDefault(i => i.siren == personne.id_company);
            CompanyDto? companyDto = _mapper.Map<CompanyDto>(company);
            recruiter.company = companyDto;

            // Annoucement Recruiter
            List<Annoucement>? annonce = await _context.Annoucements.Where(a => a.id_user == personne.id).ToListAsync();
            List<AnnoucementRecruiterDto> annonceDto = _mapper.Map<List<AnnoucementRecruiterDto>>(annonce);
            
            foreach(Annoucement pseudoannonce in annonce)
            {
                Annoucement_State? state = _context.Annoucement_Status.FirstOrDefault(i => i.id == pseudoannonce.id_status);
                Naf_Division? naf_div = _context.Naf_Divisions.FirstOrDefault(n => n.id == pseudoannonce.id_naf_division);
                Job? job = _context.Jobs.FirstOrDefault(j => j.id == pseudoannonce.id_job);

                foreach(AnnoucementRecruiterDto dtoAnn in annonceDto)
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
                        var qualification = _context.Annoucements
                            .Include(x => x.skills)
                                .ThenInclude(x => x.Skill)
                            .Where(x => x.id_user == personne.id && x.id == pseudoannonce.id)
                            .ToList();
                        
                        // format json car sinon impossible a lire les donénes
                        var options = new JsonSerializerOptions
                        {
                            ReferenceHandler = ReferenceHandler.IgnoreCycles
                        };

                        var json = System.Text.Json.JsonSerializer.Serialize(qualification, options);
                        var jsonDoc = JsonDocument.Parse(json);
                        var root = jsonDoc.RootElement;

                        foreach (var user in root.EnumerateArray())
                        {
                            var valRecup = System.Text.Json.JsonSerializer.Deserialize<Annoucement>(user);

                            if(valRecup != null)
                            {
                                // pour les skills on créer un dictionnaire pour avoir les skills de type "id": "value"
                                Dictionary<Int32, string> skillDico = new Dictionary<Int32, string>();

                                if(valRecup.skills != null)
                                {
                                    foreach(Qualification skill in valRecup.skills)
                                    {
                                        if(skill.Skill != null)
                                        {
                                            skillDico.Add(skill.Skill.id, skill.Skill.title!);
                                        }
                                    }
                                }

                                dtoAnn.qualifications = skillDico;
                            }
                        }
                    }
                }
            }

            recruiter.annoucements = annonceDto;

            return Ok(recruiter);
        }
    }
}