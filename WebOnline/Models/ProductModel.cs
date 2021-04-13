using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebOnline.Models
{
    public class ProductModel
    {

        [Key]
        [StringLength(10)]
        public string MaSanPham { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSanPham { get; set; }

        [StringLength(10)]
        public string MaLoaiSP { get; set; }

        [StringLength(10)]
        public string MaKhoiLuong { get; set; }

        [StringLength(10)]
        public string MaNhaSanXuat { get; set; }

        [StringLength(50)]
        public string DonViTinh { get; set; }

        public int? SoLuong { get; set; }

        public int? SoLuongBan { get; set; }

        public int? DonGia { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayCapNhat { get; set; }

        [StringLength(50)]
        public string HinhMinhHoa { get; set; }
    }
}