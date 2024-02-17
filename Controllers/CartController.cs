using Microsoft.AspNetCore.Mvc;
using GuitarShop.Models;
using GuitarShop.Data;
namespace GuitarShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Action to display the customer's cart
        public IActionResult Index()
        {
            // Retrieve the user's cart items based on customer authentication (you may use a more secure approach)
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if the customer is not authenticated
            }

            var user = _context.Customer.FirstOrDefault(u => u.Username == username);
            var cartItems = _context.CartItem.Where(c => c.UserId == user.Id).ToList();
            return View(cartItems);
        }

        // Action to add a product to the cart
        public IActionResult AddToCart(int productId, int quantity)
        {
            // Retrieve the customer's cart based on user authentication (you may use a more secure approach)
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if the user is not authenticated
            }

            var user = _context.Customer.FirstOrDefault(u => u.Username == username);
            var cartItem = _context.CartItem.FirstOrDefault(c => c.UserId == user.Id && c.GuitarId == productId);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    UserId = user.Id,
                    GuitarId = productId,
                    Quantity = quantity
                };
                _context.CartItem.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Action to remove a product from the cart
        public IActionResult RemoveFromCart(int cartItemId)
        {
            var cartItem = _context.CartItem.Find(cartItemId);
            if (cartItem == null)
            {
                return NotFound();
            }

            _context.CartItem.Remove(cartItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
