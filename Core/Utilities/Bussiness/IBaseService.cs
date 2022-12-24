using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Bussiness
{
    public interface IBaseService<TEntity , TId> where TEntity : class , IEntity , new()
    {
        IResult Add(TEntity entity);
        IResult Delete(TEntity entity);
        IResult Update(TEntity entity);
        IDataResult<List<TEntity>> GetAll();
        IDataResult<TEntity> GetById(TId id);
    }
}
