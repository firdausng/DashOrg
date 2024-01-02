namespace Leave.API.Model;

public class LeaveType: Entity
{
    public required string Name { get; set; }
    public required int Total { get; set; }
}