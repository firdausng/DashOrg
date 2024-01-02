using Leave.API.Model;

namespace Leave.API.Dto;

public class CreateLeaveRequest
{
    public Guid MemberId { get; set; }
    public List<CreateLeaveItem> Leaves { get; set; }
    public required CreateLeaveType LeaveType { get; set; }
    public CreateLeaveAttachment Attachment { get; set; }
    public string? Reason { get; set; }
}