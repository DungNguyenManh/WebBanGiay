using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BanGiay.Models;

namespace BanGiay.Pages.QLSanPham
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

        // Thuộc tính để lưu thông tin sản phẩm
        public SanPham SanPham { get; set; }

        // Phương thức xử lý khi trang được truy cập bằng HTTP GET
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // Kiểm tra xem id có hợp lệ không
            if (id == null)
            {
                return NotFound();
            }

            // Lấy thông tin sản phẩm từ cơ sở dữ liệu theo id
            SanPham = await _context.SanPham.FirstOrDefaultAsync(m => m.ID == id);

            // Kiểm tra xem sản phẩm có tồn tại không
            if (SanPham == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
