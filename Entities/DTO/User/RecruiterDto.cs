using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippeeAPI;

public class RecruiterDto
{
    public bool connexion { get; set; }
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

    public Type_User? id_type_user {get; set; }

    public CompanyDto? company { get; set; }
    
}