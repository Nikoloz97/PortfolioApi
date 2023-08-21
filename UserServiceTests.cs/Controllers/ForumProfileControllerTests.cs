using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Controllers.Forum.ForumProfile;
using PortfolioApi.DataAccess.Forum;
using PortfolioApi.Entities.Forum;

namespace PortfolioTests.Controllers
{
    [TestFixture]
    public class Tests
    {
        private ForumProfileController _controller;
        private Mock<IForumRepository> _mockForumRepository;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _mockForumRepository = new Mock<IForumRepository>();
            _mapper = new Mock<IMapper>();
            _controller = new ForumProfileController(_mockForumRepository.Object, _mapper.Object);
        }

        [Test]
        public void GetForumProfile_WithoutInterest_ReturnsOkIActionResult()
        {
            // Arrange
            var forumProfileId = 1;
            var isInterestsListIncluded = false;
            var forumProfile = new ForumProfile("mockDisplayName") { ForumProfileId = forumProfileId};
            _mockForumRepository.Setup(service => service.GetForumProfileAsync(forumProfileId, isInterestsListIncluded)).ReturnsAsync(forumProfile);
            
            // Act
            var result = _controller.GetAllForumProfiles();

            // Assert
            Assert.IsInstanceOf<Task<IActionResult>>(result);

        }
    }
}