using Business.Abstract;
using Core.Utilities.Bussiness;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        IFileHelper _fileHelper;
        UserManager<ApplicationUser> _userManager;

        public ApplicationUserManager(IApplicationUserDal applicationUserDal , IImageService imageService, IFollowerService followerService , IFileHelper fileHelper)
        {
            _applicationUserDal = applicationUserDal;
            _imageService = imageService;
            _followerService = followerService;
            _fileHelper = fileHelper;
        }

        public IResult Add(ApplicationUser entity)
        {
            _applicationUserDal.Add(entity);
            return new SuccessResult();
        }

        public IResult AddUserPP(ApplicationUser user, IFormFile file)
        {

            string imagePath = _fileHelper.IsFileEmpty(file) ? "default.png" : _fileHelper.Upload(file, @"wwwroot\images\pp\");
            user.PPPath = imagePath;
            _applicationUserDal.Update(user);
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
            return new SuccessDataResult<string>(id,"");
        }

        public IResult Update(ApplicationUser entity)
        {
            _applicationUserDal.Update(entity);
            return new SuccessResult();
        }
        
    }
}
