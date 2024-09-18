using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BanGiay.Models;

namespace BanGiay.Pages.QLTinTuc
{
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class DeleteModel : PageModel
    {
        private readonly BanGiay.Models.ApplicationDbContext _context;

        public DeleteModel(BanGiay.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TinTuc TinTuc { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TinTuc = await _context.TinTuc.FindAsync(id);

            if (TinTuc != null)
            {
                _context.TinTuc.Remove(TinTuc);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
