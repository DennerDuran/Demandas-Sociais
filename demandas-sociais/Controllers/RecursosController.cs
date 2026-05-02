using demandas_sociais.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace demandas_sociais.Controllers
{

    [Authorize]
    public class RecursosController : Controller

    {

        private readonly AppDbContext _context;

        public RecursosController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var dados = await _context.Recursos.ToListAsync();

            return View(dados);
        }

        public IActionResult Create()
        {
                 ViewData["DemandaId"] = _context.Demandas
                .Select(d => new SelectListItem
                {
                    Value = d.id.ToString(),
                    Text = d.Nome
                })
                .ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Recursos recursos)
        {
            if (ModelState.IsValid)
            {
                _context.Recursos.Add(recursos);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewData["DemandaId"] = _context.Demandas
                .Select(d => new SelectListItem
                {
                    Value = d.id.ToString(),
                    Text = d.Nome
                })
                .ToList();

            return View(recursos);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Recursos.FindAsync(id);

            if (dados == null)
                return NotFound();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Recursos recursos)
        {
            if (id != recursos.Id)
                return NotFound();

            if (ModelState.IsValid)

            {
                _context.Recursos.Update(recursos);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Recursos.FindAsync(id);

            if (dados == null)
                return NotFound();


            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Recursos.FindAsync(id);

            if (dados == null)
                return NotFound();


            return View(dados);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Recursos.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Recursos.Remove(dados);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");
        }

    }

}
