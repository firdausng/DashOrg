using Microsoft.EntityFrameworkCore;
using Personnel.Api.Model;

namespace Personnel.Api.Data;

public class PersonnelDbContext(DbContextOptions<PersonnelDbContext> options) : DbContext(options)
{
    public DbSet<Member> Members { get; set; }
}