﻿// <auto-generated />
using System;
using EnglishTeacher.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EnglishTeacher.Persistance.Migrations
{
    [DbContext(typeof(WordDbContext))]
    partial class WordDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
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

                    b.Property<DateTime?>("Inactivated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WordId");

                    b.ToTable("Sentenses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2022, 9, 15, 13, 39, 37, 64, DateTimeKind.Local).AddTicks(1320),
                            StatusId = 1,
                            Text = "text",
                            WordId = 1
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2022, 9, 15, 13, 39, 37, 64, DateTimeKind.Local).AddTicks(1329),
                            StatusId = 1,
                            Text = "text 2",
                            WordId = 1
                        });
                });

            modelBuilder.Entity("EnglishTeacher.Domain.Entities.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CorrectAnswers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnglishText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Inactivated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastAnswer")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("PolishText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("WrongAnswers")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Words");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CorrectAnswers = 0,
                            Created = new DateTime(2022, 9, 15, 13, 39, 37, 64, DateTimeKind.Local).AddTicks(1121),
                            EnglishText = "Do",
                            LastAnswer = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PolishText = "robić",
                            StatusId = 1,
                            WrongAnswers = 0
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
#pragma warning restore 612, 618
        }
    }
}
