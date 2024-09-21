
using Microsoft.EntityFrameworkCore;
using Tuna_Piano.Models;

namespace Tuna_Piano.API
{
    public class SongAPI
    {
        public static void Map(WebApplication app)
        {
            //Get a list of all songs
            app.MapGet("/songs", (TunaPianoDbContext db) =>
            {
                return db.Songs.ToList();
            });

            //Get a song and its associated artist details and genre details 
            app.MapGet("/songs/{songId}", (TunaPianoDbContext db, int songId) =>
            {
                Song singleSong = db.Songs
                .Include(s => s.Artist)
                .Include(s => s.Genres)
                .FirstOrDefault(s => s.Id == songId);

                if (singleSong == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(singleSong);
            });

            //Create a new song
            app.MapPost("/songs", (TunaPianoDbContext db, Song song) =>
            {
                db.Songs.Add(song);
                db.SaveChanges();
                return Results.Created($"/songs/{song.Id}", song);
            });

            //Update song by Id
            app.MapPut("/songs/{id}", (TunaPianoDbContext db, int id, Song songs) =>
            {
                Song songToUpdate = db.Songs.SingleOrDefault(songs => songs.Id == id);
                if (songToUpdate == null)
                {
                    return Results.NotFound();
                }
                songToUpdate.Title = songs.Title;
                songToUpdate.ArtistId = songs.ArtistId;
                songToUpdate.Album = songs.Album;
                songToUpdate.length = songs.length;
                db.SaveChanges();
                return Results.NoContent();
            });

            //Delete song by Id
            app.MapDelete("/songs/{id}", (TunaPianoDbContext db, int id) =>
            {
                Song song = db.Songs.SingleOrDefault(s => s.Id == id);
                if (song == null)
                {
                    return Results.NotFound();
                }
                db.Songs.Remove(song);
                db.SaveChanges();
                return Results.NoContent();
            });
        }
    }
}

