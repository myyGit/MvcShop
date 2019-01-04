using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public partial class Good : BaseEntity
    {
        [Key]
        public int GoodId { get; set; }

        [Required]
        [StringLength(500)]
        public string GoodName { get; set; }

        [Required]
        public string GoodKeyWord { get; set; }

        public decimal GoodPrice { get; set; }
        /// <summary>
        /// 商品权重
        /// </summary>
        public int GoodWeight { get; set; }

        public int GoodSale { get; set; }

        public int GoodStock { get; set; }

        [StringLength(1000)]
        public string GoodDesc { get; set; }

        [Required]
        //[ItemField(OnlyLoadAll = true)]
        public string GoodIntroduce { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastChangeTime { get; set; }

        public bool IsActive { get; set; }

        public int CategoryId { get; set; }
        
        public virtual Category Category { get; set; }
        public override int Id { get => GoodId; set => GoodId = value; }
    }
}
