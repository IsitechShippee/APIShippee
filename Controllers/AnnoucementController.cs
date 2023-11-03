using ShippeeAPI.Context;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Aspose.Cells.Charts;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

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
    public async Task<IActionResult> GetAnnouncement(int id, string cp, int diplome)
    {
        List<Annoucement> final_annonce_filter = new List<Annoucement>();

        List<Annoucement> annonce = new List<Annoucement>();

        if(id == 1)
        {
            annonce = await _context.Annoucements.Where(i => i.id_type == 2 || i.id_type == 3).ToListAsync();
        }
        else
        {
            annonce = await _context.Annoucements.Where(i => i.id_type == 1).ToListAsync();
        }


        List<Annoucement> annonce_filter_cp = new List<Annoucement>();

        if(cp != "null")
        {
            // ajout des annonces qui ont les memes codes postaux dans une liste
            foreach(Annoucement annouce in annonce)
            {
                if(annouce.id_user != null)
                {
                    User? user_cp = _context.Users.FirstOrDefault(i => i.id == annouce.id_user);
                    if(user_cp != null)
                    {
                        if(user_cp.cp != "" && user_cp.cp != null)
                        {
                            if(user_cp.cp == cp)
                            {
                                annonce_filter_cp.Add(annouce);
                            }
                        }
                        else
                        {
                            Company? company_cp = _context.Companies.FirstOrDefault(i => i.siren == user_cp.id_company);
                            
                            if(company_cp != null)
                            {
                                if(company_cp.cp == cp)
                                {
                                    annonce_filter_cp.Add(annouce);
                                }
                            }
                        }
                    }
                }
            }

            // verif si déjà dans le tableau
            foreach(Annoucement annouce in annonce)
            {
                if(annouce.id_user != null)
                {
                    User? user_cp = _context.Users.FirstOrDefault(i => i.id == annouce.id_user);
                    if(user_cp != null)
                    {
                        if(user_cp.cp != "" && user_cp.cp != null)
                        {
                            if(user_cp.cp.Substring(0, 2) == cp.Substring(0, 2))
                            {
                                if(!annonce_filter_cp.Contains(annouce))
                                {
                                    annonce_filter_cp.Add(annouce);
                                }
                            }
                        }
                        else
                        {
                            Company? company_cp = _context.Companies.FirstOrDefault(i => i.siren == user_cp.id_company);
                            
                            if(company_cp != null)
                            {
                                if(company_cp.cp != null)
                                {
                                    if(company_cp.cp.Substring(0, 2) == cp.Substring(0, 2))
                                    {
                                        if(!annonce_filter_cp.Contains(annouce))
                                        {
                                            annonce_filter_cp.Add(annouce);
                                        }
                                    }
                                }
                                
                            }
                        }
                    }
                }
            }

            final_annonce_filter = annonce_filter_cp;
        }

        List<Annoucement> annonce_filter_diplome = new List<Annoucement>();

        if(diplome != 0)
        {
            if(final_annonce_filter.Count == 0)
            {
                foreach(Annoucement annoncediplome in annonce)
                {
                    if(annoncediplome.id_diplome == diplome)
                    {
                        annonce_filter_diplome.Add(annoncediplome);
                    }
                }
            }
            else
            {
                foreach(Annoucement annoncediplome in final_annonce_filter)
                {
                    if(annoncediplome.id_diplome == diplome)
                    {
                        annonce_filter_diplome.Add(annoncediplome);
                    }
                }
            }

            final_annonce_filter = annonce_filter_diplome;
        }

        List<string> nafadd = new List<string>();
        List<string> diplo = new List<string>();
        List<Dictionary<Int32, string>> quali = new List<Dictionary<Int32, string>>();

        foreach(Annoucement addf in final_annonce_filter)
        {
            Naf_Division nafd = _context.Naf_Divisions.FirstOrDefault(n => n.id == addf.id_naf_division);

            if(nafd != null)
            {
                nafadd.Add(nafd.title);
            }

            Diplome dip = _context.Diplomes.FirstOrDefault(n => n.id == addf.id_diplome);

            if(dip != null)
            {
                diplo.Add(dip.diplome);
            }


            var qualification = _context.Annoucements
                .Include(x => x.skills)
                    .ThenInclude(x => x.Skill)
                .Where(x => x.id == addf.id)
                .ToList();

            // format json car sinon impossible a lire les donénes
            var options3 = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            var json3 = System.Text.Json.JsonSerializer.Serialize(qualification, options3);
            var jsonDoc3 = JsonDocument.Parse(json3);
            var root3 = jsonDoc3.RootElement;

            foreach (var user2 in root3.EnumerateArray())
            {
                var valRecup2 = System.Text.Json.JsonSerializer.Deserialize<Annoucement>(user2);

                if (valRecup2 != null)
                {
                    // pour les skills on créer un dictionnaire pour avoir les skills de type "id": "value"
                    Dictionary<Int32, string> skillDico = new Dictionary<Int32, string>();

                    if (valRecup2.skills != null)
                    {
                        foreach (Qualification skill in valRecup2.skills)
                        {
                            Skill? sskillss = _context.Skills.FirstOrDefault(s => s.id == skill.id_skill);
                            if (sskillss != null)
                            {
                                if (sskillss.title != null)
                                {
                                    skillDico.Add(sskillss.id, sskillss.title);
                                }
                            }
                        }
                    }

                    quali.Add(skillDico);
                }
            }



        }

        List<AnnoucementRecentStudentDto> testt = _mapper.Map<List<AnnoucementRecentStudentDto>>(final_annonce_filter);

        var index = 0;
        foreach(AnnoucementRecentStudentDto aaaa in testt)
        {
            aaaa.naf_division_title = nafadd[index];
            aaaa.diplome = diplo[index];
            aaaa.qualifications = quali[index];
            index++;
        }




        





        return Ok(testt);
    }

    [HttpPut("UpdateStatusAnnouncement")]
    public async Task<IActionResult> UpdateStatus(StatusAnnouncementDto stateAnnouncement)
    {
        User? personne = _context.Users.FirstOrDefault(i => i.email == stateAnnouncement.user.id && i.password == stateAnnouncement.user.password);

        if(personne == null)
        {
            return Ok("user existe pas");
        }

        Annoucement? exist = _context.Annoucements.FirstOrDefault(i => i.id == stateAnnouncement.id_annoucement);
        
        if(exist != null)
        {
            exist.id_status = stateAnnouncement.id_statut;
            _context.Annoucements.Update(exist);
            await _context.SaveChangesAsync();
        }
        

        return Ok("statut de l'annonce modifier");
    }

    [HttpPost("AddAnnouncement")]
    public async Task<IActionResult> AddAnnouncement(AddAnnouncementDto add_announcement)
    {
        Annoucement newannouncement = new Annoucement();
        newannouncement.id_user = add_announcement.user_id;
        newannouncement.title = add_announcement.title;
        newannouncement.description = add_announcement.description;
        newannouncement.publish_date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        newannouncement.id_type = add_announcement.type_id;
        newannouncement.id_status = 2;
        newannouncement.id_naf_division = add_announcement.division_naf_id;
        newannouncement.id_diplome = add_announcement.diplome_id;

        await _context.Annoucements.AddAsync(newannouncement);
        await _context.SaveChangesAsync();

        Annoucement? exist = _context.Annoucements.FirstOrDefault(i => i.id_user == add_announcement.user_id && i.title == add_announcement.title && i.description == add_announcement.description && i.id_type == add_announcement.type_id && i.id_naf_division == add_announcement.division_naf_id && i.id_diplome == add_announcement.diplome_id);

        for(int i = 0; i < add_announcement.skills.Length; i++)
        {
            Qualification newqualif = new Qualification();
            newqualif.id_annoucement = exist.id;
            newqualif.id_skill = add_announcement.skills[i];

            await _context.Qualifications.AddAsync(newqualif);
            await _context.SaveChangesAsync();
        }

        return Ok("ok");
    }

}