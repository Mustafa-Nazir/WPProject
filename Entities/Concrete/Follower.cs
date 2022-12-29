using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Follower : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        [Required]
        public string UserId { get; set; }
        [StringLength(450)]
        [Required]
        public string FollowedUserId { get; set; }
        
    }

    
}
