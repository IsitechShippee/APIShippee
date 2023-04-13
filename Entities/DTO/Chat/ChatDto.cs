namespace ShippeeAPI;

public class ChatDto
{
    public Int32 id { get; set; }

    public string? content { get; set; }

    public DateTime? send_time { get; set; }

    public Int32? status { get; set; }
}