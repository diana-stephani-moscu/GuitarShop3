using Microsoft.AspNetCore.Mvc;
using GuitarShop.Models;
using GuitarShop.Data;
namespace GuitarShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Action for customer registration (GET)
        public IActionResult Register()
        {
            return View();
        }

        // Action for customer registration (POST)
        [HttpPost]
        public IActionResult Register(Customer user)
        {
            if (ModelState.IsValid)
            {
                _context.Customer.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        // Action for customer login (GET)
        public IActionResult Login()
        {
            return View();
        }

        // Action for customer login (POST)
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Customer.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                // Store the user's authentication status (you may use a more secure approach)
                HttpContext.Session.SetString("Username", user.Username);
                return RedirectToAction("Index", "Home"); // Redirect to the homepage after login
            }
            ViewBag.ErrorMessage = "Invalid username or password";
            return View();
        }

        // Action for user logout
        public IActionResult Logout()
        {
            // Clear the user's authentication status
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index", "Home"); // Redirect to the homepage after logout
        }
    }
}
