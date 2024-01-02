namespace Leave.API.Dto;

public class CreateLeaveItem
{
    public DateOnly LeaveDate { get; set; }
    public double Quantity { get; set; }
}