using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public class GoodImageMap : EntityTypeConfiguration<GoodImage>
    {
        public GoodImageMap()
        {
            this.ToTable("GoodImages")
                .HasKey(p => p.GoodImageId)
                .Ignore(p => p.Id);
            this.Property(p => p.GoodImageId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(p => p.Good).WithMany().HasForeignKey(p => p.GoodId);
        }
    }
}
