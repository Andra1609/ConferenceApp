using ConferenceWebApp.Controllers;
using ConferenceWebApp.Interfaces;
using ConferenceWebLibrary.Models;
using ConferenceWebLibrary.Models.Binding;
using ConferenceWebLibrary.Models.View;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConferenceWebTests
{
    public class ConferenceControllerTest
    {
        //private Mock<ILogger<CourseController>> _logger;
        private Mock<IRepositoryWrapper> mockRepo;
        private ConferenceController conferenceController;
        //private AddCourse addCourse;
        private AddConferenceBindingModel addConference;
        private AddSponsorBindingModel addSponsor;
        //private UpdateCourse updateCourse;
        private Conference conference;
        private List<Conference> conferences;
        private Mock<IConference> conferenceMock;
        private List<IConference> conferencesMock;
        private Mock<IAddConference> addConferenceMock;
        private Mock<IAddSponsor> addSponsorMock;
        private Mock<IUpdateConference> updateConferenceMock;
        private Mock<IConferenceViewModel> conferenceViewModelMock;
        private List<IConferenceViewModel> conferencesViewModelMock;

        public ConferenceControllerTest()
        {
            conferenceMock = new Mock<IConference>();
            conferencesMock = new List<IConference> { conferenceMock.Object };
            addConferenceMock = new Mock<IAddConference>();
            addSponsorMock = new Mock<IAddSponsor>();
            updateConferenceMock = new Mock<IUpdateConference>();
            conference = new Conference();
            conferences = new List<Conference>();

            // viewmodels mock 
            conferenceViewModelMock = new Mock<IConferenceViewModel>();
            conferencesViewModelMock = new List<IConferenceViewModel>();

            // sample models
            addConference = new AddConferenceBindingModel { Name = "AI Conference", Place = "London" };
            addSponsor = new AddSponsorBindingModel { Name = "Google" };
            //updateConference = new UpdateConference { Name = "ML Conference", 
            //    ..... };

            // controller setup
            //// courseControllerMock = new Mock<ICourseController>();
            //_logger = new Mock<ILogger<CourseController>>();
            var sponsorMock = new Mock<ISponsor>();
            var sponsorsMock = new List<ISponsor>() { sponsorMock.Object };
            var sponsorResultsMock = new Mock<IActionResult>();

            mockRepo = new Mock<IRepositoryWrapper>();
            var allConferences = GetConferences();
            conferenceController = new ConferenceController(mockRepo.Object);
        }
 
        [Fact]
        public void GetAllConferences_Test()
        {
            // arrange
            mockRepo.Setup(repo => repo.Conferences.FindAll()).Returns(GetConferences().ToList());
            //mockRepo.Setup(repo => repo.Sponsors.FindByCondition(c => c.ConferenceID == It.IsAny<int>())).Returns(GetSponsors());
            // act
            var controllerActionResult = conferenceController.Index();
            // assert
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void GetConference_Test()
        {
            // arrange
            mockRepo.Setup(repo => repo.Conferences.FindByCondition(c => c.ID == It.IsAny<int>())).Returns(GetConferences());
            // act
            var controllerActionResult = conferenceController.Details(It.IsAny<int>());
            // assert
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void AddConferenceView_Test()
        {
            // arrange
            mockRepo.Setup(repo => repo.Conferences.FindByCondition(c => c.ID == It.IsAny<int>())).Returns(GetConferences());
            // act
            var controllerActionResult = conferenceController.Create();
            // assert
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void AddConference_Test()
        {
            // arrange
            mockRepo.Setup(repo => repo.Conferences.FindByCondition(c => c.ID == It.IsAny<int>())).Returns(GetConferences());
            // act
            var controllerActionResult = conferenceController.Create(addConference);
            // assert
            Assert.NotNull(controllerActionResult);
            Assert.IsType<RedirectToActionResult>(controllerActionResult);
        }
        
        [Fact]
        public void DeleteConference_Test()
        {
            // arrange
            mockRepo.Setup(repo => repo.Conferences.FindByCondition(c => c.ID == It.IsAny<int>())).Returns(GetConferences());
            mockRepo.Setup(repo => repo.Sponsors.FindByCondition(c => c.ID == It.IsAny<int>())).Returns(GetSponsors());
            mockRepo.Setup(repo => repo.Conferences.Delete(GetConference()));
            // act
            var controllerActionResult = conferenceController.Delete(It.IsAny<int>());
            // assert
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void UpdateConferenceView_Test()
        {
            // arrange
            mockRepo.Setup(repo => repo.Conferences.FindByCondition(c => c.ID == It.IsAny<int>())).Returns(GetConferences());

            // act
            var controllerActionResult = conferenceController.Update(It.IsAny<int>());
            // assert
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void UpdateConference_Test()
        {
            // arrange
            mockRepo.Setup(repo => repo.Conferences.FindByCondition(c => c.ID == It.IsAny<int>())).Returns(GetConferences());
            mockRepo.Setup(repo => repo.Conferences.Update(GetConference()));
            // act
            var controllerActionResult = conferenceController.Update(It.IsAny<int>());
            // assert
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void AddSponsor_Test()
        {
            // arrange
            mockRepo.Setup(repo => repo.Conferences.FindByCondition(c => c.ID == It.IsAny<int>())).Returns(GetConferences());
            mockRepo.Setup(repo => repo.Sponsors.FindByCondition(c => c.ID == It.IsAny<int>())).Returns(GetSponsors());
            // act
            var controllerActionResult = conferenceController.CreateSponsor(addSponsor, 1);
            // assert
            Assert.NotNull(controllerActionResult);
            //Assert.IsType<RedirectToActionResult>(controllerActionResult);
        }

        private IEnumerable<Sponsor> GetSponsors()
        {
            return new List<Sponsor>() {
                new Sponsor { ID = 1, ConferenceID = GetConferences().ToList()[0].ID, Description="ss", Name="Google", PictureURL="dfsd" },
                new Sponsor { ID = 2, ConferenceID = GetConferences().ToList()[1].ID, Description="ssa", Name="Facebook", PictureURL="sffad" },
            };
        }
        
        private Sponsor GetSponsor()
        {
            return GetSponsors().ToList()[0];
        }
        
        private IEnumerable<Conference> GetConferences()
        {
            var conferences = new List<Conference> {
            new Conference(){ID=1, Name="AI Conference", Place="London", ConferenceTime=DateTime.Now, Description="asdsa", Free="No", PictureURL="asd.",Price=13.4f 
            },
            new Conference(){ID=2, Name="ML Conference", Place="Dublin", ConferenceTime=DateTime.Now, Description="asdsa", Free="No", PictureURL="asd.",Price=14.0f}
            };
            return conferences;
        }
        
        private Conference GetConference()
        {
            return GetConferences().ToList()[0];
        }

    }
}
