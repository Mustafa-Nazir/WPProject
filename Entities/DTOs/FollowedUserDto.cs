using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class FollowedUserDto:IDto
    {
        public string Email { get; set; }
        public string PP { get; set; }
        public string Image { get; set; }
        public int ImageId { get; set; }


    }
}
