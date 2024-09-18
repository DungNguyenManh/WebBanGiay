using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BanGiay.Models;

namespace BanGiay.Pages.QLNguoiDung
{
    // Áp dụng bộ lọc để kiểm tra quyền admin
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class CreateModel : PageModel
    {
        private readonly BanGiay.Models.ApplicationDbContext _context;

        // Khởi tạo CreateModel với ApplicationDbContext
        public CreateModel(BanGiay.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        // Phương thức xử lý khi trang được truy cập bằng HTTP GET
        public IActionResult OnGet()
        {
            // Trả về trang tạo mới người dùng
            return Page();
        }

        // Thuộc tính để bind dữ liệu từ form tạo mới người dùng
        [BindProperty]
        public NguoiDung NguoiDung { get; set; }

        // Phương thức xử lý khi form tạo mới được submit bằng HTTP POST
        public async Task<IActionResult> OnPostAsync()
        {
            // Kiểm tra nếu ModelState không hợp lệ, trả về trang hiện tại để hiển thị lại form với thông báo lỗi
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Thêm người dùng mới vào cơ sở dữ liệu và lưu thay đổi
            _context.NguoiDung.Add(NguoiDung);
            await _context.SaveChangesAsync();

            // Chuyển hướng về trang danh sách người dùng sau khi tạo mới thành công
            return RedirectToPage("./Index");
        }
    }
}
