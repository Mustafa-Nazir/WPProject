using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ImageDetail:IEntity
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public int EmojiId { get; set; }
    }
}
