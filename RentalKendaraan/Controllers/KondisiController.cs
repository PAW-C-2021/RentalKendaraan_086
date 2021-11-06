using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalKendaraan.Models;

namespace RentalKendaraan.Controllers
{
    public class KondisiController : Controller
    {
        private readonly RentKendaraanContext _context;

        public KondisiController(RentKendaraanContext context)
        {
            _context = context;
        }

        // GET: Kondisi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kondisis.ToListAsync());
        }

        // GET: Kondisi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kondisi = await _context.Kondisis
                .FirstOrDefaultAsync(m => m.IdKondisi == id);
            if (kondisi == null)
            {
                return NotFound();
            }

            return View(kondisi);
        }

        // GET: Kondisi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kondisi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKondisi,NamaKondisi")] Kondisi kondisi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kondisi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kondisi);
        }

        // GET: Kondisi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kondisi = await _context.Kondisis.FindAsync(id);
            if (kondisi == null)
            {
                return NotFound();
            }
            return View(kondisi);
        }

        // POST: Kondisi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKondisi,NamaKondisi")] Kondisi kondisi)
        {
            if (id != kondisi.IdKondisi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kondisi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KondisiExists(kondisi.IdKondisi))
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
            return View(kondisi);
        }

        // GET: Kondisi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kondisi = await _context.Kondisis
                .FirstOrDefaultAsync(m => m.IdKondisi == id);
            if (kondisi == null)
            {
                return NotFound();
            }

            return View(kondisi);
        }

        // POST: Kondisi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kondisi = await _context.Kondisis.FindAsync(id);
            _context.Kondisis.Remove(kondisi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KondisiExists(int id)
        {
            return _context.Kondisis.Any(e => e.IdKondisi == id);
        }
    }
}
