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
        }

        List<Annoucement> annonce_filter_diplome = new List<Annoucement>();

        if(diplome != 0)
        {
            if(annonce_filter_cp.Count == 0)
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
                foreach(Annoucement annoncediplome in annonce_filter_cp)
                {
                    if(annoncediplome.id_diplome == diplome)
                    {
                        annonce_filter_diplome.Add(annoncediplome);
                    }
                }
            }
        }

        List<Annoucement> testt = _mapper.Map<List<Annoucement>>(annonce_filter_diplome);

        return Ok(annonce_filter_diplome);
    }

    [HttpPut("UpdateStatusAnnouncement")]
    public async Task<IActionResult> UpdateStatus(StatusAnnouncementDto stateAnnouncement)
    {

        Annoucement? exist = _context.Annoucements.FirstOrDefault(i => i.id == stateAnnouncement.id_annoucement);
        
        if(exist != null)
        {
            exist.id_status = stateAnnouncement.id_statut;
            _context.Annoucements.Update(exist);
            await _context.SaveChangesAsync();
        }
        

        return Ok("statut de l'annonce modifier");
    }

}