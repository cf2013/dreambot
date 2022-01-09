﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dreambot.Data;

namespace dreambot.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dreambot.Data.Entities.Conversation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("contents")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("feedback")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("seed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.Property<string>("teacherFeedback")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("teacherFeedbackDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("teacherId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("studentId");

                    b.HasIndex("teacherId");

                    b.ToTable("Conversation");
                });

            modelBuilder.Entity("dreambot.Data.Entities.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("currentCourse")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("whatsapp")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("dreambot.Data.Entities.Teacher", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("whatsapp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("dreambot.Data.Entities.Conversation", b =>
                {
                    b.HasOne("dreambot.Data.Entities.Student", "student")
                        .WithMany("conversations")
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dreambot.Data.Entities.Teacher", "teacher")
                        .WithMany("conversations")
                        .HasForeignKey("teacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
