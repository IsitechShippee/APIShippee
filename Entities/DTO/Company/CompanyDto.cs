using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippeeAPI;

public class CompanyDto
{
    [Key]
    public Int32 siren { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? name { get; set; }
}