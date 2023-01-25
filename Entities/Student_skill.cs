using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippeeAPI;

public class Student_skill
{
    [Column(name: "id_student")]
    public int Userid { get; set; }
    public User? User { get; set; }

    [Column(name: "id_skill")]
    public int Skillid { get; set; }
    public Skill? Skill { get; set; }
}