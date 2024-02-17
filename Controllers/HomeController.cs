using GuitarShop.Data;
using GuitarShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GuitarShop.Controllers
{
    public class HomeController : Controller
    {


        /*
         * private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        *
        */

        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*public async Task<ActionResult> Statistics()
        {
            IQueryable<Guitar> data =
            from order in _context.Guitar
            group order by order.OrderDate into dateGroup
            select new Guitar()
                {
                    OrderDate = dateGroup.Key,
                    VideoGameCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        } */

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Guitar()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
