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
    public class ApplicationUserManager : IApplicationUserService
    {
        IApplicationUserDal _applicationUserDal;
        IImageService _imageService;
        IFollowerService _followerService;

        public ApplicationUserManager(IApplicationUserDal applicationUserDal , IImageService imageService, IFollowerService followerService)
        {
            _applicationUserDal = applicationUserDal;
            _imageService = imageService;
            _followerService = followerService;
        }

        public IResult Add(ApplicationUser entity)
        {
            _applicationUserDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(ApplicationUser entity)
        {
            _applicationUserDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<ApplicationUser>> GetAll()
        {
            List<ApplicationUser> results = _applicationUserDal.GetAll();
            return new SuccessDataResult<List<ApplicationUser>>(results);
        }

        public IDataResult<ApplicationUser> GetById(string id)
        {
            ApplicationUser result = _applicationUserDal.Get(u => u.Id == id);
            return new SuccessDataResult<ApplicationUser>(result);
        }

        public IDataResult<int> GetFollowerCount(string id)
        {
            int result = _followerService.GetFollowerByFollowedId(id).Data.Count;
            return new SuccessDataResult<int>(result);
        }

        public IDataResult<int> GetFollowingCount(string id)
        {
            int result = _followerService.GetFollowingByUserId(id).Data.Count;
            return new SuccessDataResult<int>(result);
        }

        public IDataResult<int> GetPostCount(string id)
        {
            int result = _imageService.GetByUserId(id).Data.Count;
            return new SuccessDataResult<int>(result);

        }

        public IDataResult<string> GetUserIdByName(string name)
        {
            string id = _applicationUserDal.Get(u => u.UserName == name).Id;
            return new SuccessDataResult<string>(id);
        }

        public IResult Update(ApplicationUser entity)
        {
            _applicationUserDal.Update(entity);
            return new SuccessResult();
        }
    }
}
