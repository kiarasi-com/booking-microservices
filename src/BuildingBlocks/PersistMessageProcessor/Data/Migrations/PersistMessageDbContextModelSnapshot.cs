﻿// <auto-generated />
using System;
using BuildingBlocks.PersistMessageProcessor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BuildingBlocks.PersistMessageProcessor.Data.Migrations
{
    [DbContext(typeof(PersistMessageDbContext))]
    partial class PersistMessageDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BuildingBlocks.PersistMessageProcessor.PersistMessage", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("Data")
                        .HasColumnType("text")
                        .HasColumnName("data");

                    b.Property<string>("DataType")
                        .HasColumnType("text")
                        .HasColumnName("data_type");

                    b.Property<string>("DeliveryType")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("Outbox")
                        .HasColumnName("delivery_type");

                    b.Property<string>("MessageStatus")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("InProgress")
                        .HasColumnName("message_status");

                    b.Property<int>("RetryCount")
                        .HasColumnType("integer")
                        .HasColumnName("retry_count");

                    b.HasKey("Id")
                        .HasName("pk_persist_message");

                    b.ToTable("persistMessage", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
