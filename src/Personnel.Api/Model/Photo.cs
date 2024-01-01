namespace Personnel.Api.Model;

public class Photo: Entity
{
    public required string Path { get; set; }
    public required string Comment { get; set; }
}