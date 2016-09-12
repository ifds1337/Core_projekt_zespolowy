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
    public class RezerwacjesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RezerwacjesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rezerwacjes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rezerwacje.ToListAsync());
        }

        // GET: Zrob rezerwacje w bazie danych rezerwacji
        public async Task<IActionResult> Zarezerwowano()
        {


            return View();
        }

        // GET: Rezerwacjes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacje = await _context.Rezerwacje.SingleOrDefaultAsync(m => m.ID == id);
            if (rezerwacje == null)
            {
                return NotFound();
            }

            return View(rezerwacje);
        }

        // GET: Rezerwacjes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rezerwacjes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Rez_Do,Rez_ID_Klienta,Rez_ID_Pokoju,Rez_Od")] Rezerwacje rezerwacje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezerwacje);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rezerwacje);
        }

        // GET: Rezerwacjes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacje = await _context.Rezerwacje.SingleOrDefaultAsync(m => m.ID == id);
            if (rezerwacje == null)
            {
                return NotFound();
            }
            return View(rezerwacje);
        }

        // POST: Rezerwacjes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Rez_Do,Rez_ID_Klienta,Rez_ID_Pokoju,Rez_Od")] Rezerwacje rezerwacje)
        {
            if (id != rezerwacje.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezerwacje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezerwacjeExists(rezerwacje.ID))
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
            return View(rezerwacje);
        }

        // GET: Rezerwacjes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacje = await _context.Rezerwacje.SingleOrDefaultAsync(m => m.ID == id);
            if (rezerwacje == null)
            {
                return NotFound();
            }

            return View(rezerwacje);
        }

        // POST: Rezerwacjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezerwacje = await _context.Rezerwacje.SingleOrDefaultAsync(m => m.ID == id);
            _context.Rezerwacje.Remove(rezerwacje);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RezerwacjeExists(int id)
        {
            return _context.Rezerwacje.Any(e => e.ID == id);
        }
    }
}
