using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartbootstrapAgency.Data;
using StartbootstrapAgency.Models;

namespace StartbootstrapAgency.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class PortfolioController : Controller
    {
        private readonly StartbootstrapAgencyDbContext _context;

        public PortfolioController(StartbootstrapAgencyDbContext context)
        {
            _context = context;
        }

        // GET: PortfolioController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Portfolios.ToListAsync());
        }

        // GET: PortfolioController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var portfolio = _context.Portfolios.FirstOrDefault(x => x.ID == id);
            if (portfolio == null) return NotFound();


            return View(portfolio);
        }

        // GET: PortfolioController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Category = _context.Categories.ToList();
            return View();
        }

        // POST: PortfolioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Portfolio portfolio)
        {
            portfolio.CreatedDate = DateTime.Now;
            _context.Portfolios.Add(portfolio);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: PortfolioController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var portfolio = _context.Portfolios.Include(x => x.Category).FirstOrDefault(x => x.ID == id);
            if (portfolio == null) return NotFound();


            return View(portfolio);
        }

        // POST: PortfolioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Portfolio portfolio)
        {
            portfolio.CreatedDate = DateTime.Now;
            try
            {
                var updatedEntity = _context.Entry(portfolio);
                updatedEntity.State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        // GET: PortfolioController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolios
                .FirstOrDefaultAsync(x => x.ID == id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }

        // POST: PortfolioController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var portfolio = await _context.Portfolios.FindAsync(id);
            _context.Portfolios.Remove(portfolio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
