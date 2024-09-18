using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BanGiay.Models;

namespace BanGiay.Pages.QLSanPham
{
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class IndexModel : PageModel
    {
        private readonly BanGiay.Models.ApplicationDbContext _context;

        public IndexModel(BanGiay.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SanPham> SanPham { get;set; }

        public async Task OnGetAsync()
        {
            SanPham = await _context.SanPham.ToListAsync();
        }
    }
}
