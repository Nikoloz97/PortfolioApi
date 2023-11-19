using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Controllers.Forum.ForumProfile;
using PortfolioApi.DataAccess.Forum;
using PortfolioApi.Models.Forum.ForumProfile;
using PortfolioApi.Services.Forum;

namespace PortfolioTests.Controllers
{
    [TestFixture]
    public class Tests
    {
        private ForumProfileController _forumController;
        private Mock<IForumProfileService> _mockForumService;
        private Mock<IForumRepository> _mockForumRepository;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _mockForumRepository = new Mock<IForumRepository>();
            _mapper = new Mock<IMapper>();
            _mockForumService = new Mock<IForumProfileService>();
            _forumController = new ForumProfileController(_mockForumService.Object);
        }

        [Test]
        public void GetForumProfile_Returns_OkTaskIActionResult()
        {
            // Arrange
            var forumProfileId = 1;
            var forumProfileDto = new ForumProfileDto();

            _mockForumService.Setup(service => service.GetForumProfileAsync(forumProfileId)).ReturnsAsync(forumProfileDto);
            
            // Act
            var result = _forumController.GetForumProfile(forumProfileId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Task<IActionResult>>(result);
        }
    }
}