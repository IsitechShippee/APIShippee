namespace ShippeeAPI;

public class AddAnnouncementDto
{
    public Int32 user_id { get; set; }

    public string title { get; set; }

    public string description { get; set; }

    public Int32 type_id { get; set; }

    public Int32 division_naf_id { get; set; }

    public Int32 diplome_id { get; set; }

    public Int32[] skills { get; set; }
}