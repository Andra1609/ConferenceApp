using ConferenceWebLibrary.Models;
using ConferenceWebLibrary.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceWebLibrary.Utility
{
    // static cause we don't need to create instances of it
    public static class ConferenceUtility
    {
        // this cause it's extension method
        public static ConferenceViewModel GetViewModel(this Conference conference)
        {
            var conferenceVM = new ConferenceViewModel()
            {
                ID = conference.ID,
                Name = conference.Name,
                Description = conference.Description,
                PictureURL = conference.PictureURL,
                Place = conference.Place,
                ConferenceTime = conference.ConferenceTime,
                Free = conference.Free,
                Price = conference.Price
            };
            return conferenceVM;
        }

        public static List<ConferenceViewModel> GetConferenceViewModels(this List<Conference> conferences) { 
            var allConferencesVM = new List<ConferenceViewModel>();
            foreach (var conference in conferences)
            {
                allConferencesVM.Add(new ConferenceViewModel()
                {
                    ID = conference.ID,
                    Name = conference.Name,
                    Description = conference.Description,
                    PictureURL = conference.PictureURL,
                    Place = conference.Place,
                    ConferenceTime = conference.ConferenceTime,
                    Free = conference.Free,
                    Price = conference.Price
                });
            }
            return allConferencesVM;
        }
    }
}
