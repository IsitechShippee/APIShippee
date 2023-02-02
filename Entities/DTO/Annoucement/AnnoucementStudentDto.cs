using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippeeAPI;

public class AnnoucementStudentDto
{
    public Int32 id { get; set; }

    public string? title { get; set; }

    public string? description { get; set; }

    public DateTime? publish_date { get; set; }

    public Annoucement_State? status { get; set; }

    public string? naf_division_title { get; set; }

    public string? job_title { get; set; }
}