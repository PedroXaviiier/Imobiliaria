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
    public class ImoveisController : Controller
    {
        private readonly ImobiliariaDbContext _context;

        public ImoveisController(ImobiliariaDbContext context)
        {
            _context = context;
        }

        // GET: Imoveis
        public async Task<IActionResult> Index()
        {
            var imobiliariaDbContext = _context.Imoveis.Include(i => i.ClienteDono).Include(i => i.CorretorGestor).Include(i => i.CorretorNegocio);
            return View(await imobiliariaDbContext.ToListAsync());
        }

        // GET: Imoveis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovei = await _context.Imoveis
                .Include(i => i.ClienteDono)
                .Include(i => i.CorretorGestor)
                .Include(i => i.CorretorNegocio)
                .FirstOrDefaultAsync(m => m.ImovelId == id);
            if (imovei == null)
            {
                return NotFound();
            }

            return View(imovei);
        }

        // GET: Imoveis/Create
        public IActionResult Create()
        {
            ViewData["ClienteDonoId"] = new SelectList(_context.Clientes, "ClienteId", "Cpf");
            ViewData["CorretorGestorId"] = new SelectList(_context.Corretores, "CorretorId", "Cpf");
            ViewData["CorretorNegocioId"] = new SelectList(_context.Corretores, "CorretorId", "Cpf");
            return View();
        }

        // POST: Imoveis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImovelId,Endereco,Tipo,Area,Valor,Descricao,Negocio,CorretorNegocioId,CorretorGestorId,ClienteDonoId,Disponivel,Fotos")] Imovei imovei)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imovei);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteDonoId"] = new SelectList(_context.Clientes, "ClienteId", "Cpf", imovei.ClienteDonoId);
            ViewData["CorretorGestorId"] = new SelectList(_context.Corretores, "CorretorId", "Cpf", imovei.CorretorGestorId);
            ViewData["CorretorNegocioId"] = new SelectList(_context.Corretores, "CorretorId", "Cpf", imovei.CorretorNegocioId);
            return View(imovei);
        }

        // GET: Imoveis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovei = await _context.Imoveis.FindAsync(id);
            if (imovei == null)
            {
                return NotFound();
            }
            ViewData["ClienteDonoId"] = new SelectList(_context.Clientes, "ClienteId", "Cpf", imovei.ClienteDonoId);
            ViewData["CorretorGestorId"] = new SelectList(_context.Corretores, "CorretorId", "Cpf", imovei.CorretorGestorId);
            ViewData["CorretorNegocioId"] = new SelectList(_context.Corretores, "CorretorId", "Cpf", imovei.CorretorNegocioId);
            return View(imovei);
        }

        // POST: Imoveis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImovelId,Endereco,Tipo,Area,Valor,Descricao,Negocio,CorretorNegocioId,CorretorGestorId,ClienteDonoId,Disponivel,Fotos")] Imovei imovei)
        {
            if (id != imovei.ImovelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imovei);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImoveiExists(imovei.ImovelId))
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
            ViewData["ClienteDonoId"] = new SelectList(_context.Clientes, "ClienteId", "Cpf", imovei.ClienteDonoId);
            ViewData["CorretorGestorId"] = new SelectList(_context.Corretores, "CorretorId", "Cpf", imovei.CorretorGestorId);
            ViewData["CorretorNegocioId"] = new SelectList(_context.Corretores, "CorretorId", "Cpf", imovei.CorretorNegocioId);
            return View(imovei);
        }

        // GET: Imoveis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovei = await _context.Imoveis
                .Include(i => i.ClienteDono)
                .Include(i => i.CorretorGestor)
                .Include(i => i.CorretorNegocio)
                .FirstOrDefaultAsync(m => m.ImovelId == id);
            if (imovei == null)
            {
                return NotFound();
            }

            return View(imovei);
        }

        // POST: Imoveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imovei = await _context.Imoveis.FindAsync(id);
            if (imovei != null)
            {
                _context.Imoveis.Remove(imovei);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImoveiExists(int id)
        {
            return _context.Imoveis.Any(e => e.ImovelId == id);
        }
    }
}
