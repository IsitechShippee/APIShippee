using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippeeAPI;

public class StudentDto
{

    [Key]
    public Int32 id { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? surname { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? firstname { get; set; }

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

    public List<SkillDto>? skills { get; set; }
    
}