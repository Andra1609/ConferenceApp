using ConferenceWebApp.Data;
using ConferenceWebLibrary.Models;
using ConferenceWebLibrary.Models.Binding;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sponsorWebApp.Controllers
{
    [Route("[Controller]")]
    public class SponsorsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        // Create constructor and inject DbContext
        public SponsorsController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        // Read
        [Route("")]
        public IActionResult Index()
        {
            var allsponsors = dbContext.Sponsors.ToList();
            return View(allsponsors);
        }

        // Read: Details about a sponsor
        [Route("details/{id:int}")]
        public IActionResult Details(int id)
        {
            // gets the cat with the specified id
            var sponsorById = dbContext.Sponsors.FirstOrDefault(c => c.ID == id);
            return View(sponsorById);
        }


        // Update
        [Route("update/{id:int}")]
        public IActionResult Update(int id)
        {
            var sponsorById = dbContext.Sponsors.FirstOrDefault(c => c.ID == id);
            return View(sponsorById);
        }
        [HttpPost]
        [Route("update/{id:int}")]
        // popoulate the form
        public IActionResult Update(Sponsor sponsor, int id)
        {
            var sponsorToUpdate = dbContext.Sponsors.FirstOrDefault(c => c.ID == id);
            sponsorToUpdate.Name = sponsor.Name;
            sponsorToUpdate.PictureURL = sponsor.PictureURL;
            sponsorToUpdate.Description = sponsor.Description;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // Delete
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var sponsorToDelete = dbContext.Sponsors.FirstOrDefault(c => c.ID == id);
            dbContext.Sponsors.Remove(sponsorToDelete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
