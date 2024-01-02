
using Microsoft.EntityFrameworkCore;

namespace Leave.Api.Data;

public class LeaveDbContext(DbContextOptions<LeaveDbContext> options) : DbContext(options)
{
    public DbSet<API.Model.Leave> Leaves { get; set; }
    public DbSet<API.Model.LeaveStatus> LeaveStatus { get; set; }
}