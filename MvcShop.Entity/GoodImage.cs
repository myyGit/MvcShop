using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public partial class GoodImage : BaseEntity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GoodImageId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1000)]
        public string GoodImageName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1000)]
        public string GoodImageUrl { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GoodId { get; set; }
        public virtual Good Good { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime CreateTime { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime LastChangeTime { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool IsActive { get; set; }
        [Column(Order = 7)]
        public int Weight { get; set; }
        public override int Id { get => GoodImageId; set => GoodImageId = value; }
    }
}
