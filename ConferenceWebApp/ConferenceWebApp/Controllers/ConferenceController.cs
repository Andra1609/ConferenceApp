using ConferenceWebApp.Data;
using ConferenceWebLibrary.Models;
using ConferenceWebLibrary.Models.Binding;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceWebApp.Controllers
{
    [Route("[Controller]")]
    public class ConferenceController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        // Create constructor and inject DbContext
        public ConferenceController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        // Read
        [Route("")]
        public IActionResult Index()
        {
            var allConferences = dbContext.Conferences.ToList();
            return View(allConferences);
        }

        // Read: Details about a conference
        [Route("details/{id:int}")]
        public IActionResult Details(int id)
        {
            // gets the cat with the specified id
            var conferenceById = dbContext.Conferences.FirstOrDefault(c => c.ID == id);
            return View(conferenceById);
        }

        // Create conference
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(AddConferenceBindingModel bindingModel)
        {
            var conferenceToCreate = new Conference
            {
                Name = bindingModel.Name,
                Place = bindingModel.Place
            };
            dbContext.Conferences.Add(conferenceToCreate);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // Sponsor Section
        // Create Sponsor
        [Route("addsponsor/{conferenceID:int}")]
        public IActionResult CreateSponsor(int conferenceID)
        {
            var conference = dbContext.Conferences.FirstOrDefault(c => c.ID == conferenceID);
            ViewBag.ConferenceName = conference.Name;
            ViewBag.ConferenceID = conference.ID;
            return View();
        }

        [HttpPost]
        [Route("addsponsor/{conferenceID:int}")]
        public IActionResult CreateSponsor(AddSponsorBindingModel bindingModel, int conferenceID)
        {
            bindingModel.ConferenceID = conferenceID;
            var sponsorToCreate = new Sponsor
            {
                Name = bindingModel.Name,
                Conference = dbContext.Conferences.FirstOrDefault(c => c.ID == conferenceID)
            };
            dbContext.Sponsors.Add(sponsorToCreate);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("{id:int}/sponsors")]
        public IActionResult ViewSponsors(int id)
        {
            var conference = dbContext.Conferences.FirstOrDefault(c => c.ID == id);
            var sponsors = dbContext.Sponsors.Where(c => c.Conference.ID == id).ToList();
            ViewBag.ConferenceName = conference.Name;
            return View(sponsors);
        }
        // Update
        [Route("update/{id:int}")]
        public IActionResult Update(int id)
        {
            var conferenceById = dbContext.Conferences.FirstOrDefault(c => c.ID == id);
            return View(conferenceById);
        }
        [HttpPost]
        [Route("update/{id:int}")]
        // popoulate the form
        public IActionResult Update(Conference conference, int id)
        {
            var conferenceToUpdate = dbContext.Conferences.FirstOrDefault(c => c.ID == id);
            conferenceToUpdate.Name = conference.Name;
            conferenceToUpdate.Description = conference.Description;
            conferenceToUpdate.PictureURL = conference.PictureURL;
            conferenceToUpdate.Place = conference.Place;
            conferenceToUpdate.ConferenceTime = conference.ConferenceTime;
            conferenceToUpdate.Free = conference.Free;
            conferenceToUpdate.Price = conference.Price;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // Delete
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var catToDelete = dbContext.Conferences.FirstOrDefault(c => c.ID == id);
            dbContext.Conferences.Remove(catToDelete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
