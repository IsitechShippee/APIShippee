
using ShippeeAPI.Context;
using Microsoft.AspNetCore.Mvc;
using System.IO;
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
        Workbook wb = new Workbook("G:/Shippee/Naf_Section.xls");

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
    

    
}