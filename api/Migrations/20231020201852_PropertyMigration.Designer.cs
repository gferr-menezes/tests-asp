﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20231020201852_PropertyMigration")]
    partial class PropertyMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            CreatedAt = new DateTime(2023, 10, 20, 20, 18, 52, 747, DateTimeKind.Utc).AddTicks(7680),
                            Name = "guilherme ferreira",
                            UserId = new Guid("a2bf83f7-1e91-438a-a204-56064519acb1")
                        });
                });

            modelBuilder.Entity("PropertyModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("city");

                    b.Property<string>("Complement")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("complement");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(10,8)")
                        .HasColumnName("latitude");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(11,8)")
                        .HasColumnName("longitude");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("neighborhood");

                    b.Property<string>("Number")
                        .HasColumnType("varchar(10)")
                        .HasColumnName("number");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("char(36)")
                        .HasColumnName("owner_id");

                    b.Property<Guid>("ResponsibleId")
                        .HasColumnType("char(36)")
                        .HasColumnName("responsible_id");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasColumnName("state");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<decimal>("ValueRent")
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("value_rent");

                    b.Property<decimal>("ValueSale")
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("value_sale");

                    b.Property<string>("ZipCode")
                        .HasColumnType("varchar(10)")
                        .HasColumnName("zip_code");

                    b.HasKey("Id");

                    b.HasIndex("ResponsibleId");

                    b.ToTable("properties");
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
                            CreatedAt = new DateTime(2023, 10, 20, 20, 18, 52, 743, DateTimeKind.Utc).AddTicks(3670),
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

            modelBuilder.Entity("PropertyModel", b =>
                {
                    b.HasOne("UserModel", "Responsible")
                        .WithMany()
                        .HasForeignKey("ResponsibleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Responsible");
                });

            modelBuilder.Entity("UserModel", b =>
                {
                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}
