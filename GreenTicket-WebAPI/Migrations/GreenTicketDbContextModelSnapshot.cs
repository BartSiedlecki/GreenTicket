﻿// <auto-generated />
using System;
using GreenTicket_WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenTicketWebAPI.Migrations
{
    [DbContext(typeof(GreenTicketDbContext))]
    partial class GreenTicketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StreetNo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("VenueID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityID");

                    b.HasIndex("VenueID")
                        .IsUnique();

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("City", (string)null);
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("EndDateTime")
                        .HasPrecision(6)
                        .HasColumnType("datetime2(6)");

                    b.Property<int>("EventSubCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("LimitPerUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartDateTime")
                        .HasPrecision(6)
                        .HasColumnType("datetime2(6)");

                    b.Property<int>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventSubCategoryId");

                    b.HasIndex("VenueId");

                    b.ToTable("Event", (string)null);
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.EventCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("EventCategory", (string)null);
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.EventPerformer", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("PerformerId")
                        .HasColumnType("int");

                    b.HasKey("EventId", "PerformerId");

                    b.HasIndex("PerformerId");

                    b.ToTable("EventPerformer", (string)null);
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.EventSubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Subcategory")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("EventSubCategory", (string)null);
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("ImageType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Image", (string)null);
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Newsletter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IPAddress")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.ToTable("Newsletter", (string)null);
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Performer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Performer", (string)null);
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Row", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Row", (string)null);
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Seat", b =>
                {
                    b.Property<Guid>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("CustomPrice")
                        .HasColumnType("decimal(19, 4)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReservationSessionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestrictionDescpiption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RowId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Sold")
                        .HasColumnType("bit");

                    b.HasKey("SeatId");

                    b.HasIndex("RowId");

                    b.ToTable("Seat", (string)null);
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("IsStanding")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(19, 4)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Section", (string)null);
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Venue", (string)null);
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Address", b =>
                {
                    b.HasOne("GreenTicket_WebAPI.Entities.City", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenTicket_WebAPI.Entities.Venue", "Venue")
                        .WithOne("Address")
                        .HasForeignKey("GreenTicket_WebAPI.Entities.Address", "VenueID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Event", b =>
                {
                    b.HasOne("GreenTicket_WebAPI.Entities.EventSubCategory", "SubCategory")
                        .WithMany("Events")
                        .HasForeignKey("EventSubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenTicket_WebAPI.Entities.Venue", "Venue")
                        .WithMany("Event")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubCategory");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.EventPerformer", b =>
                {
                    b.HasOne("GreenTicket_WebAPI.Entities.Event", "Event")
                        .WithMany("EventPerformers")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenTicket_WebAPI.Entities.Performer", "Performer")
                        .WithMany("EventPerformers")
                        .HasForeignKey("PerformerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Performer");
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.EventSubCategory", b =>
                {
                    b.HasOne("GreenTicket_WebAPI.Entities.EventCategory", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Image", b =>
                {
                    b.HasOne("GreenTicket_WebAPI.Entities.Event", "Event")
                        .WithMany("Images")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Row", b =>
                {
                    b.HasOne("GreenTicket_WebAPI.Entities.Section", "Section")
                        .WithMany("Rows")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Seat", b =>
                {
                    b.HasOne("GreenTicket_WebAPI.Entities.Row", "Row")
                        .WithMany("Seats")
                        .HasForeignKey("RowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Row");
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Section", b =>
                {
                    b.HasOne("GreenTicket_WebAPI.Entities.Event", "Event")
                        .WithMany("Sections")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.City", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Event", b =>
                {
                    b.Navigation("EventPerformers");

                    b.Navigation("Images");

                    b.Navigation("Sections");
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.EventCategory", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.EventSubCategory", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Performer", b =>
                {
                    b.Navigation("EventPerformers");
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Row", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Section", b =>
                {
                    b.Navigation("Rows");
                });

            modelBuilder.Entity("GreenTicket_WebAPI.Entities.Venue", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Event");
                });
#pragma warning restore 612, 618
        }
    }
}
