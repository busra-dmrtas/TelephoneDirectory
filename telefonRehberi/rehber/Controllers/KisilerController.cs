using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rehber.Models;

namespace rehber.Controllers
{
    public class KisilerController : Controller
    {
        private readonly VeriContext _context;

        public KisilerController()
        {
            _context = new VeriContext();
        }

        // GET: Kisiler
        public async Task<IActionResult> Index()
        {
              return _context.Kisilers != null ? 
                          View(await _context.Kisilers.ToListAsync()) :
                          Problem("Entity set 'VeriContext.Kisilers'  is null.");
        }

        // GET: Kisiler/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Kisilers == null)
            {
                return NotFound();
            }

            var kisiler = await _context.Kisilers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kisiler == null)
            {
                return NotFound();
            }

            return View(kisiler);
        }

        // GET: Kisiler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kisiler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Soyad,Numara")] Kisiler kisiler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kisiler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kisiler);
        }

        // GET: Kisiler/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Kisilers == null)
            {
                return NotFound();
            }

            var kisiler = await _context.Kisilers.FindAsync(id);
            if (kisiler == null)
            {
                return NotFound();
            }
            return View(kisiler);
        }

        // POST: Kisiler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Ad,Soyad,Numara")] Kisiler kisiler)
        {
            if (id != kisiler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kisiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KisilerExists(kisiler.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kisiler);
        }

        // GET: Kisiler/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Kisilers == null)
            {
                return NotFound();
            }

            var kisiler = await _context.Kisilers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kisiler == null)
            {
                return NotFound();
            }

            return View(kisiler);
        }

        // POST: Kisiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Kisilers == null)
            {
                return Problem("Entity set 'VeriContext.Kisilers'  is null.");
            }
            var kisiler = await _context.Kisilers.FindAsync(id);
            if (kisiler != null)
            {
                _context.Kisilers.Remove(kisiler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KisilerExists(long id)
        {
          return (_context.Kisilers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
