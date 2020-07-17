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
    public class RegistrationsController : Controller
    {
        private readonly ManagementDbContext _context;

        public RegistrationsController(ManagementDbContext context)
        {
            _context = context;
        }

        // GET: Registrations
        public async Task<IActionResult> Index()
        {
            var managementDbContext = _context.RegistrationTable.Include(r => r.Batches).Include(r => r.Courses);
            return View(await managementDbContext.ToListAsync());
        }

        // GET: Registrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.RegistrationTable
                .Include(r => r.Batches)
                .Include(r => r.Courses)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // GET: Registrations/Create
        public IActionResult Create()
        {
            ViewData["BatchesID"] = new SelectList(_context.BatchTable, "Id", "Id");
            ViewData["CoursesID"] = new SelectList(_context.CourseTable, "Id", "Name");
            return View();
        }

        // POST: Registrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,CoursesID,BatchesID,PhoneNumber")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BatchesID"] = new SelectList(_context.BatchTable, "Id", "Id", registration.BatchesID);
            ViewData["CoursesID"] = new SelectList(_context.CourseTable, "Id", "Name", registration.CoursesID);
            return View(registration);
        }

        // GET: Registrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.RegistrationTable.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            ViewData["BatchesID"] = new SelectList(_context.BatchTable, "Id", "Id", registration.BatchesID);
            ViewData["CoursesID"] = new SelectList(_context.CourseTable, "Id", "Name", registration.CoursesID);
            return View(registration);
        }

        // POST: Registrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,CoursesID,BatchesID,PhoneNumber")] Registration registration)
        {
            if (id != registration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationExists(registration.Id))
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
            ViewData["BatchesID"] = new SelectList(_context.BatchTable, "Id", "Id", registration.BatchesID);
            ViewData["CoursesID"] = new SelectList(_context.CourseTable, "Id", "Name", registration.CoursesID);
            return View(registration);
        }

        // GET: Registrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.RegistrationTable
                .Include(r => r.Batches)
                .Include(r => r.Courses)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registration = await _context.RegistrationTable.FindAsync(id);
            _context.RegistrationTable.Remove(registration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationExists(int id)
        {
            return _context.RegistrationTable.Any(e => e.Id == id);
        }
    }
}
