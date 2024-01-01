namespace Personnel.Api.Model;

public class EmergencyContact: Entity
{
    public required int Priority { get; set; }
    public required string Name { get; set; }
    public required string Relationship { get; set; }
    public required string PreferredLanguage { get; set; }
    public required string PhoneNumber { get; set; }
}