using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMS_Full_Stack_App.Data;
using EMS_Full_Stack_App.Model;

namespace EMS_Full_Stack_App.Controllers
{
    public class EmpProfilesController : Controller
    {
        private readonly DeptMaterDbContext _context;

        public EmpProfilesController(DeptMaterDbContext context)
        {
            _context = context;
        }

        // GET: EmpProfiles
        public async Task<IActionResult> Index()
        {
              return _context.EmpProfile != null ? 
                          View(await _context.EmpProfile.ToListAsync()) :
                          Problem("Entity set 'DeptMaterDbContext.EmpProfile'  is null.");
        }

        // GET: EmpProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmpProfile == null)
            {
                return NotFound();
            }

            var empProfile = await _context.EmpProfile
                .FirstOrDefaultAsync(m => m.EmpCode == id);
            if (empProfile == null)
            {
                return NotFound();
            }

            return View(empProfile);
        }

        // GET: EmpProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpCode,DateOfBirth,EmpName,Email,DeptCode,DeptMasterDeptCode")] EmpProfile empProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empProfile);
        }

        // GET: EmpProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmpProfile == null)
            {
                return NotFound();
            }

            var empProfile = await _context.EmpProfile.FindAsync(id);
            if (empProfile == null)
            {
                return NotFound();
            }
            return View(empProfile);
        }

        // POST: EmpProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpCode,DateOfBirth,EmpName,Email,DeptCode,DeptMasterDeptCode")] EmpProfile empProfile)
        {
            if (id != empProfile.EmpCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpProfileExists(empProfile.EmpCode))
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
            return View(empProfile);
        }

        // GET: EmpProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmpProfile == null)
            {
                return NotFound();
            }

            var empProfile = await _context.EmpProfile
                .FirstOrDefaultAsync(m => m.EmpCode == id);
            if (empProfile == null)
            {
                return NotFound();
            }

            return View(empProfile);
        }

        // POST: EmpProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmpProfile == null)
            {
                return Problem("Entity set 'DeptMaterDbContext.EmpProfile'  is null.");
            }
            var empProfile = await _context.EmpProfile.FindAsync(id);
            if (empProfile != null)
            {
                _context.EmpProfile.Remove(empProfile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpProfileExists(int id)
        {
          return (_context.EmpProfile?.Any(e => e.EmpCode == id)).GetValueOrDefault();
        }
    }
}
