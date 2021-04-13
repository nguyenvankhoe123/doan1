namespace WebOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDatHang")]
    public partial class ChiTietDatHang
    {
        [Key]
        [StringLength(10)]
        public string SoHoaDon { get; set; }

        [DisplayName("Mã sản phẩm")]
        [StringLength(10)]
        public string MaSanPham { get; set; }

        [DisplayName("Mã khách hàng")]
        [StringLength(10)]
        public string MaKhachHang { get; set; }

        [DisplayName("Mã hóa đơn")]
        [StringLength(10)]
        public string MaHoaDon { get; set; }

        [DisplayName("Số lượng")]
        public int? SoLuong { get; set; }

        [DisplayName("Đơn giá")]
        public int? DonGia { get; set; }

        [DisplayName("Thành tiền")]
        public int? ThanhTien { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayDatHang { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayGiaoHang { get; set; }

        public virtual DatHang DatHang { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
