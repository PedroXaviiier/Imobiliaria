using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Imobiliaria.Web;

namespace Imobiliaria.Web.Controllers
{
    public class CorretoresController : Controller
    {
        private readonly ImobiliariaDbContext _context;

        public CorretoresController(ImobiliariaDbContext context)
        {
            _context = context;
        }

        // GET: Corretores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Corretores.ToListAsync());
        }

        // GET: Corretores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corretore = await _context.Corretores
                .FirstOrDefaultAsync(m => m.CorretorId == id);
            if (corretore == null)
            {
                return NotFound();
            }

            return View(corretore);
        }

        // GET: Corretores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Corretores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CorretorId,Nome,Cpf,Creci,Telefone,Email")] Corretore corretore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(corretore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(corretore);
        }

        // GET: Corretores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corretore = await _context.Corretores.FindAsync(id);
            if (corretore == null)
            {
                return NotFound();
            }
            return View(corretore);
        }

        // POST: Corretores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CorretorId,Nome,Cpf,Creci,Telefone,Email")] Corretore corretore)
        {
            if (id != corretore.CorretorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(corretore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorretoreExists(corretore.CorretorId))
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
            return View(corretore);
        }

        // GET: Corretores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corretore = await _context.Corretores
                .FirstOrDefaultAsync(m => m.CorretorId == id);
            if (corretore == null)
            {
                return NotFound();
            }

            return View(corretore);
        }

        // POST: Corretores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var corretore = await _context.Corretores.FindAsync(id);
            if (corretore != null)
            {
                _context.Corretores.Remove(corretore);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorretoreExists(int id)
        {
            return _context.Corretores.Any(e => e.CorretorId == id);
        }
    }
}
