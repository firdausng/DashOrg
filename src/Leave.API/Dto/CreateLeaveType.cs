namespace Leave.API.Dto;

public class CreateLeaveType
{
    public required string Name { get; set; }
    public required int Total { get; set; }
}