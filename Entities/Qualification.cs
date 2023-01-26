namespace ShippeeAPI;

public class Qualification
{
    public int Annoucement_Companyid { get; set; }
    public Annoucement_Company? Annoucement_Company { get; set; }

    public int Skillid { get; set; }
    public Skill? Skill { get; set; }
}