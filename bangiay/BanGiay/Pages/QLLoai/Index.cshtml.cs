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
    public class IndexModel : PageModel
    {
        private readonly BanGiay.Models.ApplicationDbContext _context;

        // Khởi tạo IndexModel với ApplicationDbContext
        public IndexModel(BanGiay.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        // Danh sách loại sản phẩm
        public IList<Loai> Loai { get; set; }

        // Phương thức xử lý khi trang được truy cập bằng HTTP GET
        public async Task OnGetAsync()
        {
            // Lấy danh sách tất cả loại sản phẩm từ cơ sở dữ liệu và gán vào thuộc tính Loai
            Loai = await _context.Loai.ToListAsync();
        }
    }
}
