using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BanGiay.Models;

namespace BanGiay.Pages.QLDonHang
{
    // Áp dụng bộ lọc để kiểm tra quyền admin
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class DetailsModel : PageModel
    {
        private readonly BanGiay.Models.ApplicationDbContext _context;

        // Khởi tạo DetailsModel với ApplicationDbContext
        public DetailsModel(BanGiay.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        // Đối tượng DonHang để chứa thông tin đơn hàng
        public DonHang DonHang { get; set; } = default!;
        // Danh sách chứa chi tiết đơn hàng
        public List<ChiTietDonHang> listchitietdonhang { get; set; } = new List<ChiTietDonHang>();
        // Danh sách chứa sản phẩm trong chi tiết đơn hàng
        public List<SanPham> ListSanPham { get; set; } = new List<SanPham>();
        // Biến để tính tổng giá trị đơn hàng
        public decimal TongGia { get; set; }

        // Phương thức xử lý khi trang được truy cập bằng HTTP GET
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // Kiểm tra nếu id hoặc _context.DonHang là null thì trả về NotFound
            if (id == null || _context.DonHang == null)
            {
                return NotFound();
            }

            // Truy vấn đơn hàng dựa trên id
            var donhang = await _context.DonHang.FirstOrDefaultAsync(m => m.ID == id);

            // Truy vấn chi tiết đơn hàng dựa trên id đơn hàng
            listchitietdonhang = await _context.ChiTietDonHang.Where(ct => ct.IDDonHang == id).ToListAsync();
            // Khởi tạo tổng giá trị đơn hàng bằng 0
            TongGia = 0;

            // Lặp qua từng chi tiết đơn hàng để tính tổng giá và lấy thông tin sản phẩm
            foreach (var chitiet in listchitietdonhang)
            {
                // Truy vấn sản phẩm dựa trên ID sản phẩm trong chi tiết đơn hàng
                var sanpham = await _context.SanPham.FirstOrDefaultAsync(sp => sp.ID == chitiet.IDSanPham);
                // Thêm sản phẩm vào danh sách sản phẩm
                ListSanPham.Add(sanpham);

                // Tính tổng giá trị đơn hàng
                TongGia += chitiet.SoLuong * chitiet.Gia;
            }

            // Kiểm tra nếu không tìm thấy đơn hàng thì trả về NotFound
            if (donhang == null)
            {
                return NotFound();
            }
            else
            {
                // Gán giá trị đơn hàng cho biến DonHang
                DonHang = donhang;
            }

            // Trả về trang hiện tại
            return Page();
        }
    }
}
