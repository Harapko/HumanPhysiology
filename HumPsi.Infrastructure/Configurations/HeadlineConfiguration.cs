using HumPsi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumPsi.Infrastructure.Configurations;

public class HeadlineConfiguration : IEntityTypeConfiguration<HeadlineEntity>
{
    public void Configure(EntityTypeBuilder<HeadlineEntity> builder)
    {
        builder
            .HasKey(h => h.Id);

        builder
            .HasOne(h => h.SectionEntity)
            .WithMany(s => s.Headlines)
            .HasForeignKey(h => h.SectionId);
    }
}