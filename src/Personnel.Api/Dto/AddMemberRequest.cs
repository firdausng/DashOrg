namespace Personnel.Api.Dto;

public class AddMemberRequest
{
    public required string Address { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required string WorkEmail { get; set; }
    public required string WorkAddress { get; set; }
    
    public required string FullName { get; set; }
    public required string GivenName { get; set; }
    public required string FamilyName { get; set; }
    
    public required string Gender { get; set; }
    public required DateOnly Dob { get; set; }
    public required string MaritalStatus { get; set; }
    public required DateOnly MaritalStatusDate { get; set; }
    public required string Ethnic { get; set; }
    public required string Religion { get; set; }
    public required string CitizenshipStatus { get; set; }
    public required string Nationality { get; set; }
}