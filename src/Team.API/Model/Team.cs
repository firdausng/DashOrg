namespace Team.API.Model;

public class Team: Entity
{
    public string Name { get; set; }
    public Guid ManagerId { get; set; }
    public List<Team> ChildTeam { get; set; } = [];
    public List<TeamMember> TeamMembers { get; set; } = [];

}