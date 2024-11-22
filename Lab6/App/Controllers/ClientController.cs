using System.Globalization;
using System.Linq;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

public class ClientsController : Controller
{
    private readonly AppDbContext _context;

    public ClientsController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Search()
    {
        var viewModel = new ClientSearchViewModel();
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Search(ClientSearchViewModel searchModel)
    {
        var query = _context.Clients
            .Include(c => c.AgeBand)
            .Include(c => c.Gender)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchModel.FirstName))
        {
            var searchTerm = searchModel.FirstName.Trim().ToLower(CultureInfo.InvariantCulture);
            query = query.Where(c => c.FirstName.ToLower().Contains(searchTerm));
        }

        if (!string.IsNullOrWhiteSpace(searchModel.LastName))
        {
            var searchTerm = searchModel.LastName.Trim().ToLower(CultureInfo.InvariantCulture);
            query = query.Where(c => c.LastName.ToLower().Contains(searchTerm));
        }

        if (!string.IsNullOrWhiteSpace(searchModel.AgeBandCode))
        {
            query = query.Where(c => c.AgeBandCode == searchModel.AgeBandCode);
        }

        if (!string.IsNullOrWhiteSpace(searchModel.GenderCode))
        {
            query = query.Where(c => c.GenderCode == searchModel.GenderCode);
        }

        searchModel.Results = await query
            .OrderBy(c => c.LastName)
            .ThenBy(c => c.FirstName)
            .ToListAsync();
        searchModel.SearchPerformed = true;
        return View(searchModel);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var client = await _context.Clients
            .Include(c => c.AgeBand)
            .Include(c => c.Gender)
            .Include(c => c.Appointments)
                .ThenInclude(a => a.Staff)
            .Include(c => c.PaymentDetails)
            .FirstOrDefaultAsync(c => c.ClientId == id);

        if (client is null)
        {
            return NotFound();
        }

        var recentAppointments = client.Appointments
            .OrderByDescending(a => a.AppointmentDate)
            .Take(5)
            .ToList();

        ViewData["RecentAppointments"] = recentAppointments;
        return View(client);
    }
}
