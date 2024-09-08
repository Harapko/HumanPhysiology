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

        builder
            .HasMany(h => h.ArticleEntities)
            .WithOne(a => a.HeadlineEntity)
            .HasForeignKey(a => a.HeadlineId);

        builder
            .Property(h => h.Id)
            .IsRequired();

        builder
            .Property(h => h.Title)
            .IsRequired()
            .HasMaxLength(25);

        builder
            .Property(h => h.SectionId)
            .IsRequired();
    }
}