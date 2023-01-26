using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippeeAPI;

public class User
{

    [Key]
    public Int32 id { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? name { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? fristname { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? email { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? password { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? picture { get; set; }

    public bool? is_online { get; set; }

    public Int32? type_user {get; set; }

    public string? description { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? web_site { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? cv { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? city { get; set; }

    public DateOnly? birthday { get; set; } 

    public List<Student_Skill>? Student_skills { get; set; }

    public Company? Company { get; set; }
    
    [ForeignKey("Company")]
    public Int32? id_company { get; set; }

}