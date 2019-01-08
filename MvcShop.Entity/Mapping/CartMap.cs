using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public class CartMap : EntityTypeConfiguration<Cart>
    {
        public CartMap()
        {
            this.ToTable("Cart")
                .HasKey(p => p.CartId)
                .Ignore(p => p.Id);

            this.Property(p => p.CartId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(p => p.Good).WithMany().HasForeignKey(p => p.GoodId).WillCascadeOnDelete(false);
        }
    }
}
