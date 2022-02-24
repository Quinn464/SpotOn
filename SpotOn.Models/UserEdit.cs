using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotOn.Models
{
    public class UserEdit
    {
        public int UserId { get; set; }
        public string UserName { get; set; }       
        public bool IsDeleted { get; set; }       
    }
}
