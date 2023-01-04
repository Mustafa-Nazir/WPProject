using Business.Abstract;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
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
        IFileHelper _fileHelper;

        public ImageManager(IImageDal imageDal , IFileHelper fileHelper)
        {
            _imageDal = imageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(Image entity)
        {
            _imageDal.Add(entity);
            return new SuccessResult();
        }

        public IResult AddImage(Image image, IFormFile file)
        {
            if (_fileHelper.IsFileEmpty(file)) return new ErrorResult();
            string imagePath = _fileHelper.Upload(file, @"wwwroot\images\uploads\");
            image.Path = imagePath;
            return Add(image);
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

        public IDataResult<List<Image>> GetByUserId(string id)
        {
            List<Image> result = _imageDal.GetAll(i => i.UserId == id);
            return new SuccessDataResult<List<Image>>(result);
        }

        public IResult Update(Image entity)
        {
            _imageDal.Update(entity);
            return new SuccessResult();
        }
    }
}
