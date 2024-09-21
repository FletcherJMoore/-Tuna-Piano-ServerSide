namespace Tuna_Piano;
using Microsoft.EntityFrameworkCore;
using Tuna_Piano.Models;
    public class TunaPianoDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Song>().HasData(new Song[]
        {
        new Song {Id = 1, Title = "SongTitle", ArtistId = 1, Album = "Album"},
        new Song {Id = 2, Title = "SongTitle", ArtistId = 2, Album = "Album"},
        new Song {Id = 3, Title = "SongTitle", ArtistId = 2, Album = "Album"},
        new Song {Id = 4, Title = "SongTitle", ArtistId = 1, Album = "Album" }
        });

        modelBuilder.Entity<Genre>().HasData(new Genre[]
        {
            new Genre {Id = 1, Description = "Genre 1"},
            new Genre {Id = 2, Description = "Genre 2"},
            new Genre {Id = 3, Description = "Genre 3"},
            new Genre {Id = 4, Description = "Genre 4" },
        });

        modelBuilder.Entity<Artist>().HasData(new Artist[]
        {
            new Artist {Id = 1, Name = "Name 1", Age = 21, Bio = "Bio 1"},
            new Artist {Id = 2, Name = "Name 2", Age = 22, Bio = "Bio 2"},
            new Artist {Id = 3, Name = "Name 3", Age = 23, Bio = "Bio 3"},
            new Artist {Id = 4, Name = "Name 4", Age = 24, Bio = "Bio 4"}
        });
    }


    public TunaPianoDbContext(DbContextOptions<TunaPianoDbContext> context) : base(context)
        {

        }
    }

