using Moq;
using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Models;
using PairingTest.Web.Services;
using QuestionServiceWebApi;
using System.Collections.Generic;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        [Test]
        public async void ShouldGetQuestionnaire()
        {
            //Arrange
            var expectedTitle = "My expected quesitons";
            Mock<IQuestionnaireService> mockQuestionnaireService = new Mock<IQuestionnaireService>();
            var questionnaire = new QuestionnaireViewModel
            {
                QuestionnaireTitle = expectedTitle
            };
            mockQuestionnaireService.Setup(t => t.GetAsync()).ReturnsAsync(questionnaire);

            var questionnaireController = new QuestionnaireController(mockQuestionnaireService.Object);

            //Act
            var viewResult = await questionnaireController.Index();
            var result = (QuestionnaireViewModel) viewResult.ViewData.Model;
            
            //Assert
            Assert.That(result.QuestionnaireTitle, Is.EqualTo(expectedTitle));
        }
    }
}