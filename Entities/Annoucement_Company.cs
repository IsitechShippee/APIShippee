using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippeeAPI;

public class Annoucement_Company
{
    [Key]
    public Int32 id { get; set; }

    public User? User { get; set; }
    
    [ForeignKey("User")]
    public Int32? id_recruiter { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? title { get; set; }

    public string? description { get; set; }

    public DateTime? publish_date { get; set; }

    public Job? Job { get; set; }
    
    [ForeignKey("Job")]
    public Int32? id_job { get; set; }

    public Naf_Division? Naf_Division { get; set; }
    
    [ForeignKey("Naf_Division")]
    public Int32? id_naf_division { get; set; }

}