using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BanGiay.Models;
using Microsoft.EntityFrameworkCore;

namespace BanGiay.Pages.QLSanPham
{
    // Áp dụng bộ lọc để kiểm tra quyền admin
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class CreateModel : PageModel
    {
        private readonly BanGiay.Models.ApplicationDbContext _context;

        // Thuộc tính để lưu danh sách loại sản phẩm
        public List<Loai> ListLoai { get; set; }

        // Khởi tạo CreateModel với ApplicationDbContext
        public CreateModel(BanGiay.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        // Phương thức xử lý khi trang được truy cập bằng HTTP GET
        public async Task<IActionResult> OnGet()
        {
            // Lấy danh sách loại sản phẩm từ cơ sở dữ liệu và lưu vào thuộc tính ListLoai
            ListLoai = await _context.Loai.ToListAsync() ?? new List<Loai>();
            return Page();
        }

        // Thuộc tính để liên kết dữ liệu sản phẩm từ form
        [BindProperty]
        public SanPham SanPham { get; set; }

        // Thuộc tính để liên kết tệp ảnh từ form
        [BindProperty]
        public IFormFile Anh { get; set; }

        // Phương thức xử lý khi trang được truy cập bằng HTTP POST
        // Để bảo vệ khỏi các cuộc tấn công overposting
        // Xem thêm tại https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // Kiểm tra tính hợp lệ của ModelState
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Xử lý tệp ảnh nếu có
            if (Anh != null && Anh.Length > 0)
            {
                // Lấy tên tệp ảnh
                var fileName = Path.GetFileName(Anh.FileName);
                // Đặt đường dẫn tệp ảnh
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "client/img/featured", fileName);

                // Đảm bảo thư mục tồn tại
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                // Lưu tệp ảnh vào đường dẫn
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Anh.CopyToAsync(stream);
                }

                // Lưu tên tệp ảnh vào thuộc tính Anh của sản phẩm
                SanPham.Anh = fileName;
            }

            // Thêm sản phẩm vào cơ sở dữ liệu
            _context.SanPham.Add(SanPham);
            // Lưu các thay đổi vào cơ sở dữ liệu
            await _context.SaveChangesAsync();

            // Chuyển hướng đến trang danh sách sản phẩm
            return RedirectToPage("./Index");
        }
    }
}
