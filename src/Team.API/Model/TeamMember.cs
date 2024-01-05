namespace Team.API.Model;

public class TeamMember: Entity
{
    public Guid MemberId { get; set; }
    public required string Designation { get; set; }
    public required string Location { get; set; }
    public List<Team> Teams { get; set; } = [];
}