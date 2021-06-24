using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eDrugs.ApplicationCore;
using eDrugs.DbAccess;
using eDrugs.Models;
using Microsoft.AspNetCore.Authorization;

namespace eDrugs.Controllers
{
    [Authorize]
    public class DrugMfgInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DrugMfgInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DrugMfgInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DrugMfgInfos.ToListAsync());
        }

        // GET: DrugMfgInfoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drugMfgInfo = await _context.DrugMfgInfos
                .Where(m => m.Id == id).Include(m=> m.Drug).FirstOrDefaultAsync();
            if (drugMfgInfo == null)
            {
                return NotFound();
            }

            return View(drugMfgInfo);
        }

        // GET: DrugMfgInfoes/Create
        public async Task<IActionResult> Create()
        {
            
            
            var model = new DrugMfgInfoViewModel
            {
                Drugs = new List<SelectListItem>()
            };
            await IncludeDrugsToViewModel(model);


            return View(model);
        }

        private async Task IncludeDrugsToViewModel(DrugMfgInfoViewModel model)
        {
            await _context.Drugs.ForEachAsync(d =>
            {
                var item = new SelectListItem
                {
                    Text = d.GenericName,
                    Value = d.Id.ToString()
                };
                model.Drugs.Add(item);
            });
        }

        // POST: DrugMfgInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DrugMfgInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var drugMfgInfo = new DrugMfgInfo
                {
                    Drug = await _context.Drugs.FirstOrDefaultAsync(p=> p.Id == model.DrugId),
                    Mrp = model.Mrp,
                    TypeOfDrugs = model.TypeOfDrugs,
                    UnitAmount = model.UnitAmount,
                    MfgDate = model.MfgDate,
                    ExpDate = model.ExpDate
                };
                _context.Add(drugMfgInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: DrugMfgInfoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drugMfgInfo = await _context.DrugMfgInfos.Where(p=> p.Id == id)
                .Include(p=>p.Drug).FirstOrDefaultAsync();
            if (drugMfgInfo == null)
            {
                return NotFound();
            }

            var model = new DrugMfgInfoViewModel
            {
                Id = drugMfgInfo.Id,
                ExpDate = drugMfgInfo.ExpDate,
                MfgDate = drugMfgInfo.MfgDate,
                DrugId = drugMfgInfo.Drug.Id,
                Drugs = new List<SelectListItem>(),
                Mrp = drugMfgInfo.Mrp,
                TypeOfDrugs = drugMfgInfo.TypeOfDrugs,
                UnitAmount = drugMfgInfo.UnitAmount
            };
            await IncludeDrugsToViewModel(model);
            return View(model);
        }

        // POST: DrugMfgInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DrugMfgInfoViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var drugMfgInfo = await _context.DrugMfgInfos.FindAsync(model.Id);
                drugMfgInfo.Drug = await _context.Drugs.FindAsync(model.DrugId);
                drugMfgInfo.ExpDate = model.ExpDate;
                drugMfgInfo.MfgDate = model.MfgDate;
                drugMfgInfo.TypeOfDrugs = model.TypeOfDrugs;
                drugMfgInfo.Mrp = model.Mrp;
                drugMfgInfo.UnitAmount = model.UnitAmount;
                try
                {
                   var entry = _context.DrugMfgInfos.Attach(drugMfgInfo);
                   entry.State = EntityState.Modified;
                    //_context.Update(drugMfgInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrugMfgInfoExists(drugMfgInfo.Id))
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
            return View(model);
        }

        // GET: DrugMfgInfoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drugMfgInfo = await _context.DrugMfgInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drugMfgInfo == null)
            {
                return NotFound();
            }

            return View(drugMfgInfo);
        }

        // POST: DrugMfgInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var drugMfgInfo = await _context.DrugMfgInfos.FindAsync(id);
            _context.DrugMfgInfos.Remove(drugMfgInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrugMfgInfoExists(Guid id)
        {
            return _context.DrugMfgInfos.Any(e => e.Id == id);
        }
    }
}
