﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ExquisiteImagesApi.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string UserId { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
