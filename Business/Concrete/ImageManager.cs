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
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public IResult Add(Image entity)
        {
            _imageDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Image entity)
        {
            _imageDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Image>> GetAll()
        {
            List<Image> images = _imageDal.GetAll();
            return new SuccessDataResult<List<Image>>(images);
        }

        public IDataResult<Image> GetById(int id)
        {
            Image image = _imageDal.Get(i => i.Id == id);
            return new SuccessDataResult<Image>(image);
        }

        public IResult Update(Image entity)
        {
            _imageDal.Update(entity);
            return new SuccessResult();
        }
    }
}
