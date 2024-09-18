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
    public class DeleteModel : PageModel
    {
        private readonly BanGiay.Models.ApplicationDbContext _context;

        // Khởi tạo DeleteModel với ApplicationDbContext
        public DeleteModel(BanGiay.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        // Thuộc tính để bind dữ liệu từ form xóa người dùng
        [BindProperty]
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
            // Trả về trang xóa người dùng
            return Page();
        }

        // Phương thức xử lý khi form xóa được submit bằng HTTP POST
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // Kiểm tra nếu ID không tồn tại, trả về NotFound
            if (id == null)
            {
                return NotFound();
            }

            // Tìm người dùng theo ID
            NguoiDung = await _context.NguoiDung.FindAsync(id);

            // Nếu người dùng tồn tại, xóa khỏi cơ sở dữ liệu và lưu thay đổi
            if (NguoiDung != null)
            {
                _context.NguoiDung.Remove(NguoiDung);
                await _context.SaveChangesAsync();
            }

            // Chuyển hướng về trang danh sách người dùng sau khi xóa thành công
            return RedirectToPage("./Index");
        }
    }
}
