namespace Leave.API.Model;

public class Attachment: Entity
{
    public required string Path { get; set; }
    public required string Comment { get; set; }
}