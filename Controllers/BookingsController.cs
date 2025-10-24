using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClidesCustoms.Data;
using ClidesCustoms.Models;

namespace ClidesCustoms.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BookingsController> _logger;

        public BookingsController(ApplicationDbContext context, ILogger<BookingsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var bookings = await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Service)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();
            
            return View(bookings);
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Service)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public async Task<IActionResult> Create()
        {
            var services = await _context.Services.Where(s => s.IsActive).ToListAsync();
            var customers = await _context.Customers.ToListAsync();
            
            if (!services.Any())
            {
                TempData["Error"] = "No services are available. Please add services first.";
                return RedirectToAction(nameof(Index));
            }
            
            if (!customers.Any())
            {
                TempData["Error"] = "No customers found. Please add customers first.";
                return RedirectToAction(nameof(Index));
            }
            
            ViewBag.Services = services;
            ViewBag.Customers = customers;
            return View();
        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,ServiceId,BookingDate,VehicleMake,VehicleModel,VehicleYear,licensePlate,notes")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    booking.status = "pending";
                    booking.CreatedAt = DateTime.UtcNow;
                    _context.Add(booking);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Booking created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "An error occurred while creating the booking: " + ex.Message;
                }
            }
            
            // Reload data for the view if there are validation errors
            ViewBag.Services = await _context.Services.Where(s => s.IsActive).ToListAsync();
            ViewBag.Customers = await _context.Customers.ToListAsync();
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            
            ViewBag.Services = await _context.Services.Where(s => s.IsActive).ToListAsync();
            ViewBag.Customers = await _context.Customers.ToListAsync();
            return View(booking);
        }

        // POST: Bookings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,ServiceId,BookingDate,VehicleMake,VehicleModel,VehicleYear,licensePlate,status,notes")] Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.Id))
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
            
            ViewBag.Services = await _context.Services.Where(s => s.IsActive).ToListAsync();
            ViewBag.Customers = await _context.Customers.ToListAsync();
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }
    }
}
