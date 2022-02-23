using SpotOn.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotOn.Models
{
    public class SongListItem
    {
        public int SongId { get; set; }
        public string Name { get; set; }

        public GenreType Genre { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; } 
        }
}
