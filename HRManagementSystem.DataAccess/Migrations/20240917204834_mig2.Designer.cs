﻿// <auto-generated />
using System;
using HRManagementSystem.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HRManagementSystem.DataAccess.Migrations
{
    [DbContext(typeof(HRContext))]
    [Migration("20240917204834_mig2")]
    partial class mig2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HRManagementSystem.Entity.Concrete.Advertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("HRManagementSystem.Entity.Concrete.AdvertisementAppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdvertisementAppUserStatusId")
                        .HasColumnType("int");

                    b.Property<int>("AdvertisementId")
                        .HasColumnType("int");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("CvPath")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MilitaryStatusId")
                        .HasColumnType("int");

                    b.Property<int>("WorkExperince")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementAppUserStatusId");

                    b.HasIndex("AppUserId");

                    b.HasIndex("MilitaryStatusId");

                    b.HasIndex("AdvertisementId", "AppUserId")
                        .IsUnique();

                    b.ToTable("AdvertisementAppUsers");
                });

            modelBuilder.Entity("HRManagementSystem.Entity.Concrete.AdvertisementAppUserStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("AdvertisementAppUserStatus");
                });

            modelBuilder.Entity("HRManagementSystem.Entity.Concrete.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.HasKey("Id");

                    b.ToTable("AppRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Definition = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Definition = "Member"
                        });
                });

            modelBuilder.Entity("HRManagementSystem.Entity.Concrete.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("HRManagementSystem.Entity.Concrete.AppUserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppRoleId")
                        .HasColumnType("int");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("AppRoleId", "AppUserId")
                        .IsUnique();

                    b.ToTable("AppUserRoles");
                });

            modelBuilder.Entity("HRManagementSystem.Entity.Concrete.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("HRManagementSystem.Entity.Concrete.MilitaryStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.HasKey("Id");

                    b.ToTable("MilitaryStatuses");
                });

            modelBuilder.Entity("HRManagementSystem.Entity.Concrete.ProvidedService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("ProvidedServices");
                });

            modelBuilder.Entity("HRManagementSystem.Entity.Concrete.AdvertisementAppUser", b =>
                {
                    b.HasOne("HRManagementSystem.Entity.Concrete.AdvertisementAppUserStatus", "AdvertisementAppUserStatus")
                        .WithMany("AdvertisementAppUsers")
                        .HasForeignKey("AdvertisementAppUserStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRManagementSystem.Entity.Concrete.Advertisement", "Advertisement")
                        .WithMany("AdvertisementAppUsers")
                        .HasForeignKey("AdvertisementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRManagementSystem.Entity.Concrete.AppUser", "AppUser")
                        .WithMany("AdvertisementAppUsers")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRManagementSystem.Entity.Concrete.MilitaryStatus", "MilitaryStatus")
                        .WithMany("AdvertisementAppUsers")
                        .HasForeignKey("MilitaryStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advertisement");

                    b.Navigation("AdvertisementAppUserStatus");

                    b.Navigation("AppUser");

                    b.Navigation("MilitaryStatus");
                });

            modelBuilder.Entity("HRManagementSystem.Entity.Concrete.AppUser", b =>
                {
                    b.HasOne("HRManagementSystem.Entity.Concrete.Gender", "Gender")
                        .WithMany("AppUsers")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("HRManagementSystem.Entity.Concrete.AppUserRole", b =>
                {
                    b.HasOne("HRManagementSystem.Entity.Concrete.AppRole", "AppRole")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("AppRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRManagementSystem.Entity.Concrete.AppUser", "AppUser")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppRole");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("HRManagementSystem.Entity.Concrete.Advertisement", b =>
                {
                    b.Navigation("AdvertisementAppUsers");
                });

            modelBuilder.Entity("HRManagementSystem.Entity.Concrete.AdvertisementAppUserStatus", b =>
                {
                    b.Navigation("AdvertisementAppUsers");
                });

            modelBuilder.Entity("HRManagementSystem.Entity.Concrete.AppRole", b =>
                {
                    b.Navigation("AppUserRoles");
                });

            modelBuilder.Entity("HRManagementSystem.Entity.Concrete.AppUser", b =>
                {
                    b.Navigation("AdvertisementAppUsers");

                    b.Navigation("AppUserRoles");
                });

            modelBuilder.Entity("HRManagementSystem.Entity.Concrete.Gender", b =>
                {
                    b.Navigation("AppUsers");
                });

            modelBuilder.Entity("HRManagementSystem.Entity.Concrete.MilitaryStatus", b =>
                {
                    b.Navigation("AdvertisementAppUsers");
                });
#pragma warning restore 612, 618
        }
    }
}