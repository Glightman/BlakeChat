using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlakeChat.Models
{
    public class Message
    {
        public int id { get; set; }
        public string userName { get; set; }
        [Required]
        public string text { get; set; }
        public DateTime DateTime { get; set; }
        public string userId { get; set; }
        public AppUser appUser { get; set; }  
    }
}
