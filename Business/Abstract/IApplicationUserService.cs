using Core.Utilities.Bussiness;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApplicationUserService:IBaseService<ApplicationUser , string>
    {
    }
}
