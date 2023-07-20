﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using nc2.Context;

#nullable disable

namespace nc2.Migrations
{
    [DbContext(typeof(NcDbContext))]
    [Migration("20230410105929_cloud-remove")]
    partial class cloudremove
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("nc2.Models.Note", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("isChecked")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("noteType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("notebookId")
                        .HasColumnType("int");

                    b.Property<string>("stickerNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("stickerType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("textNote")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("notebookId");

                    b.ToTable("Notes");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Note");

                    b.UseTphMappingStrategy();

                    b.HasData(
                        new
                        {
                            id = 1,
                            createdDate = new DateTime(2023, 4, 10, 13, 59, 28, 981, DateTimeKind.Local).AddTicks(8),
                            modifiedDate = new DateTime(2023, 4, 10, 13, 59, 28, 981, DateTimeKind.Local).AddTicks(10),
                            notebookId = 1,
                            textNote = "Sample"
                        });
                });

            modelBuilder.Entity("nc2.Models.Notebook", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("checkedCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("imageCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("notebookType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shareStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("textCount")
                        .HasColumnType("int");

                    b.Property<int?>("uncheckedCount")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Notebooks");
                });

            modelBuilder.Entity("nc2.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("displayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("emailVerified")
                        .HasColumnType("bit");

                    b.Property<bool?>("isLoggedin")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("photoURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            id = 1,
                            createdDate = new DateTime(2023, 4, 10, 13, 59, 28, 980, DateTimeKind.Local).AddTicks(9799),
                            displayName = "merve",
                            email = "merve@merve.com",
                            modifiedDate = new DateTime(2023, 4, 10, 13, 59, 28, 980, DateTimeKind.Local).AddTicks(9813),
                            uid = ""
                        });
                });

            modelBuilder.Entity("nc2.Models.PlannerNote", b =>
                {
                    b.HasBaseType("nc2.Models.Note");

                    b.Property<string>("day")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("header")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hour")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("PlannerNote");
                });

            modelBuilder.Entity("nc2.Models.Note", b =>
                {
                    b.HasOne("nc2.Models.Notebook", "Notebook")
                        .WithMany()
                        .HasForeignKey("notebookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notebook");
                });
#pragma warning restore 612, 618
        }
    }
}
