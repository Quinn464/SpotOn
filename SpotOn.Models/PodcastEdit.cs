using SpotOn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotOn.Models
{
    public class PodcastEdit
    {
        public int PodcastId { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public GenreType Genre { get; set; }
        public bool IsDeleted { get; set; }
       
    }
}
