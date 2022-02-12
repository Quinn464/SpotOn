using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotOn.Data
{
    public class Playlist 
    {
        [Key]
        public int PlaylistId { get; set; }

        [Required]
        public List<Song> PlaylistContent { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        
        
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

       
       

        




    }
}
