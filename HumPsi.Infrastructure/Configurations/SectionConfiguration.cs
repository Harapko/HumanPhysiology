using HumPsi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumPsi.Infrastructure.Configurations;

public class SectionConfiguration : IEntityTypeConfiguration<SectionEntity>
{
    public void Configure(EntityTypeBuilder<SectionEntity> builder)
    {

        builder
            .HasKey(s => s.Id);

        builder
            .HasMany(s => s.Headlines)
            .WithOne(h => h.SectionEntity)
            .HasForeignKey(h => h.SectionId);
    }
}