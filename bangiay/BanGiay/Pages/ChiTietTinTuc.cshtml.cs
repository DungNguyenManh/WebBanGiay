using BanGiay.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BanGiay.Pages
{
    public class ChiTietTinTucModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public TinTuc TinTuc { get; set; }

        public ChiTietTinTucModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            TinTuc = await _dbContext.TinTuc.FindAsync(id);

            if (TinTuc == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
