using ConferenceWebLibrary.Models;
using ConferenceWebLibrary.Models.View;
using System.Collections.Generic;

namespace ConferenceWebLibrary.Utility
{
    public static class SponsorUtility
    {
        // this cause it's extension method
        public static SponsorViewModel GetViewModel(this Sponsor sponsor)
        {
            var sponsorVM = new SponsorViewModel()
            {
                ID = sponsor.ID,
                Name = sponsor.Name,
                Description = sponsor.Description,
                PictureURL = sponsor.PictureURL
            };
            return sponsorVM;
        }

        public static List<SponsorViewModel> GetSponsorViewModels(this List<Sponsor> sponsors)
        {
            var allSponsorsVM = new List<SponsorViewModel>();
            foreach (var sponsor in sponsors)
            {
                allSponsorsVM.Add(new SponsorViewModel()
                {
                    ID = sponsor.ID,
                    Name = sponsor.Name,
                    Description = sponsor.Description,
                    PictureURL = sponsor.PictureURL
                });
            }
            return allSponsorsVM;
        }
    }
}
