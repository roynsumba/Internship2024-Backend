﻿// <auto-generated />
using System;
using AppraisalTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppraisalTracker.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240812073856_secondmigrations")]
    partial class secondmigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AppraisalTracker.Modules.AppraisalActivity.Models.ConfigMenuItem", b =>
                {
                    b.Property<Guid>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FieldDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("ItemId");

                    b.ToTable("ConfigMenuItems");
                });

            modelBuilder.Entity("AppraisalTracker.Modules.AppraisalActivity.Models.Implementation", b =>
                {
                    b.Property<Guid>("ImplementationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Evidence")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("EvidenceContentType")
                        .HasColumnType("text");

                    b.Property<string>("EvidenceFileName")
                        .HasColumnType("text");

                    b.Property<Guid>("MeasurableActivityId")
                        .HasColumnType("uuid");

                    b.Property<string>("Stakeholder")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("ImplementationId");

                    b.HasIndex("MeasurableActivityId");

                    b.ToTable("Implementations");
                });

            modelBuilder.Entity("AppraisalTracker.Modules.AppraisalActivity.Models.MeasurableActivity", b =>
                {
                    b.Property<Guid>("MeasurableActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ActivityId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("InitiativeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PeriodId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PerspectiveId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SsMartaObjectivesId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("MeasurableActivityId");

                    b.HasIndex("ActivityId");

                    b.HasIndex("InitiativeId");

                    b.HasIndex("PeriodId");

                    b.HasIndex("PerspectiveId");

                    b.HasIndex("SsMartaObjectivesId");

                    b.ToTable("MeasurableActivities");
                });

            modelBuilder.Entity("AppraisalTracker.Modules.Users.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AppraisalTracker.Modules.AppraisalActivity.Models.Implementation", b =>
                {
                    b.HasOne("AppraisalTracker.Modules.AppraisalActivity.Models.MeasurableActivity", "MeasurableActivity")
                        .WithMany("Implementation")
                        .HasForeignKey("MeasurableActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeasurableActivity");
                });

            modelBuilder.Entity("AppraisalTracker.Modules.AppraisalActivity.Models.MeasurableActivity", b =>
                {
                    b.HasOne("AppraisalTracker.Modules.AppraisalActivity.Models.ConfigMenuItem", "ConfigActivityId")
                        .WithMany()
                        .HasForeignKey("ActivityId");

                    b.HasOne("AppraisalTracker.Modules.AppraisalActivity.Models.ConfigMenuItem", "ConfigInitiativeId")
                        .WithMany()
                        .HasForeignKey("InitiativeId");

                    b.HasOne("AppraisalTracker.Modules.AppraisalActivity.Models.ConfigMenuItem", "ConfigPeriodId")
                        .WithMany()
                        .HasForeignKey("PeriodId");

                    b.HasOne("AppraisalTracker.Modules.AppraisalActivity.Models.ConfigMenuItem", "ConfigPerspectiveId")
                        .WithMany()
                        .HasForeignKey("PerspectiveId");

                    b.HasOne("AppraisalTracker.Modules.AppraisalActivity.Models.ConfigMenuItem", "ConfigSsMartaObjectivesId")
                        .WithMany()
                        .HasForeignKey("SsMartaObjectivesId");

                    b.Navigation("ConfigActivityId");

                    b.Navigation("ConfigInitiativeId");

                    b.Navigation("ConfigPeriodId");

                    b.Navigation("ConfigPerspectiveId");

                    b.Navigation("ConfigSsMartaObjectivesId");
                });

            modelBuilder.Entity("AppraisalTracker.Modules.AppraisalActivity.Models.MeasurableActivity", b =>
                {
                    b.Navigation("Implementation");
                });
#pragma warning restore 612, 618
        }
    }
}
