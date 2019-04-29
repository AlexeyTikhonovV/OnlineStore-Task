using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    [Authorize]
    public class CartController : Controller 
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public CartController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);

            var Cart = _context.Carts.Where(c => c.ApplicationUserId == currentUser.Id);

            return View(Cart);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCountCommodity(int id, Cart cart)
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);

            var listGoods = _context.Carts.ToList();
            var findCommodity = listGoods.Find(i => i.CommodityNamber == id);
            var updateCount = _context.Carts.Find(findCommodity.CartId); 
            if (cart.Count == 0)
            {
                updateCount.Count = findCommodity.Count + 1;
            }
            else
            {
                updateCount.Count = cart.Count;
            }            
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int? id)
        {
            if (id != null)
            {
                ApplicationUser currentUser = await _userManager.GetUserAsync(User);
                var carts = _context.Carts.Where(c => c.CommodityNamber == id && c.ApplicationUserId == currentUser.Id).FirstOrDefault();
                if (carts != null)
                {
                    _context.Carts.Remove(carts);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
