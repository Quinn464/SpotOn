using SpotOn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotOn.Models
{
    public class SongEdit
    {
        public string Name { get; set; }
        public int SongId { get; set; }
        public GenreType Genre { get; set; }
        public bool IsDeleted { get; set; }
        public int ArtistId { get; set; }
    }
}
