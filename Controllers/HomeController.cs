#nullable enable
using System.Diagnostics;
using ClidesCustoms.Models;
using Microsoft.AspNetCore.Mvc;
using ClidesCustoms.Data;

namespace ClidesCustoms.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var featuredServices = _context.Services.Where(s => s.IsActive).Take(6).ToList();

            var featuredProducts = _context.Products.Where(p => p.IsActive && p.StockQuantity > 0).Take(6).ToList();

            ViewBag.FeaturedServices = featuredServices;
            ViewBag.FeaturedProducts = featuredProducts;

            return View();

        }

        public IActionResult Privacy()
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
