using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public class Address : BaseEntity
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public virtual UserAccount UserAccount { get; set; }
        public string ReceiverName { get; set; }
        public string MobilePhone { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Street { get; set; }
        public string ZipNum { get; set; }
        public bool IsDefault { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastChangeTime { get; set; }
        public bool IsActive { get; set; }
        public override int Id { get => AddressId; set => AddressId = value; }
    }
}
