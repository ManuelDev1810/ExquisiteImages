using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExquisiteImages.Models
{
    public class Comment
    {
        public int CoomentId { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Details { get; set; }

        public int ImageId { get; set; }
        [ForeignKey("ImageId")]
        public Image Image { get; set; }
    }
}
