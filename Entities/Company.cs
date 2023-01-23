using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippeeAPI;

public class Company
{
    [Key]
    public Int32 siren { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string name { get; set; } =string.Empty;

    public Naf_Section? Naf_Section { get; set; }
    
    [ForeignKey("Naf_Section")]
    public Int32 id_naf { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string street { get; set; } =string.Empty;
    
    [Column(TypeName = "varchar(255)")]
    public string cp { get; set; } =string.Empty;
    
    [Column(TypeName = "varchar(255)")]
    public string city { get; set; } =string.Empty;
    
    [Column(TypeName = "varchar(255)")]
    public string legal_form { get; set; } =string.Empty;
    
    [Column(TypeName = "varchar(255)")]
    public string effective { get; set; } =string.Empty;
    
    [Column(TypeName = "varchar(255)")]
    public string web_site { get; set; } =string.Empty; 

    public bool payment { get; set; }

}