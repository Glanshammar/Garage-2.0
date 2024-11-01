using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage_2._0.Data;
using Garage_2._0.Models;
using Garage_2._0.Models.ViewModels;

namespace Garage_2._0.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private readonly Garage_2_0Context _context;
        private readonly IMemoryCache _cache;
        
        public ParkedVehiclesController(Garage_2_0Context context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        // GET: ParkedVehicles
        
        public async Task<IActionResult> Index()
        {
            const string cacheKey = "ParkedVehiclesIndex";
    
            // Attempt to get the cached value
            if (!_cache.TryGetValue(cacheKey, out List<ParkedVehicleIndexViewModel> model))
            {
                // Cache miss, so we need to query the database
                var parkedVehicles = await _context.ParkedVehicle
                    .Select(e => new ParkedVehicleIndexViewModel
                    {
                        Id = e.Id,
                        VehicleType = e.VehicleType,
                        RegistrationNumber = e.RegistrationNumber,
                        ArrivalTime = e.ArrivalTime,
                        ParkedTime = DateTime.Now.Subtract(e.ArrivalTime)
                    })
                    .ToListAsync();

                // Set cache options
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(1));

                // Save data in cache
                _cache.Set(cacheKey, parkedVehicles, cacheEntryOptions);

                // Assign the freshly queried data to model
                model = parkedVehicles;
            }

            // Ensure model is not null before passing to the view
            return View("Index", model ?? new List<ParkedVehicleIndexViewModel>());
        }

        // GET: ParkedVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public IActionResult Create()
        {
            ViewData["VehicleTypes"] = new SelectList(Enum.GetValues(typeof(VehicleType)));
            return View();
        }

        // POST: ParkedVehicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VehicleType,RegistrationNumber,Color,Brand,Model,NumberOfWheels")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                // Check if the registration number already exists
                if (await _context.ParkedVehicle.AnyAsync(v => v.RegistrationNumber == parkedVehicle.RegistrationNumber))
                {
                    ModelState.AddModelError("RegistrationNumber", "This registration number is already in use.");
                    ViewData["VehicleTypes"] = new SelectList(Enum.GetValues(typeof(VehicleType)));
                    return View(parkedVehicle);
                }

                _context.Add(parkedVehicle);
                await _context.SaveChangesAsync();

                // Invalidate the cache
                _cache.Remove("ParkedVehiclesIndex");

                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleTypes"] = new SelectList(Enum.GetValues(typeof(VehicleType)));
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            ViewData["VehicleTypes"] = new SelectList(Enum.GetValues(typeof(VehicleType)));
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VehicleType,RegistrationNumber,Color,Brand,Model,NumberOfWheels")] ParkedVehicle parkedVehicle)
        {
            if (id != parkedVehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingVehicle = await _context.ParkedVehicle.FindAsync(id);
                    if (existingVehicle == null)
                    {
                        return NotFound();
                    }

                    // Check if the registration number already exists (excluding the current vehicle)
                    if (await _context.ParkedVehicle.AnyAsync(v => v.RegistrationNumber == parkedVehicle.RegistrationNumber && v.Id != id))
                    {
                        ModelState.AddModelError("RegistrationNumber", "This registration number is already in use.");
                        ViewData["VehicleTypes"] = new SelectList(Enum.GetValues(typeof(VehicleType)));
                        return View(parkedVehicle);
                    }

                    existingVehicle.VehicleType = parkedVehicle.VehicleType;
                    existingVehicle.RegistrationNumber = parkedVehicle.RegistrationNumber;
                    existingVehicle.Color = parkedVehicle.Color;
                    existingVehicle.Brand = parkedVehicle.Brand;
                    existingVehicle.Model = parkedVehicle.Model;
                    existingVehicle.NumberOfWheels = parkedVehicle.NumberOfWheels;

                    _context.Update(existingVehicle);
                    await _context.SaveChangesAsync();

                    // Invalidate the cache
                    _cache.Remove("ParkedVehiclesIndex");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkedVehicleExists(parkedVehicle.Id))
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
            ViewData["VehicleTypes"] = new SelectList(Enum.GetValues(typeof(VehicleType)));
            return View(parkedVehicle);
        }



        // GET: ParkedVehicles/Checkout/5
        public async Task<IActionResult> Checkout(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            var checkoutViewModel = new CheckoutViewModel
            {
                Id = parkedVehicle.Id,
                VehicleType = parkedVehicle.VehicleType,
                RegistrationNumber = parkedVehicle.RegistrationNumber,
                ArrivalTime = parkedVehicle.ArrivalTime,
                ParkedTime = DateTime.Now.Subtract(parkedVehicle.ArrivalTime),
                CheckoutTime = DateTime.Now
            };

            return View(checkoutViewModel);
        }

        // POST: ParkedVehicles/Checkout/5
        [HttpPost, ActionName("Checkout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckoutConfirmed(int id)
        {
            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            var checkoutTime = DateTime.Now;
            var parkedTime = checkoutTime - parkedVehicle.ArrivalTime;
            var price = CalculateParkingPrice(parkedTime);

            // Store details in TempData
            TempData["VehicleType"] = parkedVehicle.VehicleType.ToString();
            TempData["RegistrationNumber"] = parkedVehicle.RegistrationNumber;
            TempData["ArrivalTime"] = parkedVehicle.ArrivalTime;
            TempData["CheckoutTime"] = checkoutTime;
            TempData["ParkedTime"] = parkedTime.ToString();
           TempData["Price"] = price.ToString();


            _context.ParkedVehicle.Remove(parkedVehicle);
            await _context.SaveChangesAsync();

            // Invalidate the cache
            _cache.Remove("ParkedVehiclesIndex");

          // return RedirectToAction(nameof(Index));

           // Redirect to ShowReceipt with the vehicle's id to display the final receipt
            return RedirectToAction("ShowReceipt", new { id = id });

        }

        private bool ParkedVehicleExists(int id)
        {
            return _context.ParkedVehicle.Any(e => e.Id == id);
        }


        // GET: ParkedVehicles/ShowReceipt/5
        public async Task<IActionResult> ShowReceipt(int id)
        {
            var parkedVehicle = await _context.ParkedVehicle.FirstOrDefaultAsync(v => v.Id == id);
            if (TempData["RegistrationNumber"] == null)
            {
                return NotFound();
            }

            var receiptViewModel = new ReceiptViewModel
            {
                VehicleType = Enum.Parse<VehicleType>(TempData["VehicleType"].ToString()),
                RegistrationNumber = TempData["RegistrationNumber"].ToString(),
                ArrivalTime = DateTime.Parse(TempData["ArrivalTime"].ToString()),
                CheckoutTime = DateTime.Parse(TempData["CheckoutTime"].ToString()),
                ParkedTime = TimeSpan.Parse(TempData["ParkedTime"].ToString()),
                Price = decimal.Parse(TempData["Price"].ToString()),
                IsConfirmation = false
            };

            return View("ShowReceipt", receiptViewModel);
        }




        // Helper method to calculate the price based on parked time
        private decimal CalculateParkingPrice(TimeSpan parkedTime)
        {
            decimal hourlyRate = 50m; //  hourly rate
            return (decimal)parkedTime.TotalHours * hourlyRate;
        }


    }


}