namespace MangaAPI.Models.DTO.GET;

public class StudentMailPassWordDto
{
    public string? name { get; set; }
    public string? fristname { get; set; }
    public string? email { get; set; }
    public string? password { get; set; }
    public string? picture { get; set; }
    public bool? is_online { get; set; }
    public Int32? type_user {get; set; }
    public string? description { get; set; }
    public string? web_site { get; set; }
    public string? cv { get; set; }
    public string? city { get; set; }
    public DateOnly? birthday { get; set; }
}