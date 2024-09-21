﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tuna_Piano;

#nullable disable

namespace Tuna_Piano.Migrations
{
    [DbContext(typeof(TunaPianoDbContext))]
    [Migration("20240909225034_NewItems")]
    partial class NewItems
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GenreSong", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("integer");

                    b.Property<int>("SongsId")
                        .HasColumnType("integer");

                    b.HasKey("GenresId", "SongsId");

                    b.HasIndex("SongsId");

                    b.ToTable("GenreSong");
                });

            modelBuilder.Entity("Tuna_Piano.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 21,
                            Bio = "Bio 1",
                            Name = "Name 1"
                        },
                        new
                        {
                            Id = 2,
                            Age = 22,
                            Bio = "Bio 2",
                            Name = "Name 2"
                        },
                        new
                        {
                            Id = 3,
                            Age = 23,
                            Bio = "Bio 3",
                            Name = "Name 3"
                        },
                        new
                        {
                            Id = 4,
                            Age = 24,
                            Bio = "Bio 4",
                            Name = "Name 4"
                        });
                });

            modelBuilder.Entity("Tuna_Piano.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Genre 1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Genre 2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Genre 3"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Genre 4"
                        });
                });

            modelBuilder.Entity("Tuna_Piano.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Album")
                        .HasColumnType("text");

                    b.Property<int>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("length")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Album = "Album",
                            ArtistId = 1,
                            Title = "SongTitle",
                            length = 0
                        },
                        new
                        {
                            Id = 2,
                            Album = "Album",
                            ArtistId = 2,
                            Title = "SongTitle",
                            length = 0
                        },
                        new
                        {
                            Id = 3,
                            Album = "Album",
                            ArtistId = 2,
                            Title = "SongTitle",
                            length = 0
                        },
                        new
                        {
                            Id = 4,
                            Album = "Album",
                            ArtistId = 1,
                            Title = "SongTitle",
                            length = 0
                        });
                });

            modelBuilder.Entity("GenreSong", b =>
                {
                    b.HasOne("Tuna_Piano.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tuna_Piano.Models.Song", null)
                        .WithMany()
                        .HasForeignKey("SongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tuna_Piano.Models.Song", b =>
                {
                    b.HasOne("Tuna_Piano.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("Tuna_Piano.Models.Artist", b =>
                {
                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
