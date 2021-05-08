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
    public class SponsorController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public SponsorController(ApplicationDbContext applocationDbContext) 
        {
            dbContext = applocationDbContext;
        }
        // perform a request to retrieve info
        [HttpGet("")]
        public IActionResult GetAllSponsors()
        {
            var allsponsors = dbContext.Sponsors.ToList();
            return Ok(allsponsors.GetSponsorViewModels());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetSponsorById(int id)
        {
            var sponsorById = dbContext.Sponsors.FirstOrDefault(c => c.ID == id);
            if (sponsorById == null)
                return NotFound();
            return Ok(sponsorById.GetViewModel());
        }

        [HttpPost("")]
        public IActionResult CreateSponsor([FromBody] AddSponsorBindingModel bindingModel)
        {
            var sponsorToCreate = new Sponsor
            {
                Name = bindingModel.Name,
                ConferenceID = bindingModel.ConferenceID
                //Conference = dbContext.Conferences.FirstOrDefault(c => c.ID == bindingModel.ConferenceID)
            };
            var createdSponsor = dbContext.Sponsors.Add(sponsorToCreate).Entity;
            dbContext.SaveChanges();

            var sponsorVM = new SponsorViewModel()
            {
                ID = createdSponsor.ID,
                Name = createdSponsor.Name
            };

            return Ok(sponsorVM);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSponsor([FromBody] Sponsor sponsor, int id)
        {
            var sponsorById = dbContext.Sponsors.FirstOrDefault(c => c.ID == id);
            if (sponsorById == null)
                return NotFound();
            sponsorById.Name = sponsor.Name;
            sponsorById.PictureURL = sponsor.PictureURL;
            sponsorById.Description = sponsor.Description;
            dbContext.SaveChanges();
            return Ok(sponsorById.GetViewModel());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSponsor(int id)
        {
            var sponsorToDelete = dbContext.Sponsors.FirstOrDefault(c => c.ID == id);
            if (sponsorToDelete == null)
                return NotFound();
            dbContext.Sponsors.Remove(sponsorToDelete);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
