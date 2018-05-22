using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExquisiteImagesApi.Models
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
    }
}
