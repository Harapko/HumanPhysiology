﻿// <auto-generated />
using System;
using HumPsi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HumPsi.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240904092812_addArticle")]
    partial class addArticle
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HumPsi.Domain.Entities.ArticleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("HeadlineId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.HasKey("Id");

                    b.HasIndex("HeadlineId");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("HumPsi.Domain.Entities.HeadlineEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SectionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Headline");
                });

            modelBuilder.Entity("HumPsi.Domain.Entities.SectionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.HasKey("Id");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("HumPsi.Domain.Entities.ArticleEntity", b =>
                {
                    b.HasOne("HumPsi.Domain.Entities.HeadlineEntity", "HeadlineEntity")
                        .WithMany("ArticleEntities")
                        .HasForeignKey("HeadlineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HeadlineEntity");
                });

            modelBuilder.Entity("HumPsi.Domain.Entities.HeadlineEntity", b =>
                {
                    b.HasOne("HumPsi.Domain.Entities.SectionEntity", "SectionEntity")
                        .WithMany("Headlines")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SectionEntity");
                });

            modelBuilder.Entity("HumPsi.Domain.Entities.HeadlineEntity", b =>
                {
                    b.Navigation("ArticleEntities");
                });

            modelBuilder.Entity("HumPsi.Domain.Entities.SectionEntity", b =>
                {
                    b.Navigation("Headlines");
                });
#pragma warning restore 612, 618
        }
    }
}
