using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public partial class UserAccount : BaseEntity
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserHguid { get; set; }

        public int UserRoleId { get; set; }
        //virtual必须加，不加的话获取不到值
        public virtual UserRoles UserRole { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string UserPassword { get; set; }

        [StringLength(50)]
        public string NickName { get; set; }

        [StringLength(100)]
        public string Mobile { get; set; }

        [StringLength(1000)]
        public string Question { get; set; }

        [StringLength(100)]
        public string Answer { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastChangeTime { get; set; }

        public bool IsActive { get; set; }
        public override int Id
        {
            get
            {
                return UserId;
            }
            set
            {
                UserId = value;
            }
        }
    }
}
