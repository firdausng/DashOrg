namespace Personnel.Api.Model;

public class ContactInformation: Entity
{
    public required string Address { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required string WorkEmail { get; set; }
    public required string WorkAddress { get; set; }
}