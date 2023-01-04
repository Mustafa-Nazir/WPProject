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
    public interface IFollowerService:IBaseService<Follower , int>
    {
        IDataResult<List<Follower>> GetFollowingByUserId(string id);
        IDataResult<List<Follower>> GetFollowerByFollowedId(string id);
        IResult DeleteByUserAndFollowedUserId(string userId, string followedUserId);
        IResult IsFollow(string userId , string followedUserId);
        IDataResult<List<FollowedUserDto>> GetFollowedUsers(string currentUserId);
    }
}
