using BanGiay.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace BanGiay.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public List<SanPham> ListSanPham { get; set; }
        public List<Loai> ListLoai { get; set; }
        public void OnGet()
        {
            ListLoai = _dbContext.Loai.ToList();
            ListSanPham = _dbContext.SanPham.OrderByDescending(sp => sp.ID).ToList();
        }
        public IActionResult OnPostAddToCart(int id)
        {
            var sanPham = _dbContext.SanPham.Find(id);

            var sessionCart = HttpContext.Session.GetString("Cart");
            var cart = string.IsNullOrEmpty(sessionCart) ? new List<Cart>() : JsonConvert.DeserializeObject<List<Cart>>(sessionCart);

            var existingCartItem = cart.FirstOrDefault(item => item.ID == id);
            if (existingCartItem != null)
            {
                existingCartItem.SoLuong++;
            }
            else
            {
                var cartItem = new Cart
                {
                    ID = sanPham.ID,
                    Anh = sanPham.Anh,
                    Ten = sanPham.Ten,
                    SoLuong = 1,
                    Gia = sanPham.Gia
                };
                cart.Add(cartItem);
            }

            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));

            return RedirectToPage("/Index");
        }
    }
}