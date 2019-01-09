using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public class Order : BaseEntity
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public int UserId { get; set; }
        public int GoodId { get; set; }
        public string HGUID { get; set; }
        public int OrderState { get; set; }
        public int ReceiverId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastChangeTime { get; set; }
        public bool IsActive { get; set; }
        public override int Id { get => OrderId; set => OrderId = value; }
    }
}
