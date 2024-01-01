namespace Personnel.Api.Model;

public class LegalName: Entity
{
    public required string FullName { get; set; }
    public required string GivenName { get; set; }
    public required string FamilyName { get; set; }
}