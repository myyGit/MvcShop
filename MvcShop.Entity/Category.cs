using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public class Category : BaseEntity
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }
        /// <summary>
        /// 权重  用来进行排序
        /// </summary>
        public int Weight { get; set; }
        /// <summary>
        /// 类别级别
        /// </summary>
        public int Levels { get; set; }
        /// <summary>
        /// 上一级目录Id
        /// </summary>
        public int PId { get; set; }
        public DateTime CreateTime { get; set; }

        public DateTime LastChangeTime { get; set; }

        public bool IsActive { get; set; }
        
        public List<Category> Children { get; set; }
        public override int Id { get => CategoryId; set => CategoryId = value; }
    }
}
