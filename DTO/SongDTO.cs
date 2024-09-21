namespace Tuna_Piano.DTO
{
    public class SongDTO
    {
        public string Title { get; set; }
        public string Album { get; set; }
        public int ArtistId { get; set; }
        public decimal Length { get; set; }
        public List<int> GenreId { get; set; }
    }
}
