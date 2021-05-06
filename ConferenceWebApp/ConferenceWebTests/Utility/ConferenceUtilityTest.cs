using ConferenceWebLibrary.Models;
using ConferenceWebLibrary.Models.View;
using ConferenceWebLibrary.Utility;
using System;
using System.Collections.Generic;
using Xunit;

namespace ConferenceWebTests.Utility
{
    public class ConferenceUtilityTest
    {
        [Fact]
        public void GetViewModel()
        {
            // arrange
            Conference testConference = new Conference()
            {
                ID = 1,
                Name = "AI Conference",
                Description = "Conference about AI",
                PictureURL = "",
                Place = "London",
                ConferenceTime = new DateTime(2021, 11, 25),
                Free = "No",
                Price = 13.5f
            };
            // act
            var testConferenceVM = testConference.GetViewModel();
            // asert
            Assert.IsType<ConferenceViewModel>(testConferenceVM);
            Assert.NotNull(testConferenceVM);
            //Assert.NotEmpty(testConferenceVM.PictureURL);
        }

        [Fact]
        public void GetViewModels()
        {
            // arrange
            List<Conference> testConferences = new List<Conference>()
            {
                new Conference ()
                {
                    ID = 1,
                    Name = "AI Conference",
                    Description = "Conference about AI",
                    PictureURL = "",
                    Place = "London",
                    ConferenceTime = new DateTime(2021, 11, 25),
                    Free = "No",
                    Price = 13.5f
                },
                new Conference ()
                {
                    ID = 2,
                    Name = "ML Conference",
                    Description = "Conference about ML",
                    PictureURL = "",
                    Place = "Manchester",
                    ConferenceTime = new DateTime(2021, 10, 22),
                    Free = "No",
                    Price = 500.25f
                },
                new Conference ()
                {
                    ID = 3,
                    Name = "Deep Learning Conference",
                    Description = "Conference about Deep Learning",
                    PictureURL = "",
                    Place = "Dublin",
                    ConferenceTime = new DateTime(2022, 06, 01),
                    Free = "No",
                    Price = 50.5f
                }
            };
            // act
            var testConferencesVM = testConferences.GetConferenceViewModels();
            // assert
            Assert.NotEmpty(testConferencesVM);
            Assert.IsType<List<ConferenceViewModel>>(testConferencesVM);

        }
    }
}
