using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippeeAPI;

public class Student_Skill
{
    public int user_id { get; set; }
    public User? user { get; set; }

    public int skill_id { get; set; }
    public Skill? skill { get; set; }
}