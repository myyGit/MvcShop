using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _context;
        private IDbSet<T> _dbEntities;
        public EfRepository(IDbContext context)
        {
            this._context = context;
        }
        public IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this._dbEntities.Remove(entity);

            this._context.SaveChanges();
        }

        public void Delete(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            foreach (var entity in entities)
            {
                this._dbEntities.Remove(entity);
            }

            this._context.SaveChanges();
        }

        public T GetById(object id)
        {
            return this._dbEntities.Find(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this._dbEntities.Add(entity);

            this._context.SaveChanges();
        }

        public void Insert(IEnumerable<T> entities)
        {
            if (entities == null || entities.Count() > 0)
                throw new ArgumentNullException("entities");
            foreach (var entity in entities)
            {
                this._dbEntities.Add(entity);
            }
            this._context.SaveChanges();

        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this._context.SaveChanges();
        }

        public void Update(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            var dbcontext = this._context as DbContext;

            this._context.SaveChanges();
        }

        public int InsertReturnId(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this._dbEntities.Add(entity);

            this._context.SaveChanges();
            return entity.Id;
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (_dbEntities == null)
                    _dbEntities = _context.Set<T>();
                return _dbEntities;
            }
        }
    }
}
