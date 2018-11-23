using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity.Mapping
{
    public class UserRoleMap : EntityTypeConfiguration<UserRoles>
    {
        public UserRoleMap()
        {
            this.ToTable("UserRoles")
                .HasKey(p => p.UserRoleId)
                .Ignore(p => p.Id);
            this.Property(p => p.UserRoleId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
