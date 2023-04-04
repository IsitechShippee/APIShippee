namespace ShippeeAPI;

public class StudentDto
{
    public bool connexion { get; set; }
    public Int32 id { get; set; }

    public string? surname { get; set; }

    public string? firstname { get; set; }

    public string? email { get; set; }

    public string? picture { get; set; }

    public bool? is_online { get; set; }

    public Type_User? type_user {get; set; }

    public string? description { get; set; }

    public string? web_site { get; set; }

    public string? cv { get; set; }

    public string? cp { get; set; }

    public string? city { get; set; }

    public DateOnly? birthday { get; set; } 

    public bool? is_conveyed { get; set; }

    public Dictionary<Int32, string>? skills { get; set; }

    public List<AnnoucementStudentDto>? annoucements { get; set; }
    
    public List<AnnoucementFavoriteRecruiterDto>? favorites { get; set; }

    public List<AnnoucementRecentStudentDto>? recents_announcements { get; set; }
    
}