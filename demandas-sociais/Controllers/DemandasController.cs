using demandas_sociais.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace demandas_sociais.Controllers

{
    [Authorize]
    public class DemandasController : Controller
       
    {
        private readonly AppDbContext _context;
        public DemandasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Demandas.ToListAsync();  

            return View(dados);
        }

       
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Demandas demandas)
        {
            if (ModelState.IsValid)
            {
                _context.Demandas.Add(demandas);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        
            public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Demandas.FindAsync(id);

            if (dados == null)
                return NotFound();  
            return View(dados);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Demandas demandas)
        {
            if (id != demandas.id)
                return NotFound();

            if (ModelState.IsValid)

            {
                _context.Demandas.Update(demandas);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            return View();
        }

        public async Task<IActionResult> Details (int?  id)
        {
            if(id == null)  
                return NotFound();

            var dados = await _context.Demandas.FindAsync(id);

            if(dados == null)
                return NotFound();
            

            return View(dados);
        }

            public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Demandas.FindAsync(id);

            if (dados == null)
                return NotFound();


            return View(dados);
        }
    

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Demandas.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Demandas.Remove(dados);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Relatorio(int? id)
        {
            if (id == null)
                return NotFound();

            var demandas = await _context.Demandas.FindAsync(id);

            if (demandas == null)
                return NotFound();

            var recursos = await _context.Recursos
                .Where(c => c.DemandaId == id)
                .OrderByDescending(c => c.Data)
                .ToListAsync();

            decimal total = recursos.Sum(c => c.Custo);

            ViewBag.Demandas = demandas;
            ViewBag.Total = total;

            return View(recursos);
        }
    }
}
