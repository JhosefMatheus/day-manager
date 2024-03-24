﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Models;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(DayContext))]
    [Migration("20240324180454_AddTaskDayConstraints")]
    partial class AddTaskDayConstraints
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("backend.Models.TaskDayModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Day")
                        .HasColumnType("int")
                        .HasColumnName("day");

                    b.Property<int>("TaskId")
                        .HasColumnType("int")
                        .HasColumnName("task_id");

                    b.HasKey("Id");

                    b.HasIndex("TaskId", "Day")
                        .IsUnique();

                    b.ToTable("task_day");
                });

            modelBuilder.Entity("backend.Models.TaskModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<bool>("Done")
                        .HasColumnType("bit")
                        .HasColumnName("done");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("name");

                    b.Property<int>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("type_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.HasIndex("Name", "UserId", "TypeId")
                        .IsUnique();

                    b.ToTable("task");
                });

            modelBuilder.Entity("backend.Models.TaskTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("task_type");
                });

            modelBuilder.Entity("backend.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("login");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("user");
                });

            modelBuilder.Entity("backend.Models.TaskDayModel", b =>
                {
                    b.HasOne("backend.Models.TaskModel", "Task")
                        .WithMany("TaskDays")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("backend.Models.TaskModel", b =>
                {
                    b.HasOne("backend.Models.TaskTypeModel", "Type")
                        .WithMany("Tasks")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.UserModel", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");

                    b.Navigation("User");
                });

            modelBuilder.Entity("backend.Models.TaskModel", b =>
                {
                    b.Navigation("TaskDays");
                });

            modelBuilder.Entity("backend.Models.TaskTypeModel", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("backend.Models.UserModel", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}