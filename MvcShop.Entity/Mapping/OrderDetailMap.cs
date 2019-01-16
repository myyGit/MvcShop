using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity.Mapping
{
    public class OrderDetailMap : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMap()
        {
            this.ToTable("OrderDetail")
                .HasKey(p => p.OrderDetailId)
                .Ignore(p => p.Id);

            this.Property(p => p.OrderDetailId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(p => p.Good).WithMany().HasForeignKey(p => p.GoodId).WillCascadeOnDelete(false);
            this.HasRequired(p => p.Order).WithMany().HasForeignKey(p => p.OrderId).WillCascadeOnDelete(false);
        }
    }
}
