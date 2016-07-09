using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFGenericRepository;

namespace EFGenericRepository.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20160709190053_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("EFGenericRepository.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SectionName");

                    b.HasKey("Id");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("EFGenericRepository.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("SectionId");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EFGenericRepository.Student", b =>
                {
                    b.HasOne("EFGenericRepository.Section", "Section")
                        .WithMany("Students")
                        .HasForeignKey("SectionId");
                });
        }
    }
}
