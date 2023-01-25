using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippeeAPI;

public class Student_skill
{
    public int Userid { get; set; }
    public User? User { get; set; }
    
    public int Skillid { get; set; }
    public Skill? Skill { get; set; }
}