using ConferenceWebLibrary.Models;
using ConferenceWebLibrary.Models.View;
using ConferenceWebLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConferenceWebTests.Utility
{
    public class SponsorUtilityTest
    {
        [Fact]
        public void GetViewModel()
        {
            // arrange
            Sponsor testSponsor = new Sponsor()
            {
                ID = 1,
                Name = "Google",
                Description = "Google LLC is an American multinational technology company that specializes in Internet-related services and products, which include online advertising technologies, a search engine, cloud computing, software, and hardware.",
                PictureURL = "https://silvertoad.co.uk/wp-content/uploads/2018/01/google-logo.jpg"
            };
            // act
            var testSponsorVM = testSponsor.GetViewModel();
            // asert
            Assert.IsType<SponsorViewModel>(testSponsorVM);
            Assert.NotNull(testSponsorVM);
            //Assert.NotEmpty(testConferenceVM.PictureURL);
        }

        [Fact]
        public void GetSponsorViewModels()
        {
            // arrange
            List<Sponsor> testSponsors = new List<Sponsor>()
            {
                new Sponsor ()
                {
                    ID = 1,
                    Name = "Google",
                    Description = "Google LLC is an American multinational technology company that specializes in Internet-related services and products, which include online advertising technologies, a search engine, cloud computing, software, and hardware.",
                    PictureURL = "https://silvertoad.co.uk/wp-content/uploads/2018/01/google-logo.jpg"
                },
                new Sponsor ()
                {
                    ID = 2,
                    Name = "Facebook",
                    Description = "Facebook, Inc., is an American technology conglomerate based in Menlo Park, California.",
                    PictureURL = "https://wordstream-files-prod.s3.amazonaws.com/s3fs-public/styles/simple_image/public/images/facebook-logo-stats-2018.png?xnmV_wKuqClXX297l4IsIMmIYZJZrktk&itok=NuRNkmk0"
                },
                new Sponsor ()
                {
                    ID = 3,
                    Name = "Microsoft",
                    Description = "Microsoft Corporation is an American multinational technology company with headquarters in Redmond, Washington.",
                    PictureURL = "https://www.cnet.com/a/img/NmTo06FvEM6ZR9ld7a3_wlBKz7Y=/1200x675/2019/02/04/8311b046-6f2b-4b98-8036-e765f572efad/msft-microsoft-logo-2-3.jpg"
                }
            };
            // act
            var testSponsorsVM = testSponsors.GetSponsorViewModels();
            // assert
            Assert.NotEmpty(testSponsorsVM);
            Assert.IsType<List<SponsorViewModel>>(testSponsorsVM);
        }
    }
}
