﻿// <auto-generated />
using backend.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace backend.Migrations
{
    [DbContext(typeof(ExpertChoiceContext))]
    partial class ExpertChoiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("backend.Database.Models.Chart", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Charts");
                });

            modelBuilder.Entity("backend.Database.Models.DataChart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChartId");

                    b.Property<string>("Color");

                    b.Property<int?>("DemandTypeId");

                    b.Property<string>("Label");

                    b.Property<int?>("ModifierTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ChartId");

                    b.HasIndex("DemandTypeId");

                    b.HasIndex("ModifierTypeId");

                    b.ToTable("DataCharts");
                });

            modelBuilder.Entity("backend.Database.Models.DemandType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("DemandTypes");
                });

            modelBuilder.Entity("backend.Database.Models.IntervalSolution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Formulation");

                    b.Property<float>("Result");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("IntervalSolutions");
                });

            modelBuilder.Entity("backend.Database.Models.ModifierType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("ModifierTypes");
                });

            modelBuilder.Entity("backend.Database.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("backend.Database.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DataChartId");

                    b.Property<float>("X");

                    b.Property<float>("Y");

                    b.HasKey("Id");

                    b.HasIndex("DataChartId");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("backend.Database.Models.Chart", b =>
                {
                    b.HasOne("backend.Database.Models.IntervalSolution", "IntervalSolution")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("backend.Database.Models.DataChart", b =>
                {
                    b.HasOne("backend.Database.Models.Chart", "Chart")
                        .WithMany("DataCharts")
                        .HasForeignKey("ChartId");

                    b.HasOne("backend.Database.Models.DemandType", "DemandType")
                        .WithMany("DataCharts")
                        .HasForeignKey("DemandTypeId");

                    b.HasOne("backend.Database.Models.ModifierType", "ModifierType")
                        .WithMany("DataCharts")
                        .HasForeignKey("ModifierTypeId");
                });

            modelBuilder.Entity("backend.Database.Models.IntervalSolution", b =>
                {
                    b.HasOne("backend.Database.Models.User", "User")
                        .WithMany("IntervalSolutions")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("backend.Database.Models.Value", b =>
                {
                    b.HasOne("backend.Database.Models.DataChart", "DataChart")
                        .WithMany("Values")
                        .HasForeignKey("DataChartId");
                });
#pragma warning restore 612, 618
        }
    }
}
