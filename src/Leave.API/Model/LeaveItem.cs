namespace Leave.API.Model;

public class LeaveItem: Entity
{
    public DateOnly LeaveDate { get; set; }
    public double Quantity { get; set; }
}