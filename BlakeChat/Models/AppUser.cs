using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlakeChat.Models
{
    public class AppUser : IdentityUser
    {
        public List<Message> messages { get; set; }
        public int MyProperty { get; set; }
    }
}
