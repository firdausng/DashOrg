namespace Personnel.Api.Model;

public class Member: Entity
{
    public  ContactInformation ContactInformation { get; set; }
    public EmergencyContact? EmergencyContact { get; set; }
    public required PersonalInformation? PersonalInformation { get; set; }
    public LegalName LegalName { get; set; }
    public Photo? Photo { get; set; }
}