using Core.Utilities.Bussiness;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApplicationUserService:IBaseService<ApplicationUser , string>
    {
        IDataResult<int> GetPostCount(string id);
        IDataResult<int> GetFollowerCount(string id);
        IDataResult<int> GetFollowingCount(string id);
        IDataResult<string> GetUserIdByName(string name);
        IResult AddUserPP(ApplicationUser user , IFormFile file);

    }
}
