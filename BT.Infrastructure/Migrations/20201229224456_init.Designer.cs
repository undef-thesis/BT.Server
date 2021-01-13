﻿// <auto-generated />
using System;
using BT.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BT.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201229224456_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BT.Domain.Domain.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Country")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Latitude")
                        .HasColumnType("double");

                    b.Property<double>("Longitude")
                        .HasColumnType("double");

                    b.Property<Guid>("MeetingId")
                        .HasColumnType("char(36)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Province")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Range")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("MeetingId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("BT.Domain.Domain.Avatar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Filename")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("longblob");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Avatar");
                });

            modelBuilder.Entity("BT.Domain.Domain.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3277bc53-8c45-4f55-972d-760517e8d0f9"),
                            CreatedAt = new DateTime(2020, 12, 29, 22, 44, 56, 357, DateTimeKind.Utc).AddTicks(8105),
                            Name = "Basketball",
                            UpdatedAt = new DateTime(2020, 12, 29, 22, 44, 56, 357, DateTimeKind.Utc).AddTicks(8548)
                        },
                        new
                        {
                            Id = new Guid("7d6b1a9e-bd1e-45d2-8850-90d8ef6bdfd2"),
                            CreatedAt = new DateTime(2020, 12, 29, 22, 44, 56, 357, DateTimeKind.Utc).AddTicks(9117),
                            Name = "Football",
                            UpdatedAt = new DateTime(2020, 12, 29, 22, 44, 56, 357, DateTimeKind.Utc).AddTicks(9121)
                        },
                        new
                        {
                            Id = new Guid("8a2dd26e-9ed9-4956-b692-110c6229aba6"),
                            CreatedAt = new DateTime(2020, 12, 29, 22, 44, 56, 357, DateTimeKind.Utc).AddTicks(9124),
                            Name = "Hokey",
                            UpdatedAt = new DateTime(2020, 12, 29, 22, 44, 56, 357, DateTimeKind.Utc).AddTicks(9125)
                        },
                        new
                        {
                            Id = new Guid("50b2679d-1a8b-435c-874e-25fd7071866b"),
                            CreatedAt = new DateTime(2020, 12, 29, 22, 44, 56, 357, DateTimeKind.Utc).AddTicks(9128),
                            Name = "Running",
                            UpdatedAt = new DateTime(2020, 12, 29, 22, 44, 56, 357, DateTimeKind.Utc).AddTicks(9129)
                        },
                        new
                        {
                            Id = new Guid("06cdb787-4bfe-4537-85f9-53f206b70757"),
                            CreatedAt = new DateTime(2020, 12, 29, 22, 44, 56, 357, DateTimeKind.Utc).AddTicks(9132),
                            Name = "Ski",
                            UpdatedAt = new DateTime(2020, 12, 29, 22, 44, 56, 357, DateTimeKind.Utc).AddTicks(9133)
                        });
                });

            modelBuilder.Entity("BT.Domain.Domain.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CountryCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("BT.Domain.Domain.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("MeetingId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("MeetingId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BT.Domain.Domain.Meeting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("MaxParticipants")
                        .HasColumnType("int");

                    b.Property<Guid>("MeetingOrganizerId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ParticipantCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MeetingOrganizerId");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("BT.Domain.Domain.MeetingImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Filename")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("MeetingId")
                        .HasColumnType("char(36)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.HasIndex("MeetingId");

                    b.ToTable("MeetingImages");
                });

            modelBuilder.Entity("BT.Domain.Domain.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Token")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("BT.Domain.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Firstname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Lastname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("longblob");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BT.Domain.Domain.UserMeeting", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MeetingId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "MeetingId");

                    b.HasIndex("MeetingId");

                    b.ToTable("UserMeeting");
                });

            modelBuilder.Entity("BT.Domain.Domain.Address", b =>
                {
                    b.HasOne("BT.Domain.Domain.Meeting", "Meeting")
                        .WithOne("Address")
                        .HasForeignKey("BT.Domain.Domain.Address", "MeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BT.Domain.Domain.Avatar", b =>
                {
                    b.HasOne("BT.Domain.Domain.User", "User")
                        .WithOne("Avatar")
                        .HasForeignKey("BT.Domain.Domain.Avatar", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BT.Domain.Domain.Comment", b =>
                {
                    b.HasOne("BT.Domain.Domain.Meeting", "Meeting")
                        .WithMany("Comments")
                        .HasForeignKey("MeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BT.Domain.Domain.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BT.Domain.Domain.Meeting", b =>
                {
                    b.HasOne("BT.Domain.Domain.Category", "Category")
                        .WithMany("Meetings")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BT.Domain.Domain.User", "MeetingOrganizer")
                        .WithMany("OrganizedMeetings")
                        .HasForeignKey("MeetingOrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BT.Domain.Domain.MeetingImage", b =>
                {
                    b.HasOne("BT.Domain.Domain.Meeting", "Meeting")
                        .WithMany("Images")
                        .HasForeignKey("MeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BT.Domain.Domain.RefreshToken", b =>
                {
                    b.HasOne("BT.Domain.Domain.User", "User")
                        .WithOne("RefreshToken")
                        .HasForeignKey("BT.Domain.Domain.RefreshToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BT.Domain.Domain.UserMeeting", b =>
                {
                    b.HasOne("BT.Domain.Domain.Meeting", "Meeting")
                        .WithMany("Participants")
                        .HasForeignKey("MeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BT.Domain.Domain.User", "User")
                        .WithMany("EnrolledMeetings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}