using ConferenceWebApp.Data;
using ConferenceWebApp.Interfaces;
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
        //private readonly ApplicationDbContext dbContext;
        private IRepositoryWrapper repository;

        // Create constructor and inject DbContext
        //public ConferenceController(ApplicationDbContext applicationDbContext, IRepositoryWrapper repositoryWrapper)
        public ConferenceController(IRepositoryWrapper repositoryWrapper)
        {
            //dbContext = applicationDbContext;
            repository = repositoryWrapper;
        }

        // Read
        [Route("")]
        public IActionResult Index()
        {
            //var allConferences = dbContext.Conferences.ToList();
            var allConferences = repository.Conferences.FindAll().ToList();
            return View(allConferences);
        }

        // Read: Details about a conference
        [Route("details/{id:int}")]
        public IActionResult Details(int id)
        {
            // gets the conference with the specified id
            var conferenceById = repository.Conferences.FindByCondition(c => c.ID == id).FirstOrDefault();
            //var conferenceById = dbContext.Conferences.FirstOrDefault(c => c.ID == id);
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
            //dbContext.Conferences.Add(conferenceToCreate);
            repository.Conferences.Create(conferenceToCreate);
            //dbContext.SaveChanges();
            repository.Save();
            return RedirectToAction("Index");
        }

        // Sponsor Section
        // Create Sponsor
        [Route("addsponsor/{conferenceID:int}")]
        public IActionResult CreateSponsor(int conferenceID)
        {
            //var conference = dbContext.Conferences.FirstOrDefault(c => c.ID == conferenceID);
            var conference = repository.Conferences.FindByCondition(c => c.ID == conferenceID).FirstOrDefault();
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
                //Conference = dbContext.Conferences.FirstOrDefault(c => c.ID == conferenceID)
                ConferenceID = conferenceID
            };
            //dbContext.Sponsors.Add(sponsorToCreate);
            repository.Sponsors.Create(sponsorToCreate);
            //dbContext.SaveChanges();
            repository.Save();
            return RedirectToAction("Index");
        }

        [Route("{id:int}/sponsors")]
        public IActionResult ViewSponsors(int id)
        {
            //var conference = dbContext.Conferences.FirstOrDefault(c => c.ID == id);
            var conference = repository.Conferences.FindByCondition(c => c.ID == id).FirstOrDefault();
            //var sponsors = dbContext.Sponsors.Where(c => c.Conference.ID == id).ToList();
            var sponsors = repository.Sponsors.FindByCondition(c => c.ConferenceID == id).ToList().ToList();
            ViewBag.ConferenceName = conference.Name;
            return View(sponsors);
        }
        // Update
        [Route("update/{id:int}")]
        public IActionResult Update(int id)
        {
            //var conferenceById = dbContext.Conferences.FirstOrDefault(c => c.ID == id);
            var conferenceById = repository.Conferences.FindByCondition(c => c.ID == id).FirstOrDefault();
            return View(conferenceById);
        }
        [HttpPost]
        [Route("update/{id:int}")]
        // populate the form
        public IActionResult Update(Conference conference, int id)
        {
            ////var conferenceToUpdate = dbContext.Conferences.FirstOrDefault(c => c.ID == id);
            var conferenceToUpdate = repository.Conferences.FindByCondition(c => c.ID == id).FirstOrDefault();
            conferenceToUpdate.Name = conference.Name;
            conferenceToUpdate.Description = conference.Description;
            conferenceToUpdate.PictureURL = conference.PictureURL;
            conferenceToUpdate.Place = conference.Place;
            conferenceToUpdate.ConferenceTime = conference.ConferenceTime;
            conferenceToUpdate.Free = conference.Free;
            conferenceToUpdate.Price = conference.Price;
            repository.Conferences.Update(conferenceToUpdate);
            //dbContext.SaveChanges();
            repository.Save();
            return RedirectToAction("Index");
        }

        // Delete
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            //var catToDelete = dbContext.Conferences.FirstOrDefault(c => c.ID == id);
            var conferenceToDelete = repository.Conferences.FindByCondition(c => c.ID == id).FirstOrDefault();

            var sponsorToDelete = repository.Sponsors.FindByCondition(c => c.ConferenceID == id);
            foreach(var s in sponsorToDelete)
            {
                repository.Sponsors.Delete(s);
                repository.Save();
            }

            //dbContext.Conferences.Remove(catToDelete);
            repository.Conferences.Delete(conferenceToDelete);
            //dbContext.SaveChanges();
            repository.Save();
            return RedirectToAction("Index");
        }
    }
}
