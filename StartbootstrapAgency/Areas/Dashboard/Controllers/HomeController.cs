using Microsoft.AspNetCore.Mvc;

namespace StartbootstrapAgency.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
