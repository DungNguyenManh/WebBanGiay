using System;
using System.Collections.Generic;
using System.IO; // Thêm namespace này để sử dụng Path và FileStream
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http; // Thêm namespace này để sử dụng IFormFile
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BanGiay.Models;

namespace BanGiay.Pages.QLSanPham
{
    // Áp dụng bộ lọc để kiểm tra quyền admin
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class EditModel : PageModel
    {
        private readonly BanGiay.Models.ApplicationDbContext _context;

        // Danh sách loại sản phẩm
        public List<Loai> ListLoai { get; set; }

        // Khởi tạo EditModel với ApplicationDbContext
        public EditModel(BanGiay.Models.ApplicationDbContext context)
        {
            _context = context;
        }

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

            // Load danh sách loại sản phẩm
            ListLoai = await _context.Loai.ToListAsync() ?? new List<Loai>();

            return Page();
        }

        // Thuộc tính để lưu thông tin sản phẩm
        [BindProperty]
        public SanPham SanPham { get; set; }

        // Thuộc tính để lưu file ảnh tải lên
        [BindProperty]
        public IFormFile Anh { get; set; }

        // Hàm xử lý khi nhấn nút Submit
        public async Task<IActionResult> OnPostAsync()
        {
            // Kiểm tra tính hợp lệ của Model
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Nếu có file ảnh được chọn
            if (Anh != null && Anh.Length > 0)
            {
                // Lấy tên file và đường dẫn lưu file
                var fileName = Path.GetFileName(Anh.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "client/img/featured", fileName);

                // Đảm bảo thư mục tồn tại trước khi lưu file
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                // Lưu file ảnh vào đường dẫn
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Anh.CopyToAsync(stream);
                }

                // Cập nhật đường dẫn file ảnh vào sản phẩm
                SanPham.Anh = fileName;
            }

            // Cập nhật thông tin sản phẩm vào context và lưu vào database
            _context.Attach(SanPham).State = EntityState.Modified;

            try
            {
                // Lưu các thay đổi vào cơ sở dữ liệu
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Kiểm tra xem sản phẩm có tồn tại không
                if (!SanPhamExists(SanPham.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Chuyển hướng về trang Index
            return RedirectToPage("./Index");
        }

        // Kiểm tra xem sản phẩm có tồn tại trong cơ sở dữ liệu không
        private bool SanPhamExists(int? id)
        {
            return _context.SanPham.Any(e => e.ID == id);
        }
    }
}
