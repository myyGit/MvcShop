using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public partial class UserRoles : BaseEntity
    {
        [Key]
        public int UserRoleId { get; set; }

        [Required]
        [StringLength(20)]
        public string UserRoleName { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastChangeTime { get; set; }

        public bool IsActive { get; set; }
        public override int Id { get => UserRoleId; set => UserRoleId = value; }
    }
}
