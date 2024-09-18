using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BanGiay.Models;

namespace BanGiay.Pages.QLTinTuc
{
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class EditModel : PageModel
    {
        private readonly BanGiay.Models.ApplicationDbContext _context;

        public EditModel(BanGiay.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TinTuc TinTuc { get; set; }

        [BindProperty]
        public IFormFile Anh { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TinTuc = await _context.TinTuc.FirstOrDefaultAsync(m => m.ID == id);

            if (TinTuc == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Nếu có file ảnh được chọn
            if (Anh != null && Anh.Length > 0)
            {
                var fileName = Path.GetFileName(Anh.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "client/img/blog", fileName);

                // Đảm bảo thư mục tồn tại trước khi lưu file
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Anh.CopyToAsync(stream);
                }

                TinTuc.Anh = fileName;
            }

            // Cập nhật thông tin sản phẩm vào context và lưu vào database
            _context.Attach(TinTuc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TinTucExists(TinTuc.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TinTucExists(int? id)
        {
            return _context.TinTuc.Any(e => e.ID == id);
        }
    }
}
