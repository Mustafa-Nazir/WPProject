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
    public class FollowerManager : IFollowerService
    {
        IFollowerDal _followerDal;

        public FollowerManager(IFollowerDal followerDal)
        {
            _followerDal = followerDal;
        }

        public IResult Add(Follower entity)
        {
            _followerDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Follower entity)
        {
            _followerDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Follower>> GetAll()
        {
            List<Follower> results = _followerDal.GetAll();
            return new SuccessDataResult<List<Follower>>(results);
        }

        public IDataResult<Follower> GetById(int id)
        {
            Follower result = _followerDal.Get(f => f.Id == id);
            return new SuccessDataResult<Follower>(result);
        }

        public IResult Update(Follower entity)
        {
            _followerDal.Update(entity);
            return new SuccessResult();
        }
    }
}
