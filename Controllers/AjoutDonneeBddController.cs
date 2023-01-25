
using ShippeeAPI.Context;
using Microsoft.AspNetCore.Mvc;
using Aspose.Cells;
using Microsoft.EntityFrameworkCore;

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
        List<Naf_Section> listA = new List<Naf_Section>();

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

                listA.Add(naf);
            }
        }

        return Ok("Les naf_sections sont bien ajouté");
    }




    [HttpGet("Ajout_Naf_Division")]
    public async Task<IActionResult> GetAjout_Naf_Division()
    {
        Workbook wb = new Workbook("../ShippeeAPI/DonneeImporter/Naf_Division.xls");

        WorksheetCollection collection = wb.Worksheets;
        List<Naf_Division> listA = new List<Naf_Division>();

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

                listA.Add(naf);
            }
        }

        return Ok("Les naf_divisons sont bien ajouté");
    }

    
}