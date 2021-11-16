using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.BAL.Abstract
{
    public interface IRepository<TEntity>
    {
        List<TEntity> GetAllBind();
        IQueryable<TEntity> GetAll();
        TEntity GetBy(params object[] Key);
        TEntity Add(TEntity entity);
        bool Update(TEntity entity);
        TEntity Delete(TEntity entity);
        TEntity Delete(params object[] Key);
        bool Save();
    }
}
