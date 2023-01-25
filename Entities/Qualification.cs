using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippeeAPI;

public class Qualification
{
    public int Annoucement_Companyid { get; set; }
    public Annoucement_Company? Annoucement_Company { get; set; }

    public int Skillid { get; set; }
    public Skill? Skill { get; set; }
}