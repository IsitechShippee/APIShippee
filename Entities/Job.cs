using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippeeAPI;

public class Job
{
    [Key]
    public Int32 id { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? title { get; set; }

    public Naf_Section? Naf_Section { get; set; }
    
    [ForeignKey("Naf_Section")]
    public Int32? id_naf_section { get; set; }
}