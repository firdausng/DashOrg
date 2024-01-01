namespace Personnel.Api.Model;

public class PersonalInformation: Entity
{
    public required string Gender { get; set; }
    public required DateOnly Dob { get; set; }
    public required string MaritalStatus { get; set; }
    public required DateOnly MaritalStatusDate { get; set; }
    public required string Ethnic { get; set; }
    public required string Religion { get; set; }
    public required string CitizenshipStatus { get; set; }
    public required string Nationality { get; set; }
}