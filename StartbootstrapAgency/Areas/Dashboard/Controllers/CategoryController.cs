using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartbootstrapAgency.Data;
using StartbootstrapAgency.Models;

namespace StartbootstrapAgency.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class CategoryController : Controller
    {
        private readonly StartbootstrapAgencyDbContext _context;

        public CategoryController(StartbootstrapAgencyDbContext context)
        {
            _context = context;
        }

        // GET: CategoryController
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Categories.ToListAsync());
        }

        // GET: CategoryController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return NotFound();
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.ID == id);
            if (category == null) return NotFound();

            return View(category);
        }

        // GET: CategoryController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            category.CreatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);

        }

        // GET: CategoryController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null) return NotFound();
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();

            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            category.CreatedDate = DateTime.Now;
            try
            {
                var updatedEntity = _context.Entry(category);
                updatedEntity.State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: CategoryController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(x => x.ID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
