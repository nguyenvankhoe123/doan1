using WebOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebOnline.Commons;

namespace WebOnline.Controllers
{
    public class HomeController : Controller
    {
        WebOnlineDbContext db = new WebOnlineDbContext();
        public ActionResult Index()
        {
            ViewBag.SanPhamMoi = db.SanPhams.OrderByDescending(x => x.NgayCapNhat).Take(4).ToList();
            ViewBag.SanPhamBanChay = db.SanPhams.OrderByDescending(x => x.SoLuongBan).Take(4).ToList();
            return View();
        }
        public ActionResult SanPhamBanChay()
        {
            ViewBag.TrangSanPhamBanChay = db.SanPhams.OrderByDescending(x => x.SoLuongBan).Take(10000).ToList();
            return View();
        }
        public ActionResult SanPhamMoi()
        {
            ViewBag.TrangSanPhamMoi = db.SanPhams.OrderByDescending(x => x.NgayCapNhat).Take(10000).ToList();
            return View();
        }

        public ActionResult Details(string id)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(x => x.MaSanPham.Equals(id));
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }

        public ActionResult About()
        {
            ViewBag.Keodua = "Kẹo dừa là một loại kẹo được chế biến từ nguyên liệu chính là cơm dừa và đường mạch nha. Đây là loại kẹo đặc sản và là một nghề thủ công truyền thống mang đậm văn hóa xứ sở. Việt Nam có nhiều vùng trồng dừa nhưng Bến Tre chính là nơi ra đời và phát triển nghệ thuật chế biến kẹo dừa.";
            ViewBag.Lichsu = "Kẹo dừa Bến Tre có nguồn gốc từ huyện Mỏ Cày.Theo các tư liệu sưu tầm được thì người đầu tiên làm ra kẹo là bà Nguyễn Thị Ngọc, sinh năm 1914, cư ngụ tại khu phố 1, thị trấn Mỏ Cày. Kẹo dừa lúc đó có tên là kẹo Mỏ Cày. Vào năm 1970, bà Nguyễn Thị Vinh, sinh năm 1945, cư ngụ tại thị xã Bến Tre, thay đổi mới cách chế biến kẹo.Bà thành lập cơ sở sản xuất kẹo dừa Thanh Long, cơ sở đầu tiên ở thị xã Bến Tre, và từ đó tạo ra tên kẹo dừa Bến Tre. Nguyên liệu làm kẹo dừa gồm: nước cốt dừa, mạch nha, đường (trước kia người ta dùng đường thùng nhưng ngày nay dùng đường cát). Mạch nha được chắt lọc từ chất đường của hạt nếp khi được ủ cho lên mầm.";

            ViewBag.Lamduong =" Muốn làm kẹo ngon, khâu chọn nguyên liệu rất quan trọng.Thóc nếp dùng để nấu mạch nha phải là nếp tốt, hạt to chín đều. Để nảy mầm thóc phải được tưới bằng nước mưa sạch rồi đem nấu lấy mạch nha.Thợ nấu mạch nha phải là thợ lành nghề điêu luyện.Dừa khô lựa trái rám vàng mới vừa hái xuống. Vì trái dừa mới bắt đầu khô này có hương vị đặc trưng, nước cốt có độ ngọt thanh. Đường nấu kẹo phải chọn loại đường mới, có màu vàng tươi.";

            ViewBag.Sen = "Nguyên liệu làm kẹo dừa phải là dừa khô, loại dừa hầu như còn nước dừa bên trong rất ít và hầu như không còn, cơm dừa phải dày, có độ béo cao và màu trắng, không lên mọng dừa hay bị trăng ăn. Tiếp theo dùng một dụng cụ lột vỏ dừa, lấy cơm dừa và cho vào máy xay nhỏ. Cho tất cả cơm dừa xay nhuyễn vào một cái bao và dùng máy ép lấy nước cốt dừa. Phần nước cốt dừa sau khi ép ra có thể cho thêm nguyên liệu phụ vào như: sầu riêng, lá dứa, sôcôla, dâu và nhất thiết phải cho mạch nha vào. Tất cả cho vào một cái chảo rồi cho lên bếp, khuấy liên tục đều tay. Ngày xưa, khi làm kẹo dừa, người dân Nam Bộ phải dùng tay khuấy liên tục bên bếp lửa, nếu không khuấy, phần nước dừa khi sên sẽ đặc lại và chết. Ngày nay, máy móc đã hỗ trợ họ trong khâu này. Họ đỡ mất sức hơn, nhưng phần giữ lửa cho phần sên kẹo cũng rất công phu, vì lửa lớn:sên kẹo sẽ khó khăn, lửa nhỏ: kẹo sẽ rất lỏng. Khi phần nước cốt cô đặc và chuyển màu, người ta sẽ cho lên giàn khuôn mà khuôn đã được bôi trơn một lớp dầu dừa để chống dính. Dùng dao cắt ra làm nhiều phần theo kích thước định sẵn. Tại khâu này, người ta có thể phối trộn hoặc cho thêm nguyên liệu lần cuối vào để kẹo có nhiều mùi vị khác nhau như: đậu phộng giã nhuyễn, phối màu xanh là kẹo dừa lá dứa rồi hòa vào kẹo sầu riêng. Hay cho thanh kẹo nửa màu trắng, nửa màu đen là kẹo dừa sầu riêng sôcôla, v..v..Đây là hiện tượng giao lưu và tiếp biến văn hóa trong nghệ thuật ẩm thực rất sáng tạo để đáp ứng sở thích của nhiều đối tượng khách hàng, để có thể mở rộng thị trường. Phần cuối cùng là gói kẹo trong một lớp bánh tráng hay còn gọi là giấy tan mỏng phía bên ngoài. Bánh tráng này ăn được và có tác dụng hút ẩm cho kẹo. Gói bao bì bằng bánh giấy và cho vào hộp là hoàn tất công đoạn làm kẹo dừa.";
            ViewBag.Giatritruyenthong = "Từ nguồn nguyên liệu dừa rất phong phú của Bến Tre, cộng thêm tài khéo léo của người chế biến, người xứ dừa đã biết tăng thêm giá trị văn hóa, giá trị của lao động thủ công truyền thống vào sản phẩm để làm cho trái dừa không chỉ là nguồn nguyên liệu thô mà nó đã được nâng giá trị lên nhiều lần. Ở đây yếu tố văn hóa trong sản phẩm thủ công đã làm nên giá trị kinh tế, góp phần cải thiện và nâng cao đời sống cho người dân xứ dừa. Mặt khác, chính nhờ có sự phát triển kinh tế như vậy mà nghệ thuật thủ công truyền thống lại được trân trọng, gìn giữ và không ngừng phát triển.";
            ViewBag.Giatrikinhte = "Các cơ sở sản xuất kẹo dừa đã không ngần ngại đầu tư bạc tỷ để đổi mới công nghệ sản xuất kẹo truyền thống, tạo nên nhiều mẫu mã, kiểu dáng ngày càng hấp dẫn khách hàng. Theo truyền thống sản xuất xưa nay các cơ sở sản xuất kẹo dừa luôn xem trọng chất lượng, chữ tín, không sử dụng chất bảo quản, đường hóa học và các chất cấm khác nhằm khẳng định thương hiệu của mình. Nhờ vậy kẹo dừa Bến Tre đã có mặt ở các thị trường trong cả nước và còn xuất khẩu sang nhiều quốc gia Châu Á, Châu Âu và Châu Mỹ.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}