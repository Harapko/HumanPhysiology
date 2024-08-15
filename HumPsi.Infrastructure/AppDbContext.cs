using HumPsi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumPsi.Domain;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<SectionEntity> Section { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}