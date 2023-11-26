using ClassAbstract.Data;
using ClassAbstract.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassAbstract.Controllers
{
    public class LocadoraController : Controller
    {
        private readonly FilmeContext _context;

        public LocadoraController(FilmeContext context) 
        {
            _context = context;        
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Locadoras.OrderBy(i => i.Nome).ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Nome", "Descricao")] Locadora locadora)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(locadora);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("Erro de cadastro", "Não foi possível cadastrar a instituição.");
            }
            return View(locadora);
        }
        public async Task<ActionResult> Edit(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var locadora = await _context.Locadoras.SingleOrDefaultAsync(i => i.LocadoraId == id);
            if (locadora == null)
            {
                return NotFound();
            }
            return View(locadora);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("LocadoraId", "Nome", "Descricao")] Locadora locadora)
        {
            if (id != locadora.LocadoraId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locadora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!LocadoraExists(locadora.LocadoraId))
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
            return View(locadora);
        }

        private bool LocadoraExists(long? locadoraId)
        {
            var locadora = _context.Locadoras.FirstOrDefault(i => i.LocadoraId == locadoraId);
            if (locadora == null)
                return false;
            return true;
        }
        public async Task<ActionResult> Details(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var locadora = await _context.Locadoras.SingleOrDefaultAsync(i => i.LocadoraId == id);
            if (locadora == null)
            {
                return NotFound();
            }
            return View(locadora);
        }
        public async Task<ActionResult> Delete(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var locadora = await _context.Locadoras.SingleOrDefaultAsync(i => i.LocadoraId == id);
            if (locadora == null)
            {
                return NotFound();
            }
            return View(locadora);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) 
        {
            var locadora = await _context.Locadoras.SingleOrDefaultAsync(i => i.LocadoraId == id);
            _context.Locadoras.Remove(locadora);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
