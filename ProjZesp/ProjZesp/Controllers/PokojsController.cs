using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjZesp.Data;
using ProjZesp.Models;

namespace ProjZesp.Controllers
{
    public class PokojsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PokojsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Pokojs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pokoje.ToListAsync());
        }

        // GET: Lista pokoi dla klientów
        public async Task<IActionResult> ListaPokoi()
        {
            return View(await _context.Pokoje.ToListAsync());
        }

        // GET: Rezerwacja pokoi
        public IActionResult Rezerwacja()
        {
            return View();
        }


        // GET: Pokojs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokoj = await _context.Pokoje.SingleOrDefaultAsync(m => m.ID == id);
            if (pokoj == null)
            {
                return NotFound();
            }

            return View(pokoj);
        }

        // GET: Pokojs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pokojs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Pokoj_Dostępnosc,Pokoj_IloscMiejsc,Pokoj_Numer")] Pokoj pokoj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pokoj);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pokoj);
        }

        // GET: Pokojs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokoj = await _context.Pokoje.SingleOrDefaultAsync(m => m.ID == id);
            if (pokoj == null)
            {
                return NotFound();
            }
            return View(pokoj);
        }

        // POST: Pokojs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Pokoj_Dostępnosc,Pokoj_IloscMiejsc,Pokoj_Numer")] Pokoj pokoj)
        {
            if (id != pokoj.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pokoj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokojExists(pokoj.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(pokoj);
        }

        // GET: Pokojs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokoj = await _context.Pokoje.SingleOrDefaultAsync(m => m.ID == id);
            if (pokoj == null)
            {
                return NotFound();
            }

            return View(pokoj);
        }

        // POST: Pokojs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pokoj = await _context.Pokoje.SingleOrDefaultAsync(m => m.ID == id);
            _context.Pokoje.Remove(pokoj);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PokojExists(int id)
        {
            return _context.Pokoje.Any(e => e.ID == id);
        }
    }
}
