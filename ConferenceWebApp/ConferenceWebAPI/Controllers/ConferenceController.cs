using ConferenceWebAPI.Data;
using ConferenceWebLibrary.Models;
using ConferenceWebLibrary.Models.Binding;
using ConferenceWebLibrary.Models.View;
using ConferenceWebLibrary.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public ConferenceController(ApplicationDbContext applocationDbContext)
        {
            dbContext = applocationDbContext;
        }
        // perform a request to retrieve info
        [HttpGet("")]
        public IActionResult GetAllConferences()
        {
            var allConferences = dbContext.Conferences.ToList();
            //var allConferencesVM = new List<ConferenceViewModel>();
            //foreach (var conference in allConferences)
            //{
            //    allConferencesVM.Add(new ConferenceViewModel() {
            //        ID = conference.ID,
            //        Name = conference.Name,
            //        Description = conference.Description,
            //        PictureURL = conference.PictureURL,
            //        Place = conference.Place,
            //        ConferenceTime = conference.ConferenceTime,
            //        Free = conference.Free,
            //        Price = conference.Price
            //    });
            //}
            return Ok(allConferences.GetConferenceViewModels());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetConferenceById(int id)
        {
            var ConferenceById = dbContext.Conferences.FirstOrDefault(c => c.ID == id);
            if (ConferenceById == null)
                return NotFound();
            //var conferenceVM = new ConferenceViewModel () {
            //    ID = ConferenceById.ID,
            //    Name = ConferenceById.Name,
            //    Description = ConferenceById.Description,
            //    PictureURL = ConferenceById.PictureURL,
            //    Place = ConferenceById.Place,
            //    ConferenceTime = ConferenceById.ConferenceTime,
            //    Free = ConferenceById.Free,
            //    Price = ConferenceById.Price
            //};
            return Ok(ConferenceById.GetViewModel());
        }

        [HttpPost("")]
        public IActionResult CreateConference([FromBody] AddConferenceBindingModel bindingModel)
        {
            var ConferenceToCreate = new Conference
            {
                Name = bindingModel.Name,
                Place = bindingModel.Place
            };
            var createdConference = dbContext.Conferences.Add(ConferenceToCreate).Entity;
            dbContext.SaveChanges();

            var conferenceVM = new ConferenceViewModel()
            {
                ID = createdConference.ID,
                Name = createdConference.Name,
                Place = createdConference.Place
            };

            return Ok(conferenceVM);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateConference([FromBody] Conference Conference, int id)
        {
            var ConferenceById = dbContext.Conferences.FirstOrDefault(c => c.ID == id);
            if (ConferenceById == null)
                return NotFound();
            ConferenceById.Name = Conference.Name;
            ConferenceById.Description = Conference.Description;
            ConferenceById.PictureURL = Conference.PictureURL;
            ConferenceById.Place = Conference.Place;
            ConferenceById.ConferenceTime = Conference.ConferenceTime;
            ConferenceById.Free = Conference.Free;
            ConferenceById.Price = Conference.Price;
            dbContext.SaveChanges();

            return Ok(ConferenceById.GetViewModel());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConference(int id)
        {
            var ConferenceToDelete = dbContext.Conferences.FirstOrDefault(c => c.ID == id);
            if (ConferenceToDelete == null)
                return NotFound();
            dbContext.Conferences.Remove(ConferenceToDelete);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
