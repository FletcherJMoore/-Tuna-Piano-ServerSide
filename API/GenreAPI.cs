
using Microsoft.EntityFrameworkCore;
using Tuna_Piano.Models;
using Tuna_Piano.DTO;

namespace Tuna_Piano.API
{
    public class GenreAPI
    {
        public static void Map(WebApplication app)

        {
            //Get all genres
            app.MapGet("/genres", (TunaPianoDbContext db) =>
            {
                return db.Genres.ToList();
            });


            // Get all genres and their associated songs
            app.MapGet("/genres/{genreId}", (TunaPianoDbContext db, int genreId) =>
            {
                var filteredGenre = db.Genres
              .Include(a => a.Songs)
              .SingleOrDefault(a => a.Id == genreId);
                return filteredGenre;
            });

            //Create a new genre
            app.MapPost("/genres", (TunaPianoDbContext db, Genre genre) =>
            {
                db.Genres.Add(genre);
                db.SaveChanges();
                return Results.Created($"/genre/{genre.Id}", genre);
            });

            //Add a new genre to a song
            app.MapPost("/api/song/addGenre", (TunaPianoDbContext db, SongGenreDTO genreSong) =>
            {
                var singleSongToUpdate = db.Songs
                .Include(s => s.Genres)
                .FirstOrDefault(s => s.Id == genreSong.SongId);
                var genreToAdd = db.Genres.FirstOrDefault(g => g.Id == genreSong.GenreId);

                try
                {
                    singleSongToUpdate.Genres.Add(genreToAdd);
                    db.SaveChanges();
                    return Results.NoContent();

                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Invalid data submitted");
                }
            });

            //Update current genre by its Id
            app.MapPut("/genres/{id}", (TunaPianoDbContext db, int id, Genre genre) =>
            {
                Genre genreToUpdate = db.Genres.SingleOrDefault(genre => genre.Id == id);
                if (genreToUpdate == null)
                {
                    return Results.NotFound();
                }
                genreToUpdate.Description = genre.Description;
                db.SaveChanges();
                return Results.NoContent();
            });

            //Delete genre by Id
            app.MapDelete("/genres/{id}", (TunaPianoDbContext db, int id) =>
            {
                Genre genre = db.Genres.SingleOrDefault(g => g.Id == id);
                if (genre == null)
                {
                    return Results.NotFound();
                }
                db.Genres.Remove(genre);
                db.SaveChanges();
                return Results.NoContent();
            });

            //delete a genre from a song
            app.MapDelete("/api/song/{songId}/deleteGenre/{genreId}", (TunaPianoDbContext db, int genreId, int songId) =>
            {
                var singleSongToUpdate = db.Songs
               .Include(s => s.Genres)
               .FirstOrDefault(s => s.Id == songId);
                var genreToDelete = db.Genres.FirstOrDefault(g => g.Id == genreId);

                try
                {
                    singleSongToUpdate.Genres.Remove(genreToDelete);
                    db.SaveChanges();
                    return Results.NoContent();

                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Invalid data submitted");
                }
            });
        }
    }
}
