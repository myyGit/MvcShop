using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public class Cart : BaseEntity
    {
        public int CartId { get; set; }
        public int GoodId { get; set; }
        public virtual Good Good { get; set; }
        public int UserId { get; set; }
        public int Num { get; set; }
        public decimal GoodPrice { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastChangeTime { get; set; }
        public bool IsActive { get; set; }
        public override int Id { get => CartId; set => CartId = value; }
    }
}
