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
    public class DeleteModel : PageModel
    {
        private readonly BanGiay.Models.ApplicationDbContext _context;

        // Khởi tạo DeleteModel với ApplicationDbContext
        public DeleteModel(BanGiay.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        // Thuộc tính để liên kết dữ liệu sản phẩm từ form
        [BindProperty]
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

        // Phương thức xử lý khi trang được truy cập bằng HTTP POST
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // Kiểm tra xem id có hợp lệ không
            if (id == null)
            {
                return NotFound();
            }

            // Tìm sản phẩm theo id trong cơ sở dữ liệu
            SanPham = await _context.SanPham.FindAsync(id);

            // Nếu sản phẩm tồn tại, tiến hành xóa
            if (SanPham != null)
            {
                _context.SanPham.Remove(SanPham);
                await _context.SaveChangesAsync();
            }

            // Chuyển hướng đến trang danh sách sản phẩm sau khi xóa
            return RedirectToPage("./Index");
        }
    }
}
