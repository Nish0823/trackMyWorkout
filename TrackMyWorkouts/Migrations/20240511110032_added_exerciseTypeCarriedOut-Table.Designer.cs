﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrackMyWorkouts.Data;

#nullable disable

namespace TrackMyWorkouts.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240511110032_added_exerciseTypeCarriedOut-Table")]
    partial class added_exerciseTypeCarriedOutTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrackMyWorkouts.Data.DataModels.ExerciseCarriedOut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExerciseDate")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.ToTable("ExerciseCarriedOut");
                });

            modelBuilder.Entity("TrackMyWorkouts.Data.DataModels.ExerciseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExerciseType");
                });

            modelBuilder.Entity("TrackMyWorkouts.Data.DataModels.ExerciseTypeCarriedOut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseCarriedOutId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseCarriedOutId");

                    b.HasIndex("ExerciseTypeId");

                    b.ToTable("ExerciseTypeCarriedOut");
                });

            modelBuilder.Entity("TrackMyWorkouts.Data.DataModels.TestData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("TrackMyWorkouts.Data.DataModels.ExerciseTypeCarriedOut", b =>
                {
                    b.HasOne("TrackMyWorkouts.Data.DataModels.ExerciseCarriedOut", "ExerciseCarriesOut")
                        .WithMany("ExerciseTypesCarriedOut")
                        .HasForeignKey("ExerciseCarriedOutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrackMyWorkouts.Data.DataModels.ExerciseType", "ExerciseType")
                        .WithMany("ExercisesCarriedOut")
                        .HasForeignKey("ExerciseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseCarriesOut");

                    b.Navigation("ExerciseType");
                });

            modelBuilder.Entity("TrackMyWorkouts.Data.DataModels.ExerciseCarriedOut", b =>
                {
                    b.Navigation("ExerciseTypesCarriedOut");
                });

            modelBuilder.Entity("TrackMyWorkouts.Data.DataModels.ExerciseType", b =>
                {
                    b.Navigation("ExercisesCarriedOut");
                });
#pragma warning restore 612, 618
        }
    }
}