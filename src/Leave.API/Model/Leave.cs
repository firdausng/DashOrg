namespace Leave.API.Model;

public class Leave: Entity
{
    public Guid MemberId { get; set; }
    public Guid ApproverMemberId { get; set; }
    public List<LeaveItem> LeaveItems { get; set; } = [];
    public required LeaveType LeaveType { get; set; }
    public LeaveStatus Status { get; set; }
    public Attachment Attachment { get; set; }
    public string? Reason { get; set; }
}