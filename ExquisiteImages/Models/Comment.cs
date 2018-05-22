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
        public int CommentId { get; set; }
        [Required]
        public string CommentContent { get; set; }

        public DateTime Date { get; set; }

        public int ImageId { get; set; }
        [ForeignKey("ImageId")]
        public Image Image { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }
    }
}
