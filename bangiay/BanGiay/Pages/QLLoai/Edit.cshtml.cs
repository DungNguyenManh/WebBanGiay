using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BanGiay.Models;

namespace BanGiay.Pages.QLLoai
{
    // Áp dụng bộ lọc để kiểm tra quyền admin
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class EditModel : PageModel
    {
        private readonly BanGiay.Models.ApplicationDbContext _context;

        // Khởi tạo EditModel với ApplicationDbContext
        public EditModel(BanGiay.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        // Thuộc tính để bind dữ liệu từ form chỉnh sửa loại sản phẩm
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

            // Trả về trang hiện tại để hiển thị form chỉnh sửa loại sản phẩm
            return Page();
        }

        // Phương thức xử lý khi form chỉnh sửa được submit bằng HTTP POST
        public async Task<IActionResult> OnPostAsync()
        {
            // Kiểm tra nếu ModelState không hợp lệ, trả về trang hiện tại để hiển thị lại form với thông báo lỗi
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Áp dụng trạng thái Modified cho đối tượng Loai để cập nhật vào cơ sở dữ liệu
            _context.Attach(Loai).State = EntityState.Modified;

            try
            {
                // Lưu thay đổi vào cơ sở dữ liệu
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Xử lý ngoại lệ khi xảy ra lỗi cạnh tranh (concurrency)
                if (!LoaiExists(Loai.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Chuyển hướng về trang danh sách các loại sản phẩm sau khi chỉnh sửa thành công
            return RedirectToPage("./Index");
        }

        // Phương thức kiểm tra xem loại sản phẩm có tồn tại không
        private bool LoaiExists(int? id)
        {
            return _context.Loai.Any(e => e.ID == id);
        }
    }
}
