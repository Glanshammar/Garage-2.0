using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage_2._0.Data;
using Garage_2._0.Models;

namespace Garage_2._0.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private readonly Garage_2_0Context _context;

        public ParkedVehiclesController(Garage_2_0Context context)
        {
            _context = context;
        }

        // GET: ParkedVehicles
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParkedVehicle.ToListAsync());
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

        // GET: ParkedVehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle != null)
            {
                _context.ParkedVehicle.Remove(parkedVehicle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkedVehicleExists(int id)
        {
            return _context.ParkedVehicle.Any(e => e.Id == id);
        }
    }
}