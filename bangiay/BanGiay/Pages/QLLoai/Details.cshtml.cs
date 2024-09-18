using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BanGiay.Models;

namespace BanGiay.Pages.QLLoai
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

        // Thuộc tính để lưu thông tin của loại sản phẩm
        public Loai Loai { get; set; }

        // Phương thức xử lý khi trang được truy cập bằng HTTP GET
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // Kiểm tra nếu id là null, trả về NotFound
            if (id == null)
            {
                return NotFound();
            }

            // Truy vấn thông tin loại sản phẩm dựa trên id
            Loai = await _context.Loai.FirstOrDefaultAsync(m => m.ID == id);

            // Kiểm tra nếu không tìm thấy loại sản phẩm, trả về NotFound
            if (Loai == null)
            {
                return NotFound();
            }

            // Trả về trang hiện tại để hiển thị thông tin chi tiết của loại sản phẩm
            return Page();
        }
    }
}
