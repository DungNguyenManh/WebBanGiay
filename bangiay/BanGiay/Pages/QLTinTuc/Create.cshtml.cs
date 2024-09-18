using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BanGiay.Models;
using Microsoft.AspNetCore.Mvc;

namespace BanGiay.Pages.QLTinTuc
{
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class CreateModel : PageModel
    {
        private readonly BanGiay.Models.ApplicationDbContext _context;

        public CreateModel(BanGiay.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            TinTuc = new TinTuc();
            TinTuc.NgayDang = DateTime.Now;
            return Page();
        }

        [BindProperty]
        public TinTuc TinTuc { get; set; }

        [BindProperty]
        public IFormFile Anh { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Anh != null && Anh.Length > 0)
            {
                var fileName = Path.GetFileName(Anh.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "client/img/blog", fileName);

                // Ensure directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Anh.CopyToAsync(stream);
                }

                TinTuc.Anh = fileName;
            }

            _context.TinTuc.Add(TinTuc);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
