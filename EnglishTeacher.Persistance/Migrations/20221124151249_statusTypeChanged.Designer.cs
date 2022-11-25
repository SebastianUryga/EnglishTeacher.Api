﻿// <auto-generated />
using System;
using EnglishTeacher.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EnglishTeacher.Persistance.Migrations
{
    [DbContext(typeof(WordDbContext))]
    [Migration("20221124151249_statusTypeChanged")]
    partial class statusTypeChanged
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EnglishTeacher.Domain.Entities.Sentence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Inactivated")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WordId");

                    b.ToTable("Sentences");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2022, 11, 24, 16, 12, 49, 33, DateTimeKind.Local).AddTicks(5765),
                            CreatedBy = "Admin",
                            Status = 0,
                            Text = "What do you do?",
                            WordId = 1
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2022, 11, 24, 16, 12, 49, 33, DateTimeKind.Local).AddTicks(5769),
                            CreatedBy = "Admin",
                            Status = 0,
                            Text = "Just do it",
                            WordId = 1
                        });
                });

            modelBuilder.Entity("EnglishTeacher.Domain.Entities.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnglishText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Inactivated")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolishText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Words");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2022, 11, 24, 16, 12, 49, 33, DateTimeKind.Local).AddTicks(5536),
                            CreatedBy = "Admin",
                            EnglishText = "Do",
                            PolishText = "robić",
                            Status = 0
                        });
                });

            modelBuilder.Entity("EnglishTeacher.Domain.Entities.Sentence", b =>
                {
                    b.HasOne("EnglishTeacher.Domain.Entities.Word", "Word")
                        .WithMany()
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Word");
                });

            modelBuilder.Entity("EnglishTeacher.Domain.Entities.Word", b =>
                {
                    b.OwnsOne("EnglishTeacher.Domain.ValueObjects.AnsweringStatistics", "AnsweringStatistics", b1 =>
                        {
                            b1.Property<int>("WordId")
                                .HasColumnType("int");

                            b1.Property<int>("CorrectAnswers")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasDefaultValue(0)
                                .HasColumnName("CorrectAnswers");

                            b1.Property<DateTime>("LastAnswer")
                                .HasColumnType("datetime2")
                                .HasColumnName("LastAnswer");

                            b1.Property<int>("WrongAnswers")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasDefaultValue(0)
                                .HasColumnName("WrongAnswers");

                            b1.HasKey("WordId");

                            b1.ToTable("Words");

                            b1.WithOwner()
                                .HasForeignKey("WordId");

                            b1.HasData(
                                new
                                {
                                    WordId = 1,
                                    CorrectAnswers = 0,
                                    LastAnswer = new DateTime(2022, 11, 24, 16, 12, 49, 33, DateTimeKind.Local).AddTicks(5738),
                                    WrongAnswers = 0
                                });
                        });

                    b.Navigation("AnsweringStatistics")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
