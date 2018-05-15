using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExquisiteImages.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
    }
}
