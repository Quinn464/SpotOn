using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotOn.Data
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        [ForeignKey(nameof(Song))]
        public int SongId { get; set; }
        [Required]
        public GenreType GenreType { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
