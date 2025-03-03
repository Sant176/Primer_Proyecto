using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebEmpresa.Models;

namespace Primer_Proyecto.Controllers
{
    public class VentasViewModelsController : Controller
    {
        private readonly AppDbContext _context;

        public VentasViewModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: VentasViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.VentasViewModel.ToListAsync());
        }

        // GET: VentasViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasViewModel = await _context.VentasViewModel
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (ventasViewModel == null)
            {
                return NotFound();
            }

            return View(ventasViewModel);
        }

        // GET: VentasViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VentasViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,Fecha,VentaId,Estado,Total")] VentasViewModel ventasViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventasViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventasViewModel);
        }

        // GET: VentasViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasViewModel = await _context.VentasViewModel.FindAsync(id);
            if (ventasViewModel == null)
            {
                return NotFound();
            }
            return View(ventasViewModel);
        }

        // POST: VentasViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Fecha,VentaId,Estado,Total")] VentasViewModel ventasViewModel)
        {
            if (id != ventasViewModel.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventasViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentasViewModelExists(ventasViewModel.ClienteId))
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
            return View(ventasViewModel);
        }

        // GET: VentasViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasViewModel = await _context.VentasViewModel
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (ventasViewModel == null)
            {
                return NotFound();
            }

            return View(ventasViewModel);
        }

        // POST: VentasViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventasViewModel = await _context.VentasViewModel.FindAsync(id);
            if (ventasViewModel != null)
            {
                _context.VentasViewModel.Remove(ventasViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentasViewModelExists(int id)
        {
            return _context.VentasViewModel.Any(e => e.ClienteId == id);
        }
    }
}
