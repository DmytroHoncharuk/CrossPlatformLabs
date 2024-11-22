using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class StaffController : Controller
{
    private readonly AppDbContext _context;

    public StaffController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var staffList = await _context.Staff
            .Include(s => s.JobTitle)
            .OrderBy(s => s.StaffName)
            .ToListAsync();
        return View(staffList);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var staff = await _context.Staff
            .Include(s => s.JobTitle)
            .Include(s => s.Appointments)
                .ThenInclude(a => a.Client)
            .FirstOrDefaultAsync(s => s.StaffId == id);

        if (staff is null)
        {
            return NotFound();
        }

        var recentAppointments = await _context.Appointments
            .Include(a => a.Client)
            .Where(a => a.StaffId == id)
            .OrderByDescending(a => a.AppointmentDate)
            .Take(5)
            .ToListAsync();

        ViewData["RecentAppointments"] = recentAppointments;
        return View(staff);
    }

    public IActionResult Create()
    {
        ViewData["JobTitles"] = _context.StaffJobTitles.ToList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("StaffId,JobCode,StaffName,StaffDetails,DateJoined,DateLeft")] Staff staff)
    {
        if (ModelState.IsValid)
        {
            _context.Add(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["JobTitles"] = _context.StaffJobTitles.ToList();
        return View(staff);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var staff = await _context.Staff.FindAsync(id);
        if (staff is null)
        {
            return NotFound();
        }

        ViewData["JobTitles"] = _context.StaffJobTitles.ToList();
        return View(staff);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("StaffId,JobCode,StaffName,StaffDetails,DateJoined,DateLeft")] Staff staff)
    {
        if (id != staff.StaffId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(staff);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(staff.StaffId))
                {
                    return NotFound();
                }
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["JobTitles"] = _context.StaffJobTitles.ToList();
        return View(staff);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var staff = await _context.Staff
            .Include(s => s.JobTitle)
            .FirstOrDefaultAsync(s => s.StaffId == id);

        if (staff is null)
        {
            return NotFound();
        }

        return View(staff);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var staff = await _context.Staff.FindAsync(id);
        if (staff != null)
        {
            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    private bool StaffExists(int id)
    {
        return _context.Staff.Any(e => e.StaffId == id);
    }
}
