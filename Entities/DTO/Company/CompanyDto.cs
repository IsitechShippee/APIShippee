using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippeeAPI;

public class CompanyDto
{
    public Int32 siren { get; set; }

    public string? name { get; set; }
}