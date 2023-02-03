using Core.Utilities.Bussiness;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IImageDetailService:IBaseService<ImageDetail , int>
    {
        public IDataResult<List<ImageEmojiDetailDto>> GetEmojiAmountByImageId(int ImageId);
        public IResult ImageEmojiControl(ImageDetail _imageDetail);
        public IDataResult<ImageDetail> GetImageDetailByImageEmojiUserId(ImageDetail _imageDetail);
    }
}
