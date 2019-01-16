using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public class Order : BaseEntity
    {
        [Key]
        public int OrderId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNumber { get; set; }
        public int UserId { get; set; }
        public virtual UserAccount UserAccount { get; set; }
        public string HGUID { get; set; }
        public int OrderState { get; set; }
        public int GoodCount { get; set; }
        public decimal GoodTotalPrice { get; set; }
        public int AddressId { get; set; }
        public decimal PayMoney { get; set; }
        public virtual Address Address { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastChangeTime { get; set; }
        public bool IsActive { get; set; }
        public override int Id { get => OrderId; set => OrderId = value; }
    }
}
