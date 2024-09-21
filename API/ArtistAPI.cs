
using Microsoft.EntityFrameworkCore;
using Tuna_Piano.Models;

namespace Tuna_Piano.API
{
    public class ArtistAPI
    {
        public static void Map(WebApplication app)
        {

            //Get a list of all artists
            app.MapGet("/artists", (TunaPianoDbContext db) =>
            {
                return db.Artists.ToList();
            });


            //Get artists details and associated songs
            app.MapGet("artists/{artistId}", (TunaPianoDbContext db, int artistId) =>
            {
                var filteredArtist = db.Artists
              .Include(a => a.Songs)
              .ThenInclude(s => s.Genres)
              .SingleOrDefault(a => a.Id == artistId);
                return filteredArtist;
            });


            //Create a new artist
            app.MapPost("/artists", (TunaPianoDbContext db, Artist artist) =>
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return Results.Created($"/artists/{artist.Id}", artist);
            });

            //Update artist by Id
            app.MapPut("/artists/{id}", (TunaPianoDbContext db, int id, Artist artist) =>
            {
                Artist artistToUpdate = db.Artists.SingleOrDefault(artist => artist.Id == id);
                if (artistToUpdate == null)
                {
                    return Results.NotFound();
                }
                artistToUpdate.Name = artist.Name;
                artistToUpdate.Age = artist.Age;
                artistToUpdate.Bio = artist.Bio;
                db.SaveChanges();
                return Results.NoContent();
            });

            //Delete artist by Id
            app.MapDelete("/artists/{id}", (TunaPianoDbContext db, int id) =>
            {
                Artist artist = db.Artists.SingleOrDefault(a => a.Id == id);
                if (artist == null)
                {
                    return Results.NotFound();
                }
                db.Artists.Remove(artist);
                db.SaveChanges();
                return Results.NoContent();
            });
        }
    }
}
