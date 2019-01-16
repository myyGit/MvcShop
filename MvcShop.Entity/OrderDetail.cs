using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public class OrderDetail : BaseEntity
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int GoodId { get; set; }
        public virtual Good Good { get; set; }
        public decimal GoodPrice { get; set; }
        public int GoodNum { get; set; }
        public decimal SubTotal { get; set; }
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastChangeTime { get; set; }
        public bool IsActive { get; set; }
        public override int Id { get => OrderDetailId; set => OrderDetailId = value; }
    }
}
