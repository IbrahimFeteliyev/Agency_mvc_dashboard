using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartbootstrapAgency.Data;
using StartbootstrapAgency.Models;

namespace StartbootstrapAgency.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class MastheadController : Controller
    {
        private readonly StartbootstrapAgencyDbContext _context;

        public MastheadController(StartbootstrapAgencyDbContext context)
        {
            _context = context;
        }

        // GET: MastheadController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mastheads.ToListAsync());
        }

        // GET: MastheadController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return NotFound();
            var masthead = await _context.Mastheads.FirstOrDefaultAsync(x => x.ID == id);
            if (masthead == null) return NotFound();

            return View(masthead);
        }

        // GET: MastheadController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: MastheadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Masthead masthead)
        {
            masthead.CreatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(masthead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(masthead);
        }

        // GET: MastheadController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null) return NotFound();
            var masthead = await _context.Mastheads.FindAsync(id);
            if (masthead == null) return NotFound();

            return View(masthead);
        }

        // POST: MastheadController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Masthead masthead)
        {
      
            try
            {
                var updatedEntity = _context.Entry(masthead);
                updatedEntity.State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        //GET: MastheadController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masthead = await _context.Mastheads
                .FirstOrDefaultAsync(x => x.ID == id);
            if (masthead == null)
            {
                return NotFound();
            }

            return View(masthead);
        }

        //POST: MastheadController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var masthead = await _context.Mastheads.FindAsync(id);
            _context.Mastheads.Remove(masthead);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
