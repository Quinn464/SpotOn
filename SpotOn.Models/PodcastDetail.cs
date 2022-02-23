using SpotOn.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotOn.Models
{
    public class PodcastDetail
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        public string Name { get; set; }

        public int ArtistId { get; set; }

        [Required]
        public GenreType Genre { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
