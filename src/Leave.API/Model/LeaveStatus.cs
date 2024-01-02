namespace Leave.API.Model;

public class LeaveStatus: Entity
{
    public Status Status { get; set; }
    public string? Reason { get; set; }
}