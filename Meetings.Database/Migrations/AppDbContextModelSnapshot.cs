﻿// <auto-generated />
using System;
using Meetings.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Meetings.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Meetings.Domain.Entities.AvailableDateDto", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(26)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("MeetingId")
                        .HasColumnType("nvarchar(26)");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("AvailableDates", (string)null);
                });

            modelBuilder.Entity("Meetings.Domain.Entities.Meeting", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(26)");

                    b.Property<string>("AvailableDateId")
                        .HasColumnType("nvarchar(26)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("PaymentId")
                        .HasColumnType("nvarchar(26)");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("AvailableDateId")
                        .IsUnique()
                        .HasFilter("[AvailableDateId] IS NOT NULL");

                    b.HasIndex("PaymentId")
                        .IsUnique()
                        .HasFilter("[PaymentId] IS NOT NULL");

                    b.ToTable("Meetings", null, t =>
                        {
                            t.Property("Id")
                                .HasColumnName("Meeting_Id");
                        });
                });

            modelBuilder.Entity("Meetings.Domain.Entities.Payment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(26)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("MeetingId")
                        .HasColumnType("nvarchar(26)");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Payments", (string)null);
                });

            modelBuilder.Entity("Meetings.Domain.Entities.AvailableDateDto", b =>
                {
                    b.OwnsOne("Meetings.Domain.ValueObjects.CreationInfo", "CreationInfo", b1 =>
                        {
                            b1.Property<string>("AvailableDateId")
                                .HasColumnType("nvarchar(26)");

                            b1.Property<DateTimeOffset>("CreatedAt")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("CreatedAt");

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("CreatedBy");

                            b1.Property<string>("CreatedById")
                                .IsRequired()
                                .HasColumnType("nvarchar(26)")
                                .HasColumnName("CreatedById");

                            b1.HasKey("AvailableDateId");

                            b1.ToTable("AvailableDates");

                            b1.WithOwner()
                                .HasForeignKey("AvailableDateId");
                        });

                    b.OwnsOne("Meetings.Domain.ValueObjects.UpdateInfo", "UpdateInfo", b1 =>
                        {
                            b1.Property<string>("AvailableDateId")
                                .HasColumnType("nvarchar(26)");

                            b1.Property<DateTimeOffset?>("UpdatedAt")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("UpdatedAt");

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("UpdatedBy");

                            b1.Property<string>("UpdatedById")
                                .IsRequired()
                                .HasColumnType("nvarchar(26)")
                                .HasColumnName("UpdatedById");

                            b1.HasKey("AvailableDateId");

                            b1.ToTable("AvailableDates");

                            b1.WithOwner()
                                .HasForeignKey("AvailableDateId");
                        });

                    b.OwnsOne("Meetings.Domain.ValueObjects.MeetingData", "MeetingData", b1 =>
                        {
                            b1.Property<string>("AvailableDateId")
                                .HasColumnType("nvarchar(26)");

                            b1.Property<DateTimeOffset>("From")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("From");

                            b1.Property<DateTimeOffset>("To")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("To");

                            b1.HasKey("AvailableDateId");

                            b1.ToTable("AvailableDates");

                            b1.WithOwner()
                                .HasForeignKey("AvailableDateId");
                        });

                    b.Navigation("CreationInfo");

                    b.Navigation("MeetingData");

                    b.Navigation("UpdateInfo");
                });

            modelBuilder.Entity("Meetings.Domain.Entities.Meeting", b =>
                {
                    b.HasOne("Meetings.Domain.Entities.AvailableDateDto", "AvailableDateDto")
                        .WithOne("Meeting")
                        .HasForeignKey("Meetings.Domain.Entities.Meeting", "AvailableDateId");

                    b.HasOne("Meetings.Domain.Entities.Payment", "Payment")
                        .WithOne("Meeting")
                        .HasForeignKey("Meetings.Domain.Entities.Meeting", "PaymentId");

                    b.OwnsOne("Meetings.Domain.ValueObjects.CreationInfo", "CreationInfo", b1 =>
                        {
                            b1.Property<string>("MeetingId")
                                .HasColumnType("nvarchar(26)");

                            b1.Property<DateTimeOffset>("CreatedAt")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("CreatedAt");

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("CreatedBy");

                            b1.Property<string>("CreatedById")
                                .IsRequired()
                                .HasColumnType("nvarchar(26)")
                                .HasColumnName("CreatedById");

                            b1.HasKey("MeetingId");

                            b1.ToTable("Meetings");

                            b1.WithOwner()
                                .HasForeignKey("MeetingId");
                        });

                    b.OwnsOne("Meetings.Domain.ValueObjects.UpdateInfo", "UpdateInfo", b1 =>
                        {
                            b1.Property<string>("MeetingId")
                                .HasColumnType("nvarchar(26)");

                            b1.Property<DateTimeOffset?>("UpdatedAt")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("UpdatedAt");

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("UpdatedBy");

                            b1.Property<string>("UpdatedById")
                                .IsRequired()
                                .HasColumnType("nvarchar(26)")
                                .HasColumnName("UpdatedById");

                            b1.HasKey("MeetingId");

                            b1.ToTable("Meetings");

                            b1.WithOwner()
                                .HasForeignKey("MeetingId");
                        });

                    b.OwnsOne("Meetings.Domain.ValueObjects.UserData", "UserData", b1 =>
                        {
                            b1.Property<string>("MeetingId")
                                .HasColumnType("nvarchar(26)");

                            b1.Property<string>("Id")
                                .HasColumnType("nvarchar(26)")
                                .HasColumnName("Id");

                            b1.HasKey("MeetingId");

                            b1.ToTable("Meetings");

                            b1.WithOwner()
                                .HasForeignKey("MeetingId");
                        });

                    b.Navigation("AvailableDateDto");

                    b.Navigation("CreationInfo");

                    b.Navigation("Payment");

                    b.Navigation("UpdateInfo");

                    b.Navigation("UserData");
                });

            modelBuilder.Entity("Meetings.Domain.Entities.Payment", b =>
                {
                    b.OwnsOne("Meetings.Domain.ValueObjects.CreationInfo", "CreationInfo", b1 =>
                        {
                            b1.Property<string>("PaymentId")
                                .HasColumnType("nvarchar(26)");

                            b1.Property<DateTimeOffset>("CreatedAt")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("CreatedAt");

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("CreatedBy");

                            b1.Property<string>("CreatedById")
                                .IsRequired()
                                .HasColumnType("nvarchar(26)")
                                .HasColumnName("CreatedById");

                            b1.HasKey("PaymentId");

                            b1.ToTable("Payments");

                            b1.WithOwner()
                                .HasForeignKey("PaymentId");
                        });

                    b.OwnsOne("Meetings.Domain.ValueObjects.UpdateInfo", "UpdateInfo", b1 =>
                        {
                            b1.Property<string>("PaymentId")
                                .HasColumnType("nvarchar(26)");

                            b1.Property<DateTimeOffset?>("UpdatedAt")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("UpdatedAt");

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("UpdatedBy");

                            b1.Property<string>("UpdatedById")
                                .IsRequired()
                                .HasColumnType("nvarchar(26)")
                                .HasColumnName("UpdatedById");

                            b1.HasKey("PaymentId");

                            b1.ToTable("Payments");

                            b1.WithOwner()
                                .HasForeignKey("PaymentId");
                        });

                    b.OwnsOne("Meetings.Domain.ValueObjects.Amount", "Amount", b1 =>
                        {
                            b1.Property<string>("PaymentId")
                                .HasColumnType("nvarchar(26)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasMaxLength(4)
                                .HasColumnType("nvarchar(4)")
                                .HasColumnName("Currency");

                            b1.Property<long>("Decimal")
                                .HasColumnType("bigint")
                                .HasColumnName("Decimal");

                            b1.Property<long>("TotalPart")
                                .HasColumnType("bigint")
                                .HasColumnName("TotalPart");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Value");

                            b1.HasKey("PaymentId");

                            b1.ToTable("Payments");

                            b1.WithOwner()
                                .HasForeignKey("PaymentId");
                        });

                    b.Navigation("Amount");

                    b.Navigation("CreationInfo");

                    b.Navigation("UpdateInfo");
                });

            modelBuilder.Entity("Meetings.Domain.Entities.AvailableDateDto", b =>
                {
                    b.Navigation("Meeting");
                });

            modelBuilder.Entity("Meetings.Domain.Entities.Payment", b =>
                {
                    b.Navigation("Meeting");
                });
#pragma warning restore 612, 618
        }
    }
}
