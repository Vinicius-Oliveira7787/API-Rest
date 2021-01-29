﻿// <auto-generated />
using System;
using Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Migrations
{
    [DbContext(typeof(BrasileiraoContext))]
    [Migration("20210129143252_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Domain.AnswerSheets.AnswerSheet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Domain.Answers.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Score")
                        .HasMaxLength(10)
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("Domain.Questions.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AnswerSheetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Aswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("AswerSheetId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("AnswerSheetId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Profile")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aa43d63e-0b06-4490-b884-29e8cbda7043"),
                            Email = "ademir@bol.com",
                            Name = "Ademir Ademilson",
                            Password = "0192023A7BBD73250516F069DF18B500",
                            Profile = 0
                        });
                });

            modelBuilder.Entity("Domain.Questions.Question", b =>
                {
                    b.HasOne("Domain.Answers.Answer", "Answer")
                        .WithMany("Answers")
                        .HasForeignKey("AnswerId");

                    b.HasOne("Domain.AnswerSheets.AnswerSheet", "AnswerSheet")
                        .WithMany("Questions")
                        .HasForeignKey("AnswerSheetId");

                    b.Navigation("Answer");

                    b.Navigation("AnswerSheet");
                });

            modelBuilder.Entity("Domain.AnswerSheets.AnswerSheet", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Domain.Answers.Answer", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
