﻿// <auto-generated />
using System;
using ContactsAndDailyPlanner.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContactsAndDailyPlanner.Web.Migrations
{
    [DbContext(typeof(DailyAndContactsContext))]
    [Migration("20200727120921_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContactsAndDailyPlanner.DAL.Entities.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organisation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ContactsAndDailyPlanner.DAL.Entities.Email", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("ContactsAndDailyPlanner.DAL.Entities.OtherContactInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Others");
                });

            modelBuilder.Entity("ContactsAndDailyPlanner.DAL.Entities.Phone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("ContactsAndDailyPlanner.DAL.Entities.Skype", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SkypeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Skypes");
                });

            modelBuilder.Entity("ContactsAndDailyPlanner.DAL.Entities.Email", b =>
                {
                    b.HasOne("ContactsAndDailyPlanner.DAL.Entities.Contact", null)
                        .WithMany("Emails")
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("ContactsAndDailyPlanner.DAL.Entities.OtherContactInfo", b =>
                {
                    b.HasOne("ContactsAndDailyPlanner.DAL.Entities.Contact", null)
                        .WithMany("Others")
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("ContactsAndDailyPlanner.DAL.Entities.Phone", b =>
                {
                    b.HasOne("ContactsAndDailyPlanner.DAL.Entities.Contact", null)
                        .WithMany("Phones")
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("ContactsAndDailyPlanner.DAL.Entities.Skype", b =>
                {
                    b.HasOne("ContactsAndDailyPlanner.DAL.Entities.Contact", null)
                        .WithMany("Skypes")
                        .HasForeignKey("ContactId");
                });
#pragma warning restore 612, 618
        }
    }
}
