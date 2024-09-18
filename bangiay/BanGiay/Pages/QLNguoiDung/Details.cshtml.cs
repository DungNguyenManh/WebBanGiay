using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BanGiay.Models;

namespace BanGiay.Pages.QLNguoiDung
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

        // Thuộc tính để lưu thông tin người dùng
        public NguoiDung NguoiDung { get; set; }

        // Phương thức xử lý khi trang được truy cập bằng HTTP GET
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // Kiểm tra nếu ID không tồn tại, trả về NotFound
            if (id == null)
            {
                return NotFound();
            }

            // Tìm người dùng theo ID
            NguoiDung = await _context.NguoiDung.FirstOrDefaultAsync(m => m.ID == id);

            // Nếu người dùng không tồn tại, trả về NotFound
            if (NguoiDung == null)
            {
                return NotFound();
            }
            // Trả về trang hiển thị chi tiết người dùng
            return Page();
        }
    }
}
