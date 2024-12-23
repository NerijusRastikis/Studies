﻿// <auto-generated />
using ManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManyToMany.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20240904183441_CreatedConfigurationFolderAndConfiguredBookAndCategory")]
    partial class CreatedConfigurationFolderAndConfiguredBookAndCategory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookCategory", b =>
                {
                    b.Property<int>("BooksBookId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriesCategoryId")
                        .HasColumnType("int");

                    b.HasKey("BooksBookId", "CategoriesCategoryId");

                    b.HasIndex("CategoriesCategoryId");

                    b.ToTable("BookCategory");

                    b.HasData(
                        new
                        {
                            BooksBookId = 1,
                            CategoriesCategoryId = 1
                        },
                        new
                        {
                            BooksBookId = 1,
                            CategoriesCategoryId = 3
                        },
                        new
                        {
                            BooksBookId = 2,
                            CategoriesCategoryId = 1
                        },
                        new
                        {
                            BooksBookId = 3,
                            CategoriesCategoryId = 3
                        },
                        new
                        {
                            BooksBookId = 4,
                            CategoriesCategoryId = 1
                        },
                        new
                        {
                            BooksBookId = 4,
                            CategoriesCategoryId = 2
                        },
                        new
                        {
                            BooksBookId = 5,
                            CategoriesCategoryId = 2
                        },
                        new
                        {
                            BooksBookId = 6,
                            CategoriesCategoryId = 2
                        },
                        new
                        {
                            BooksBookId = 7,
                            CategoriesCategoryId = 2
                        });
                });

            modelBuilder.Entity("ManyToMany.Entities.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Name = "Hobbit",
                            Year = 1937
                        },
                        new
                        {
                            BookId = 2,
                            Name = "Lord of the Rings",
                            Year = 1954
                        },
                        new
                        {
                            BookId = 3,
                            Name = "Silmarillion",
                            Year = 1977
                        },
                        new
                        {
                            BookId = 4,
                            Name = "Hitchhiker's Guide to the Galaxy",
                            Year = 1979
                        },
                        new
                        {
                            BookId = 5,
                            Name = "Dune",
                            Year = 1965
                        },
                        new
                        {
                            BookId = 6,
                            Name = "Dune: House of Atreides",
                            Year = 1999
                        },
                        new
                        {
                            BookId = 7,
                            Name = "Dune: The Butlerian Jihad",
                            Year = 2002
                        });
                });

            modelBuilder.Entity("ManyToMany.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Adventure"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Science Fiction"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Fantasy"
                        });
                });

            modelBuilder.Entity("BookCategory", b =>
                {
                    b.HasOne("ManyToMany.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManyToMany.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
