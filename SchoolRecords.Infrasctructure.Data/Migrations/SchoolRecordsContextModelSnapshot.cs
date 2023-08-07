﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolRecords.Infrasctructure.Data.Context;

#nullable disable

namespace SchoolRecords.Infrasctructure.Data.Migrations
{
    [DbContext(typeof(SchoolRecordsContext))]
    partial class SchoolRecordsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolRecords.Domain.Entities.SchoolRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Format")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("SchoolRecords", (string)null);
                });

            modelBuilder.Entity("SchoolRecords.Domain.Entities.Schooling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Schoolings", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreatedAt = new DateTime(2023, 8, 7, 11, 24, 0, 834, DateTimeKind.Local).AddTicks(1183),
                            Description = "Ensino Infantil",
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreatedAt = new DateTime(2023, 8, 7, 11, 24, 0, 834, DateTimeKind.Local).AddTicks(1241),
                            Description = "Ensino Fundamental",
                            Type = 2
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreatedAt = new DateTime(2023, 8, 7, 11, 24, 0, 834, DateTimeKind.Local).AddTicks(1251),
                            Description = "Ensino Médio",
                            Type = 3
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            CreatedAt = new DateTime(2023, 8, 7, 11, 24, 0, 834, DateTimeKind.Local).AddTicks(1257),
                            Description = "Ensino Supeior",
                            Type = 4
                        });
                });

            modelBuilder.Entity("SchoolRecords.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BirthDate")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2023, 8, 6, 11, 24, 0, 834, DateTimeKind.Local).AddTicks(8132));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("SchoolRecordId")
                        .HasColumnType("int");

                    b.Property<int?>("SchoolingId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("SchoolRecordId")
                        .IsUnique()
                        .HasFilter("[SchoolRecordId] IS NOT NULL");

                    b.HasIndex("SchoolingId")
                        .IsUnique()
                        .HasFilter("[SchoolingId] IS NOT NULL");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("SchoolRecords.Domain.Entities.User", b =>
                {
                    b.HasOne("SchoolRecords.Domain.Entities.SchoolRecord", "SchoolRecord")
                        .WithOne()
                        .HasForeignKey("SchoolRecords.Domain.Entities.User", "SchoolRecordId");

                    b.HasOne("SchoolRecords.Domain.Entities.Schooling", "Schooling")
                        .WithOne()
                        .HasForeignKey("SchoolRecords.Domain.Entities.User", "SchoolingId");

                    b.Navigation("SchoolRecord");

                    b.Navigation("Schooling");
                });
#pragma warning restore 612, 618
        }
    }
}
