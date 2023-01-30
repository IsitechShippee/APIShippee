
using ShippeeAPI.Context;
using Microsoft.AspNetCore.Mvc;
using Aspose.Cells;

namespace ShippeeAPI.Controllers;

[ApiController]
[Route(template:"api/[controller]")]
public class AjoutDonneeBddController : ControllerBase
{
    private readonly ApplicationDbContext _context;


    private readonly ILogger<AjoutDonneeBddController> _logger;


    public AjoutDonneeBddController(ILogger<AjoutDonneeBddController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _context = dbContext;
    }


    [HttpGet("Ajout_Naf_Section")]
    public async Task<IActionResult> GetAjout_Naf_Section()
    {
        Workbook wb = new Workbook("../ShippeeAPI/DonneeImporter/Naf_Section.xls");

        WorksheetCollection collection = wb.Worksheets;

        for (int worksheetIndex = 0; worksheetIndex < collection.Count; worksheetIndex++)
        {
            Worksheet worksheet = collection[worksheetIndex];

            int rows = worksheet.Cells.MaxDataRow;
            int cols = worksheet.Cells.MaxDataColumn;

            for (int i = 0; i <= rows; i++)
            {
                Naf_Section naf = new Naf_Section();
                naf.id = Convert.ToInt32(worksheet.Cells[i, 0].Value);
                naf.title = Convert.ToString(worksheet.Cells[i, 1].Value);

                await _context.Naf_Sections.AddAsync(naf);
                await _context.SaveChangesAsync();
            }
        }

        return Ok("Les naf_sections sont bien ajoutés");
    }




    [HttpGet("Ajout_Naf_Division")]
    public async Task<IActionResult> GetAjout_Naf_Division()
    {
        Workbook wb = new Workbook("../ShippeeAPI/DonneeImporter/Naf_Division.xls");

        WorksheetCollection collection = wb.Worksheets;

        for (int worksheetIndex = 0; worksheetIndex < collection.Count; worksheetIndex++)
        {
            Worksheet worksheet = collection[worksheetIndex];

            int rows = worksheet.Cells.MaxDataRow;
            int cols = worksheet.Cells.MaxDataColumn;

            for (int i = 0; i <= rows; i++)
            {
                Naf_Division naf = new Naf_Division();
                naf.id = Convert.ToInt32(worksheet.Cells[i, 0].Value);
                naf.id_naf = Convert.ToInt32(worksheet.Cells[i, 1].Value);
                naf.title = Convert.ToString(worksheet.Cells[i, 2].Value);

                await _context.Naf_Divisions.AddAsync(naf);
                await _context.SaveChangesAsync();
            }
        }

        return Ok("Les naf_divisons sont bien ajoutés");
    }

    [HttpGet("Ajout_Type_User")]
    public async Task<IActionResult> GetAjout_Type_User()
    {
        Workbook wb = new Workbook("../ShippeeAPI/DonneeImporter/Type_User.xls");

        WorksheetCollection collection = wb.Worksheets;

        for (int worksheetIndex = 0; worksheetIndex < collection.Count; worksheetIndex++)
        {
            Worksheet worksheet = collection[worksheetIndex];

            int rows = worksheet.Cells.MaxDataRow;
            int cols = worksheet.Cells.MaxDataColumn;

            for (int i = 0; i <= rows; i++)
            {
                Type_User type_user = new Type_User();
                type_user.id = Convert.ToInt32(worksheet.Cells[i, 0].Value);
                type_user.title = Convert.ToString(worksheet.Cells[i, 1].Value);


                await _context.Type_Users.AddAsync(type_user);
                await _context.SaveChangesAsync();
            }
        }

        return Ok("Les type users sont bien ajoutés");
    }

    [HttpGet("Ajout_User")]
    public async Task<IActionResult> GetAjout_User()
    {
        Workbook wb = new Workbook("../ShippeeAPI/DonneeImporter/User.xls");

        WorksheetCollection collection = wb.Worksheets;

        for (int worksheetIndex = 0; worksheetIndex < collection.Count; worksheetIndex++)
        {
            Worksheet worksheet = collection[worksheetIndex];

            int rows = worksheet.Cells.MaxDataRow;
            int cols = worksheet.Cells.MaxDataColumn;

            for (int i = 0; i <= rows; i++)
            {
                User user = new User();
                user.id = Convert.ToInt32(worksheet.Cells[i, 0].Value);
                user.surname = Convert.ToString(worksheet.Cells[i, 1].Value);
                user.firstname = Convert.ToString(worksheet.Cells[i, 2].Value);
                user.email = Convert.ToString(worksheet.Cells[i, 3].Value);
                user.password = Convert.ToString(worksheet.Cells[i, 4].Value);
                user.picture = Convert.ToString(worksheet.Cells[i, 5].Value);
                user.is_online = Convert.ToBoolean(worksheet.Cells[i, 6].Value);
                user.id_type_user = Convert.ToInt32(worksheet.Cells[i, 7].Value);
                user.description = Convert.ToString(worksheet.Cells[i, 8].Value);
                user.web_site = Convert.ToString(worksheet.Cells[i, 9].Value);
                user.cv = Convert.ToString(worksheet.Cells[i, 10].Value);
                user.cp = Convert.ToString(worksheet.Cells[i, 11].Value);
                user.city = Convert.ToString(worksheet.Cells[i, 12].Value);
                DateTime date = Convert.ToDateTime(worksheet.Cells[i, 13].Value);
                string dateOnly = date.ToString("yyyy-MM-dd");
                DateOnly test = DateOnly.Parse(dateOnly);
                user.birthday = test;
                user.is_conveyed = Convert.ToBoolean(worksheet.Cells[i, 14].Value);


                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
        }

        return Ok("Les users sont bien ajoutés");
    }


    [HttpGet("Ajout_Skill")]
    public async Task<IActionResult> GetAjout_Skill()
    {
        Workbook wb = new Workbook("../ShippeeAPI/DonneeImporter/Skill.xls");

        WorksheetCollection collection = wb.Worksheets;

        for (int worksheetIndex = 0; worksheetIndex < collection.Count; worksheetIndex++)
        {
            Worksheet worksheet = collection[worksheetIndex];

            int rows = worksheet.Cells.MaxDataRow;
            int cols = worksheet.Cells.MaxDataColumn;

            for (int i = 0; i <= rows; i++)
            {
                Skill skill = new Skill();
                skill.id = Convert.ToInt32(worksheet.Cells[i, 0].Value);
                skill.title = Convert.ToString(worksheet.Cells[i, 1].Value);

                await _context.Skills.AddAsync(skill);
                await _context.SaveChangesAsync();
            }
        }

        return Ok("Les skills sont bien ajoutés");
    }

    
}