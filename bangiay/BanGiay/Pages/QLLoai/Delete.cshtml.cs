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
    public class DeleteModel : PageModel
    {
        private readonly BanGiay.Models.ApplicationDbContext _context;

        // Khởi tạo DeleteModel với ApplicationDbContext
        public DeleteModel(BanGiay.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        // Thuộc tính để bind dữ liệu từ form xóa loại sản phẩm
        [BindProperty]
        public Loai Loai { get; set; }

        // Phương thức xử lý khi trang được truy cập bằng HTTP GET
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // Kiểm tra nếu id là null, trả về NotFound
            if (id == null)
            {
                return NotFound();
            }

            // Truy vấn loại sản phẩm dựa trên id
            Loai = await _context.Loai.FirstOrDefaultAsync(m => m.ID == id);

            // Kiểm tra nếu không tìm thấy loại sản phẩm, trả về NotFound
            if (Loai == null)
            {
                return NotFound();
            }

            // Trả về trang hiện tại để xác nhận việc xóa
            return Page();
        }

        // Phương thức xử lý khi form xác nhận xóa được submit bằng HTTP POST
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // Kiểm tra nếu id là null, trả về NotFound
            if (id == null)
            {
                return NotFound();
            }

            // Truy vấn loại sản phẩm dựa trên id
            Loai = await _context.Loai.FindAsync(id);

            // Kiểm tra nếu loại sản phẩm tồn tại, thì xóa và lưu thay đổi vào cơ sở dữ liệu
            if (Loai != null)
            {
                _context.Loai.Remove(Loai);
                await _context.SaveChangesAsync();
            }

            // Sau khi xóa xong, chuyển hướng về trang danh sách các loại
            return RedirectToPage("./Index");
        }
    }
}
