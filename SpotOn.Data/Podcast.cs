﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotOn.Data
{
    // .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .-----------------.
    //| .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |
    //| |    _______   | || |   ______     | || |     ____     | || |  _________   | || |     ____     | || | ____ _____   | |
    //| |   /  ___  |  | || |  |_ __   \   | || |   .'    `.   | || | |  _   _  |  | || |   .'    `.   | || ||_   \|_ _|   | |
    //| |  |  (__ \_|  | || |    | |__) |  | || |  /  .--.  \  | || | |_/ | | \_|  | || |  /  .--.  \  | || |  |   \ | |   | |
    //| |   '.___`-.   | || |    |  ___/   | || |  | |    | |  | || |     | |      | || |  | |    | |  | || |  | |\ \| |   | |
    //| |  |`\____) |  | || |   _| |_      | || |  \  `--'  /  | || |    _| |_     | || |  \  `--'  /  | || | _| |_\   |_  | |
    //| |  |_______.'  | || |  |_____|     | || |   `.____.'   | || |   |_____|    | || |   `.____.'   | || ||_____|\____| | |
    //| |              | || |              | || |              | || |              | || |              | || |              | |
    //| '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |
    // '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------' 

    public class Podcast
    {
        [Key]
        public int PodcastId { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(Artist))]
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
<<<<<<< HEAD
=======

        public Guid AuthorId { get; set; }
>>>>>>> 87e2c79f537e5fd467cbcd6fefa8e151bacaf6a9

        [Required]
        public GenreType Genre { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        public bool IsDeleted { get; set; }
    }
}
