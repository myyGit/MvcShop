using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public partial class MvcShopContext : DbContext, IDbContext
    {
        public MvcShopContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        //public virtual DbSet<CarouselImages> CarouselImages { get; set; }
        //public virtual DbSet<Collections> Collections { get; set; }
        //public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        //public virtual DbSet<GoodTypes> GoodTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            System.Type configType = typeof(UserAccountMap);   //any of your configuration classes here
            var typesToRegister = Assembly.GetAssembly(configType).GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return this.Database.SqlQuery<TElement>(sql, parameters);
        }
    }
}
