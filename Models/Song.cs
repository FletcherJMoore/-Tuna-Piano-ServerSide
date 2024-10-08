﻿
using System.ComponentModel.DataAnnotations;

namespace Tuna_Piano.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Album { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public decimal length { get; set; }
    }
}
