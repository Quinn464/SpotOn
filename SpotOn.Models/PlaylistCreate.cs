using SpotOn.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotOn.Models
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
    
 public class PlaylistCreate
    {
        //[Required]
        //[MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        //[MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        //public int PlaylistId { get; set; }
        public string Name { get; set; }
        [MaxLength(8000)]
        public List<Song> PlaylistContent { get; set; }
    }
}
