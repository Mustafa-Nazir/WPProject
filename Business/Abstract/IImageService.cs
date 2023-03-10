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
    public interface IImageService:IBaseService<Image , int>
    {
        IDataResult<List<Image>> GetByUserId(string id);
        IResult AddImage(Image image , IFormFile file);
    }
}
