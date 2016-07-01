using Moq;
using NUnit.Framework;
using PairingTest.Unit.Tests.QuestionServiceWebApi.Stubs;
using QuestionServiceWebApi;
using QuestionServiceWebApi.Controllers;
using QuestionServiceWebApi.Interfaces;
using System.Collections.Generic;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi
{
    [TestFixture]
    public class QuestionsControllerTests
    {
        private readonly string _expectedTitle = "My expected questions";
        private readonly FakeQuestionRepository _fakeQuestionRepository = new FakeQuestionRepository();

        [SetUp]
        public void SetUp()
        {
            _fakeQuestionRepository.ExpectedQuestions = new Questionnaire()
            {
                QuestionnaireTitle = _expectedTitle,
                QuestionsText = new List<string>
                {
                    "Question1?",
                    "Question2?",
                    "Question3?",
                    "Question4?"
                },
                AnswersText = new List<string>
                {
                    "Answer4",
                    "Answer3",
                    "Answer2",
                    "Answer1"
                },
                CorrectAnswers = new int[] { 3, 2, 1, 0 }
            };
        }

        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var questionsController = new QuestionsController(_fakeQuestionRepository, null);

            //Act
            var questions = questionsController.Get();

            //Assert
            Assert.That(questions.QuestionnaireTitle, Is.EqualTo(_expectedTitle));
            Assert.That(questions.QuestionsText[0], Is.EqualTo(_fakeQuestionRepository.ExpectedQuestions.QuestionsText[0]));
            Assert.That(questions.QuestionsText[1], Is.EqualTo(_fakeQuestionRepository.ExpectedQuestions.QuestionsText[1]));
            Assert.That(questions.QuestionsText[2], Is.EqualTo(_fakeQuestionRepository.ExpectedQuestions.QuestionsText[2]));
            Assert.That(questions.QuestionsText[3], Is.EqualTo(_fakeQuestionRepository.ExpectedQuestions.QuestionsText[3]));
        }

        [Test]
        public void ShouldGetAnswer()
        {
            //Arrange
            var questionsController = new QuestionsController(_fakeQuestionRepository, null);

            //Act
            var questions = questionsController.Get();

            //Assert
            Assert.That(questions.QuestionnaireTitle, Is.EqualTo(_expectedTitle));
            Assert.That(questions.AnswersText[0], Is.EqualTo(_fakeQuestionRepository.ExpectedQuestions.AnswersText[0]));
            Assert.That(questions.AnswersText[1], Is.EqualTo(_fakeQuestionRepository.ExpectedQuestions.AnswersText[1]));
            Assert.That(questions.AnswersText[2], Is.EqualTo(_fakeQuestionRepository.ExpectedQuestions.AnswersText[2]));
            Assert.That(questions.AnswersText[3], Is.EqualTo(_fakeQuestionRepository.ExpectedQuestions.AnswersText[3]));
        }

        [TestCase(new int[] { 0, 0, 0, 0 }, 25.0f)]
        [Test]
        public void ShouldReturnPercentage(int[] selectedAnswers, double expectedPercentage)
        {
            // Arrange
            Mock<IMarkingService> mockMarkingService = new Mock<IMarkingService>();
            mockMarkingService.Setup(t => t.MarkQuestionnaire(_fakeQuestionRepository.ExpectedQuestions, selectedAnswers)).Returns(expectedPercentage);

            var questionsController = new QuestionsController(null, mockMarkingService.Object);

            // Act
            var percentage = questionsController.Post(_fakeQuestionRepository.ExpectedQuestions, selectedAnswers);

            // Assert
            mockMarkingService.Verify(t => t.MarkQuestionnaire(_fakeQuestionRepository.ExpectedQuestions, selectedAnswers), Times.Once);
            Assert.That(percentage, Is.EqualTo(expectedPercentage));
        }
    }
}