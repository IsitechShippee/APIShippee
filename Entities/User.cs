using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippeeAPI;

public class User
{
    [Key]
    public Int32 id { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string name { get; set; } =string.Empty;

    [Column(TypeName = "varchar(255)")]
    public string fristname { get; set; } =string.Empty;

    [Column(TypeName = "varchar(255)")]
    public string email { get; set; } =string.Empty;

    [Column(TypeName = "varchar(255)")]
    public string password { get; set; } =string.Empty;

    [Column(TypeName = "varchar(255)")]
    public string picture { get; set; } =string.Empty;

    public bool is_online { get; set; }

    public Int32 type_user {get; set; }

    public string description { get; set; } =string.Empty;

    [Column(TypeName = "varchar(255)")]
    public string web_site { get; set; } =string.Empty;

    [Column(TypeName = "varchar(255)")]
    public string cv { get; set; } =string.Empty;

    [Column(TypeName = "varchar(255)")]
    public string city { get; set; } =string.Empty;

    public DateOnly birthday { get; set; } 

    public ICollection<Skill>? Skill { get; set; } 

    public Company? Company { get; set; }
    
    [ForeignKey("Company")]
    public Int32 id_company { get; set; }

}