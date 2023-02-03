using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfImageDetailDal : EfEntityRepositoryBase<ImageDetail, WPProjectDbContext>, IImageDetailDal
    {
        public List<ImageEmojiDetailDto> GetEmojiAmountByImageId(int imageId)
        {
            using (WPProjectDbContext context = new WPProjectDbContext())
            {
                var result = (from i in context.ImageDetails
                             where i.ImageId == imageId
                             group i by i.EmojiId into g
                             select new { EmojiId = g.Key, Count = g.Count() })
                             .Join(context.Emojis, g => g.EmojiId, e => e.Id,
                             (g,e)=>new ImageEmojiDetailDto 
                             {
                                 Amount=g.Count,
                                 EmojiId=g.EmojiId,
                                 ImageId=imageId,
                                 Path =e.Path
                             });
                return result.ToList();
                             
            }
        }
    }
}
