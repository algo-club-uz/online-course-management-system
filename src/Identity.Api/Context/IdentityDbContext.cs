using Identity.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Context;

public class IdentityDbContext:DbContext
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<User> Users { get; set; }
}