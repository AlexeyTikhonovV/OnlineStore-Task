using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager; 

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index(string SelectCategory) 
        {
            if(SelectCategory != null)
            {
                var goods = _context.Commodity.Where(g => g.Category == SelectCategory).ToList();
                DropDownList();

                return View(goods);
            }
            else
            {
                var goods = _context.Commodity.ToList();
                DropDownList();

                return View(goods);
            }          
        }

        private void DropDownList()
        {
            var distinctCategory = _context.Commodity
                .GroupBy(p => p.Category)
                .Select(g => g.FirstOrDefault())
                .ToList();

            var listCategory = distinctCategory.Select(x => x.Category).ToList();

            ViewBag.list = listCategory;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToCart(int id, Cart cart)
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);
            var goods = _context.Commodity.Find(id);

            var listCart = _context.Carts.ToList();          
            var productSearch = listCart.Find(i => i.CommodityNamber == id);

            if (productSearch == null)
            {
                cart.CommodityNamber = id;
                cart.Name = goods.Name;
                cart.Price = goods.Price;
                cart.ApplicationUserId = currentUser.Id;
                _context.Carts.Add(cart);
            }
            else
            {
                var currentProduct = _context.Carts.Find(productSearch.CartId);
                currentProduct.Count = productSearch.Count + 1;               
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
