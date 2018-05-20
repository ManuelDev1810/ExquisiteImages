using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ExquisiteImages.Models
{
    public class AppUser : IdentityUser
    {
        public string ProfilePicture { get; set; }
        public List<Image> Images { get; set; }
        //public List<Comment> Comments { get; set; }
    }
}
