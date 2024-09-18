using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BanGiay.Models;

namespace BanGiay.Pages.QLLoai
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
            return Page();
        }

        // Thuộc tính để bind dữ liệu từ form tạo mới
        [BindProperty]
        public Loai Loai { get; set; }

        // Phương thức xử lý khi form được submit bằng HTTP POST
        // Để bảo vệ khỏi các cuộc tấn công overposting, xem https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // Kiểm tra tính hợp lệ của dữ liệu nhập
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Thêm đối tượng Loai vào context
            _context.Loai.Add(Loai);
            // Lưu các thay đổi vào cơ sở dữ liệu một cách bất đồng bộ
            await _context.SaveChangesAsync();

            // Chuyển hướng đến trang danh sách các loại
            return RedirectToPage("./Index");
        }
    }
}
