using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotOn.Data
{
    public enum GenreType
    {
        Rock,
        Pop,
        Country,
        Blues,
        Electronic,
        Dance,
        Jazz,
        Dubstep,
        IndieRock,
    }
    public class Song
    {
        [Key]
        public int SongId { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey(nameof(Album))]
        public int AlbumId { get; set; }
        [ForeignKey(nameof(Artist))]
        public int ArtistId { get; set; }
        [Required]
        public GenreType Genre { get; set; }
    }
}
