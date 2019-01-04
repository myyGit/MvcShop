using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public partial class CarouselImage : BaseEntity
    {
        [Key]
        public int CarouselImageId { get; set; }

        [StringLength(50)]
        public string CarouselImageName { get; set; }

        [Required]
        [StringLength(500)]
        public string CarouselImageUrl { get; set; }

        public bool IsChecked { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastChangeTime { get; set; }
        public override int Id { get => CarouselImageId; set => CarouselImageId = value; }
    }
}
