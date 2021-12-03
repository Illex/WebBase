using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace WebBase
{
    public class EnrollmentHistsController : Controller
    {
        private readonly SchoolContext _context;

        public EnrollmentHistsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: EnrollmentHists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hists.ToListAsync());
        }

        // GET: EnrollmentHists/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollmentHist = await _context.Hists
                .FirstOrDefaultAsync(m => m.EnrollmentHistID == id);
            if (enrollmentHist == null)
            {
                return NotFound();
            }

            return View(enrollmentHist);
        }

        // GET: EnrollmentHists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnrollmentHists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentHistID,course,date,enrollments")] EnrollmentHist enrollmentHist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollmentHist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enrollmentHist);
        }

        // GET: EnrollmentHists/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollmentHist = await _context.Hists.FindAsync(id);
            if (enrollmentHist == null)
            {
                return NotFound();
            }
            return View(enrollmentHist);
        }

        // POST: EnrollmentHists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EnrollmentHistID,course,date,enrollments")] EnrollmentHist enrollmentHist)
        {
            if (id != enrollmentHist.EnrollmentHistID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollmentHist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentHistExists(enrollmentHist.EnrollmentHistID))
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
            return View(enrollmentHist);
        }

        // GET: EnrollmentHists/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollmentHist = await _context.Hists
                .FirstOrDefaultAsync(m => m.EnrollmentHistID == id);
            if (enrollmentHist == null)
            {
                return NotFound();
            }

            return View(enrollmentHist);
        }

        // POST: EnrollmentHists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var enrollmentHist = await _context.Hists.FindAsync(id);
            _context.Hists.Remove(enrollmentHist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentHistExists(string id)
        {
            return _context.Hists.Any(e => e.EnrollmentHistID == id);
        }
    }
}
