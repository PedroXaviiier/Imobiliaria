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
    public class MensagensContatoesController : Controller
    {
        private readonly ImobiliariaDbContext _context;

        public MensagensContatoesController(ImobiliariaDbContext context)
        {
            _context = context;
        }

        // GET: MensagensContatoes
        public async Task<IActionResult> Index()
        {
            var imobiliariaDbContext = _context.MensagensContatos.Include(m => m.Cliente).Include(m => m.Corretor).Include(m => m.Imovel);
            return View(await imobiliariaDbContext.ToListAsync());
        }

        // GET: MensagensContatoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagensContato = await _context.MensagensContatos
                .Include(m => m.Cliente)
                .Include(m => m.Corretor)
                .Include(m => m.Imovel)
                .FirstOrDefaultAsync(m => m.MensagemId == id);
            if (mensagensContato == null)
            {
                return NotFound();
            }

            return View(mensagensContato);
        }

        // GET: MensagensContatoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Cpf");
            ViewData["CorretorId"] = new SelectList(_context.Corretores, "CorretorId", "Cpf");
            ViewData["ImovelId"] = new SelectList(_context.Imoveis, "ImovelId", "Endereco");
            return View();
        }

        // POST: MensagensContatoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MensagemId,ImovelId,ClienteId,CorretorId,Mensagem,DataEnvio")] MensagensContato mensagensContato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mensagensContato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Cpf", mensagensContato.ClienteId);
            ViewData["CorretorId"] = new SelectList(_context.Corretores, "CorretorId", "Cpf", mensagensContato.CorretorId);
            ViewData["ImovelId"] = new SelectList(_context.Imoveis, "ImovelId", "Endereco", mensagensContato.ImovelId);
            return View(mensagensContato);
        }

        // GET: MensagensContatoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagensContato = await _context.MensagensContatos.FindAsync(id);
            if (mensagensContato == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Cpf", mensagensContato.ClienteId);
            ViewData["CorretorId"] = new SelectList(_context.Corretores, "CorretorId", "Cpf", mensagensContato.CorretorId);
            ViewData["ImovelId"] = new SelectList(_context.Imoveis, "ImovelId", "Endereco", mensagensContato.ImovelId);
            return View(mensagensContato);
        }

        // POST: MensagensContatoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MensagemId,ImovelId,ClienteId,CorretorId,Mensagem,DataEnvio")] MensagensContato mensagensContato)
        {
            if (id != mensagensContato.MensagemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mensagensContato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensagensContatoExists(mensagensContato.MensagemId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Cpf", mensagensContato.ClienteId);
            ViewData["CorretorId"] = new SelectList(_context.Corretores, "CorretorId", "Cpf", mensagensContato.CorretorId);
            ViewData["ImovelId"] = new SelectList(_context.Imoveis, "ImovelId", "Endereco", mensagensContato.ImovelId);
            return View(mensagensContato);
        }

        // GET: MensagensContatoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagensContato = await _context.MensagensContatos
                .Include(m => m.Cliente)
                .Include(m => m.Corretor)
                .Include(m => m.Imovel)
                .FirstOrDefaultAsync(m => m.MensagemId == id);
            if (mensagensContato == null)
            {
                return NotFound();
            }

            return View(mensagensContato);
        }

        // POST: MensagensContatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mensagensContato = await _context.MensagensContatos.FindAsync(id);
            if (mensagensContato != null)
            {
                _context.MensagensContatos.Remove(mensagensContato);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensagensContatoExists(int id)
        {
            return _context.MensagensContatos.Any(e => e.MensagemId == id);
        }
    }
}
