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
    [Migration("20230414125942_fixmanyyy")]
    partial class fixmanyyy
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("nc2.Models.Cloud", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Clouds");
                });

            modelBuilder.Entity("nc2.Models.Note", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("day")
                        .HasColumnType("int");

                    b.Property<string>("header")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isChecked")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("noteType")
                        .HasColumnType("int");

                    b.Property<int>("notebookId")
                        .HasColumnType("int");

                    b.Property<string>("stickerNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("stickerType")
                        .HasColumnType("int");

                    b.Property<string>("textNote")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("notebookId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("nc2.Models.Notebook", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("addedBy")
                        .HasColumnType("int");

                    b.Property<int?>("checkedCount")
                        .HasColumnType("int");

                    b.Property<int>("cloudId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("imageCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("notebookType")
                        .HasColumnType("int");

                    b.Property<int?>("shareStatus")
                        .HasColumnType("int");

                    b.Property<int?>("textCount")
                        .HasColumnType("int");

                    b.Property<int?>("uncheckedCount")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("cloudId");

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
                });

            modelBuilder.Entity("nc2.Models.UserCloud", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("cloudId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("cloudId");

                    b.HasIndex("userId");

                    b.ToTable("UsersClouds");
                });

            modelBuilder.Entity("nc2.Models.UserNotebook", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("notebookId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("notebookId");

                    b.HasIndex("userId");

                    b.ToTable("UserNotebooks");
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

            modelBuilder.Entity("nc2.Models.Notebook", b =>
                {
                    b.HasOne("nc2.Models.Cloud", "Cloud")
                        .WithMany()
                        .HasForeignKey("cloudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cloud");
                });

            modelBuilder.Entity("nc2.Models.UserCloud", b =>
                {
                    b.HasOne("nc2.Models.Cloud", "Cloud")
                        .WithMany()
                        .HasForeignKey("cloudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("nc2.Models.User", "User")
                        .WithMany("userClouds")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cloud");

                    b.Navigation("User");
                });

            modelBuilder.Entity("nc2.Models.UserNotebook", b =>
                {
                    b.HasOne("nc2.Models.Notebook", "Notebook")
                        .WithMany()
                        .HasForeignKey("notebookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("nc2.Models.User", "User")
                        .WithMany("userNotebooks")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notebook");

                    b.Navigation("User");
                });

            modelBuilder.Entity("nc2.Models.User", b =>
                {
                    b.Navigation("userClouds");

                    b.Navigation("userNotebooks");
                });
#pragma warning restore 612, 618
        }
    }
}
