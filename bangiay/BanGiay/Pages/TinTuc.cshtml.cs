using BanGiay.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BanGiay.Pages
{
    public class TinTucModel : PageModel
    {
        private readonly ILogger<TinTucModel> _logger;
        private readonly ApplicationDbContext _dbContext;

        public TinTucModel(ILogger<TinTucModel> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public List<TinTuc> ListTinTuc { get; set; }
        public void OnGet()
        {
            ListTinTuc = _dbContext.TinTuc.ToList();
        }
    }
}
