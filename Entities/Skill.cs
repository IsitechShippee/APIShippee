using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippeeAPI;

public class Skill
{
    [Key]
    public Int32 id { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? title { get; set; }

    public List<Student_skill>? Student_skills { get; set; }
}