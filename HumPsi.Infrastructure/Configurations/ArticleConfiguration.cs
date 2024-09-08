using HumPsi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumPsi.Infrastructure.Configurations;

public class ArticleConfiguration : IEntityTypeConfiguration<ArticleEntity>
{
    public void Configure(EntityTypeBuilder<ArticleEntity> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .HasOne(a => a.HeadlineEntity)
            .WithMany(h => h.ArticleEntities)
            .HasForeignKey(a => a.HeadlineId);

        builder
            .Property(a => a.Id)
            .IsRequired();

        builder
            .Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(25);

        builder
            .Property(a => a.Content)
            .IsRequired();

        builder
            .Property(a => a.HeadlineId)
            .IsRequired();
    }
}