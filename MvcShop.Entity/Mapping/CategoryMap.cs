using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.ToTable("Categories")
                .HasKey(p => p.CategoryId)
                .Ignore(p => p.Id).Ignore(p=>p.Children);
            this.Property(p => p.CategoryId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //this.HasRequired(p => p.UserRole).WithMany().HasForeignKey(p => p.UserRoleId);
        }
    }
}
