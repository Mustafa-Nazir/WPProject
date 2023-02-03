using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFollowerDal:EfEntityRepositoryBase<Follower , WPProjectDbContext> , IFollowerDal
    {
        public List<FollowedUserDto> GetFollowedUserDto(string currentUserId)
        {
            using (WPProjectDbContext context = new WPProjectDbContext())
            {
                var result = from f in context.Followeres
                             where f.UserId == currentUserId
                             join i in context.Images
                             on f.FollowedUserId equals i.UserId
                             join u in context.Users
                             on f.FollowedUserId equals u.Id
                             select new FollowedUserDto { Email = u.Email, Image = i.Path, PP = u.PPPath , ImageId = i.Id};
                return result.ToList();
            }
        }
    }
}
