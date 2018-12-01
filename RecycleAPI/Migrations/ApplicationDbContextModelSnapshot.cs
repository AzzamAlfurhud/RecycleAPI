﻿// <auto-generated />
using System;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecycleAPI.Data;

namespace RecycleAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview2-35157")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RecycleAPI.Data.Entities.Recycle", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedOn");

                    b.Property<SqlBytes>("Location");

                    b.Property<int>("StatusId");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("TypeId");

                    b.ToTable("Recycles");
                });

            modelBuilder.Entity("RecycleAPI.Data.Entities.Status", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("RecycleAPI.Data.Entities.Type", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("RecycleAPI.Data.Entities.Recycle", b =>
                {
                    b.HasOne("RecycleAPI.Data.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecycleAPI.Data.Entities.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
