﻿using System.ComponentModel.DataAnnotations;


namespace Tuna_Piano.Models
{
    public class Artist
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Bio { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
