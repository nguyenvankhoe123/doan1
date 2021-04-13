namespace WebOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatHang")]
    public partial class DatHang
    {
        public DatHang()
        {
            ChiTietDatHangs = new HashSet<ChiTietDatHang>();
        }

        [Key]
        [DisplayName("Mã hóa đơn")]
        [StringLength(10)]

        public string MaHoaDon { get; set; }

        [DisplayName("Mã khách hàng")]
        [StringLength(10)]
        public string MaKhachHang { get; set; }

        [DisplayName("Tổng tiền")]
        public int? TongTien { get; set; }

        [DisplayName("Ngày đặt hàng")]
        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayDatHang { get; set; }

        [DisplayName("Trang thái")]
        public bool? TrangThai { get; set; }

        public virtual ICollection<ChiTietDatHang> ChiTietDatHangs { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
