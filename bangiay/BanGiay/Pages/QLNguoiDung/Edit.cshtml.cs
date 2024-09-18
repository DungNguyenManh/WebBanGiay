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
    public class EditModel : PageModel
    {
        private readonly BanGiay.Models.ApplicationDbContext _context;

        // Khởi tạo EditModel với ApplicationDbContext
        public EditModel(BanGiay.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        // Thuộc tính để lưu thông tin người dùng cần chỉnh sửa
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
            // Trả về trang chỉnh sửa người dùng
            return Page();
        }

        // Phương thức xử lý khi trang được truy cập bằng HTTP POST
        // Để bảo vệ khỏi các cuộc tấn công overposting, chỉ cho phép bind các thuộc tính cụ thể
        public async Task<IActionResult> OnPostAsync()
        {
            // Kiểm tra tính hợp lệ của model
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Đánh dấu trạng thái của NguoiDung là đã chỉnh sửa
            _context.Attach(NguoiDung).State = EntityState.Modified;

            try
            {
                // Lưu các thay đổi vào cơ sở dữ liệu
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Nếu có lỗi đồng bộ hóa, kiểm tra người dùng có tồn tại không
                if (!NguoiDungExists(NguoiDung.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Chuyển hướng đến trang danh sách người dùng sau khi chỉnh sửa thành công
            return RedirectToPage("./Index");
        }

        // Phương thức kiểm tra người dùng có tồn tại hay không
        private bool NguoiDungExists(int? id)
        {
            return _context.NguoiDung.Any(e => e.ID == id);
        }
    }
}
