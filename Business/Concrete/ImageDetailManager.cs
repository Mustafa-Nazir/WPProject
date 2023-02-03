using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImageDetailManager : IImageDetailService
    {
        IImageDetailDal _imageDetailDal;

        public ImageDetailManager(IImageDetailDal imageDetailDal)
        {
            _imageDetailDal = imageDetailDal;
        }

        public IResult Add(ImageDetail entity)
        {
            if (!ImageEmojiControl(entity).Success) return new ErrorResult();
            _imageDetailDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(ImageDetail entity)
        {
            _imageDetailDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<ImageDetail>> GetAll()
        {
            List<ImageDetail> results = _imageDetailDal.GetAll();
            return new SuccessDataResult<List<ImageDetail>>(results);
        }

        public IDataResult<ImageDetail> GetById(int id)
        {
            ImageDetail result = _imageDetailDal.Get(i => i.Id == id);
            return new SuccessDataResult<ImageDetail>(result);
        }

        public IDataResult<List<ImageEmojiDetailDto>> GetEmojiAmountByImageId(int ImageId)
        {
            var result = _imageDetailDal.GetEmojiAmountByImageId(ImageId);
            return new SuccessDataResult<List<ImageEmojiDetailDto>>(result);
        }

        public IResult Update(ImageDetail entity)
        {
            _imageDetailDal.Update(entity);
            return new SuccessResult();
        }

        private IResult ImageEmojiControl(ImageDetail _imageDetail)
        {
            var result = _imageDetailDal.Get(i => i.ImageId == _imageDetail.ImageId && i.UserId == _imageDetail.UserId && i.EmojiId == _imageDetail.EmojiId);
            if (result == null) return new SuccessResult();
            return new ErrorResult();
        }
    }
}
