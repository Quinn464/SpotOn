using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotOn.Models
{
    public class ArtistEdit
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
