using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }
        enum GenreType
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
    }
}
