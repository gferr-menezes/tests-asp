﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProfileModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("longtext")
                        .HasColumnName("avatar_url");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("profiles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a2bf83f7-1e91-438a-a204-56064519acb2"),
                            CreatedAt = new DateTime(2023, 10, 20, 17, 38, 13, 291, DateTimeKind.Utc).AddTicks(3770),
                            Name = "guilherme ferreira",
                            UserId = new Guid("a2bf83f7-1e91-438a-a204-56064519acb1")
                        });
                });

            modelBuilder.Entity("UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a2bf83f7-1e91-438a-a204-56064519acb1"),
                            CreatedAt = new DateTime(2023, 10, 20, 17, 38, 13, 287, DateTimeKind.Utc).AddTicks(3780),
                            Email = "test@mail.com",
                            Password = "zIVCKEz8wjw/GSaw8nyrh59ztQup5gv/eQ5dyWhckF8="
                        });
                });

            modelBuilder.Entity("ProfileModel", b =>
                {
                    b.HasOne("UserModel", "User")
                        .WithOne("Profile")
                        .HasForeignKey("ProfileModel", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserModel", b =>
                {
                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}
