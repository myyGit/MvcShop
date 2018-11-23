using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public class UserAccountMap : EntityTypeConfiguration<UserAccount>
    {
        //实体关系     Has                      With        ForeignKey
        //一对一.      HasRequired         .WithMany       .HasForeignKey
        //一对多.      HasMany             .WithRequired   .HasForeignKey
        //多对多.      HasMany             .WithMany        MapLeftKey, MapRightKey, ToTable

        public UserAccountMap()
        {
            this.ToTable("UserAccounts")
                .HasKey(p => p.UserId)
                .Ignore(p => p.Id);
            this.Property(p => p.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(p => p.UserRole).WithMany().HasForeignKey(p => p.UserRoleId);
        }
    }
}
