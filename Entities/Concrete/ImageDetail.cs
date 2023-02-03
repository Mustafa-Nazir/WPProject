using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ImageDetail:IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ImageId { get; set; }
        [Required]
        public int EmojiId { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
