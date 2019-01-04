using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public class CarouselImageMap : EntityTypeConfiguration<CarouselImage>
    {
        public CarouselImageMap()
        {
            this.ToTable("CarouselImages")
                .HasKey(p => p.CarouselImageId)
                .Ignore(p => p.Id);
            this.Property(p => p.CarouselImageId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //this.HasRequired(p => p.UserRole).WithMany().HasForeignKey(p => p.UserRoleId);
        }
    }
}
