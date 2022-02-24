﻿using SpotOn.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotOn.Models
{
    public class AlbumCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        public string Name { get; set; }

        public GenreType Genre { get; set; }
        public int ArtistId { get; set; }
        public List<Song> AlbumContent { get; set; }
    }
}
