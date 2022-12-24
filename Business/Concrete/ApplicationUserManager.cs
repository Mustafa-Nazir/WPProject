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

        public ApplicationUserManager(IApplicationUserDal applicationUserDal)
        {
            _applicationUserDal = applicationUserDal;
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

        public IResult Update(ApplicationUser entity)
        {
            _applicationUserDal.Update(entity);
            return new SuccessResult();
        }
    }
}
