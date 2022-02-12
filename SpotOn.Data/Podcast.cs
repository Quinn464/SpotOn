using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotOn.Data
{
    class Podcast
    {
        [Key]
        public int PodcastId { get; set; }
        public int ArtistId { get; set; }
        public GenreType Genre { get; set; }
        public bool IsDeleted { get; set; }
    }
}
