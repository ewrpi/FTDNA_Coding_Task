using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FTDNA_Coding_Task.Models;

namespace FTDNA_Coding_Task.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FTDNA_Coding_Task.Models.Sample", b =>
                {
                    b.Property<int>("SampleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Barcode");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedById");

                    b.Property<int>("StatusId");

                    b.HasKey("SampleId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("StatusId");

                    b.ToTable("Samples");
                });

            modelBuilder.Entity("FTDNA_Coding_Task.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StatusName");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("FTDNA_Coding_Task.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FTDNA_Coding_Task.Models.Sample", b =>
                {
                    b.HasOne("FTDNA_Coding_Task.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FTDNA_Coding_Task.Models.Status", "Status")
                        .WithMany("Samples")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
