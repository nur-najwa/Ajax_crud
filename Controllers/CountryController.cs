using Ajax_crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using System.Diagnostics.Metrics;
using System.Reflection;
using static Ajax_crud.Data.AppDbContext;

namespace Ajax_crud.Controllers
{
    public class CountryController : Controller
    {
        private readonly AppDbContexts _context;
        private readonly ILogger<CountryController> _logger;
        public CountryController(AppDbContexts context, ILogger<CountryController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            List<CountryListingModel> students = _context.Country.ToList(); 
            return View(students);
        }

        public IActionResult Add() 
        {
            return View(new CountryAddModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(CountryAddModel model)
        {
            if (ModelState.IsValid) 
            {
                var country = new CountryListingModel
                {
                    Id = model.Id,
                    CountryCode = model.CountryCode,
                    Price = model.Price
                };

                _context.Country.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(this.Index));
            }
            return Json(new { errorMessage = "" });
        }

        public async Task<IActionResult> Edit(int Id)
        { 
            if(ModelState.IsValid)
            {
                var country = await _context.Country.FindAsync(Id);
                if (country == null) 
                { 
                    return NotFound();  
                }

                var model = new CountryEditModel
                {
                    Id = country.Id,
                    CountryCode = country.CountryCode,  
                    Price = country.Price   
                };

                return View(model);
            }
            return RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CountryEditModel model)
        {
            if (ModelState.IsValid)
            {
                var country = await _context.Country.FindAsync(model.Id);

                country.CountryCode = model.CountryCode;
                country.Price = model.Price;

                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Country");
            }
            return Json(new { errorMessage = "Invalid model state" });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var country = await _context.Country.FindAsync(Id);
            if (country == null)
            {
                return Json(new { success = false });
            }

            _context.Country.Remove(country);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

    }
}


