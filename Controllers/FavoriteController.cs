using ShippeeAPI.Context;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ShippeeAPI.Controllers;

[ApiController]
[Route(template: "api/[controller]")]
public class FavoriteController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<FavoriteController> _logger;
    private readonly IMapper _mapper;


    public FavoriteController(ILogger<FavoriteController> logger, ApplicationDbContext dbContext, IMapper mapper)
    {
        _logger = logger;
        _context = dbContext;
        _mapper = mapper;
    }

    [HttpPost("favorite")]
    public async Task<IActionResult> CreateFavorite(int user, int annoucement)
    {
        Favorite favorie = new Favorite();
        favorie.id_annoucement = annoucement;
        favorie.id_user = user;

        await _context.Favorites.AddAsync(favorie);
        await _context.SaveChangesAsync();

        return Ok("Favorie ajouté");
    }

}