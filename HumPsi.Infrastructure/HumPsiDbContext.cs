
using HumPsi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumPsi.Domain;

public class HumPsiDbContext(DbContextOptions<HumPsiDbContext> options) : DbContext(options)
{
    public DbSet<SectionEntity> Section { get; init; }
    public DbSet<HeadlineEntity> Headline { get; init; }
    public DbSet<ArticleEntity> Article { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HumPsiDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}