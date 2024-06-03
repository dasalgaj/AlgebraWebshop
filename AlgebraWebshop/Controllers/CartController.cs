using AlgebraWebshop.Data;
using Microsoft.AspNetCore.Mvc;

namespace AlgebraWebshop.Controllers
{
    public class CartController : Controller
    {
        public const string SessionKeyName = "_cart";
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
