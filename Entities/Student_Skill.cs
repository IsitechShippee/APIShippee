using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippeeAPI;

public class Student_Skill
{
    public Int32 user_id { get; set; }
    public User? User { get; set; }

    public Int32 skill_id { get; set; }
    public Skill? Skill { get; set; }
}