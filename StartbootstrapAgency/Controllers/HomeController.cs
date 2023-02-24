using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartbootstrapAgency.Data;
using StartbootstrapAgency.Models;
using StartbootstrapAgency.ViewModel;
using System.Diagnostics;

namespace StartbootstrapAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StartbootstrapAgencyDbContext _context;

        public HomeController(ILogger<HomeController> logger, StartbootstrapAgencyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                masthead = _context.Mastheads.FirstOrDefault(),
                Service = _context.Services.ToList(),
                Portfolios = _context.Portfolios.Include(x => x.Category).ToList(),
             
            };

            return View(homeVM);
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