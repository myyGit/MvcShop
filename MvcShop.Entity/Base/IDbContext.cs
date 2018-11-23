using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public interface IDbContext
    {
        int SaveChanges();
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);
    }
}
