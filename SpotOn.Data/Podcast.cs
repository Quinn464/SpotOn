using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotOn.Data
{

    public class Podcast
    {
        [Key]
        public int PodcastId { get; set; }
       
        [ForeignKey(nameof(Artist))]
        public int ArtistId { get; set; }

        public GenreType Genre { get; set; }
        public bool IsDeleted { get; set; }
    }
}
