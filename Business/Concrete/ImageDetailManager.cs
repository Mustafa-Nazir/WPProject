using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult Update(ImageDetail entity)
        {
            _imageDetailDal.Update(entity);
            return new SuccessResult();
        }
    }
}
