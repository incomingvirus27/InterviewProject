using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InterviewProject.Data;
using InterviewProject.Models;

namespace InterviewProject.Controllers
{
    public class BatchesController : Controller
    {
        private readonly ManagementDbContext _context;

        public BatchesController(ManagementDbContext context)
        {
            _context = context;
        }

        // GET: Batches
        public async Task<IActionResult> Index()
        {
            return View(await _context.BatchTable.ToListAsync());
        }

        // GET: Batches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batches = await _context.BatchTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (batches == null)
            {
                return NotFound();
            }

            return View(batches);
        }

        // GET: Batches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Batches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Batch,Year")] Batches batches)
        {
            if (ModelState.IsValid)
            {
                _context.Add(batches);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(batches);
        }

        // GET: Batches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batches = await _context.BatchTable.FindAsync(id);
            if (batches == null)
            {
                return NotFound();
            }
            return View(batches);
        }

        // POST: Batches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Batch,Year")] Batches batches)
        {
            if (id != batches.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(batches);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatchesExists(batches.Id))
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
            return View(batches);
        }

        // GET: Batches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batches = await _context.BatchTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (batches == null)
            {
                return NotFound();
            }

            return View(batches);
        }

        // POST: Batches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var batches = await _context.BatchTable.FindAsync(id);
            _context.BatchTable.Remove(batches);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatchesExists(int id)
        {
            return _context.BatchTable.Any(e => e.Id == id);
        }
    }
}
