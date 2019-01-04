using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public class GoodMap : EntityTypeConfiguration<Good>
    {
        public GoodMap()
        {
            this.ToTable("Goods")
                .HasKey(p => p.GoodId)
                .Ignore(p => p.Id);

            this.Property(p => p.GoodId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            this.HasRequired(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId).WillCascadeOnDelete(false);
        }
    }
}
