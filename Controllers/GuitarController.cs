using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GuitarShop.Models;
using GuitarShop.Data;

namespace GuitarShop.Controllers
{
    public class GuitarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuitarController(ApplicationDbContext context)
            {
                _context = context;
            }

        // Action to display the list of products
        public IActionResult Index(string searchQuery, decimal? minPrice, decimal? maxPrice, string category)
        {
            var products = _context.Guitar.AsQueryable();

            // Search products based on searchQuery
            if (!string.IsNullOrEmpty(searchQuery))
            {
                products = products.Where(p => p.Name.Contains(searchQuery) || p.Description.Contains(searchQuery));
            }

            // Filter products based on minPrice and maxPrice
            if (minPrice.HasValue)
            {
                products = products.Where(p => p.Price >= minPrice);
            }

            if (maxPrice.HasValue)
            {
                products = products.Where(p => p.Price <= maxPrice);
            }

            // Filter products based on colour
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Colour.Equals(category, StringComparison.OrdinalIgnoreCase));
            }

            return View(products.ToList());


            // Filter products based on shape
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Shape.Equals(category, StringComparison.OrdinalIgnoreCase));
            }

            return View(products.ToList());


            // Filter products based on type
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Type.Equals(category, StringComparison.OrdinalIgnoreCase));
            }

            return View(products.ToList());
        }

        // Action to display product details
        public IActionResult Details(int id)
            {
                var product = _context.Guitar.Find(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
    }
}
