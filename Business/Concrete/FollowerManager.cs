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

        public IResult DeleteByUserAndFollowedUserId(string userId, string followedUserId)
        {
            Follower result = _followerDal.Get(f => f.UserId == userId && f.FollowedUserId == followedUserId);
            _followerDal.Delete(result);
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

        public IDataResult<List<FollowedUserDto>> GetFollowedUsers(string currentUserId)
        {
            var result = _followerDal.GetFollowedUserDto(currentUserId);
            return new SuccessDataResult<List<FollowedUserDto>>(result);
        }

        public IDataResult<List<Follower>> GetFollowerByFollowedId(string id)
        {
            List<Follower> result = _followerDal.GetAll(f => f.FollowedUserId == id);
            return new SuccessDataResult<List<Follower>>(result);
        }

        public IDataResult<List<Follower>> GetFollowingByUserId(string id)
        {
            List<Follower> result = _followerDal.GetAll(f => f.UserId == id);
            return new SuccessDataResult<List<Follower>>(result);
        }

        public IResult IsFollow(string userId, string followedUserId)
        {
            Follower result = _followerDal.Get(f => f.UserId == userId && f.FollowedUserId == followedUserId);
            if (result == null) return new ErrorResult();
            return new SuccessResult();
        }

        public IResult Update(Follower entity)
        {
            _followerDal.Update(entity);
            return new SuccessResult();
        }
    }
}
