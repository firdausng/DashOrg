using Microsoft.EntityFrameworkCore;

namespace Team.API.Data;

public class TeamDbContext(DbContextOptions<TeamDbContext> options) : DbContext(options)
{
    public DbSet<Model.Team> Teams { get; set; }
    public DbSet<Model.Team> TeamMembers { get; set; }
}