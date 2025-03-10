﻿// <auto-generated />
using LibraryManagementApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryManagementApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250226135527_InitialCreate1")]
    partial class InitialCreate1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryManagementApp.Model.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LibraryManagementApp.Model.Books", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BorrowCount")
                        .HasColumnType("int");

                    b.Property<int>("CopiesAvailable")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Author = "Ramesh Menon",
                            BorrowCount = 8,
                            CopiesAvailable = 25,
                            ISBN = "978-8129115356",
                            Title = "The Mahabharata"
                        },
                        new
                        {
                            Id = "2",
                            Author = "Ramesh Menon",
                            BorrowCount = 10,
                            CopiesAvailable = 30,
                            ISBN = "978-0312428032",
                            Title = "The Ramayana: A Modern Retelling"
                        },
                        new
                        {
                            Id = "3",
                            Author = "Ranjit Desai",
                            BorrowCount = 15,
                            CopiesAvailable = 20,
                            ISBN = "978-8172241215",
                            Title = "Shivaji: The Great Maratha"
                        },
                        new
                        {
                            Id = "4",
                            Author = "Ranjit Desai",
                            BorrowCount = 12,
                            CopiesAvailable = 25,
                            ISBN = "978-8177667843",
                            Title = "Swami"
                        },
                        new
                        {
                            Id = "5",
                            Author = "Ranjit Desai",
                            BorrowCount = 8,
                            CopiesAvailable = 45,
                            ISBN = "978-8177661018",
                            Title = "Radheya"
                        },
                        new
                        {
                            Id = "6",
                            Author = " V. P. Kale",
                            BorrowCount = 55,
                            CopiesAvailable = 35,
                            ISBN = "978-8184981073",
                            Title = "Partner"
                        },
                        new
                        {
                            Id = "7",
                            Author = " V. P. Kale",
                            BorrowCount = 16,
                            CopiesAvailable = 15,
                            ISBN = "978-8177665153",
                            Title = "Vapurza"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
