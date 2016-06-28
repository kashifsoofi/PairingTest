using NUnit.Framework;
using PairingTest.Unit.Tests.QuestionServiceWebApi.Stubs;
using QuestionServiceWebApi;
using QuestionServiceWebApi.Controllers;
using System.Collections.Generic;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi
{
    [TestFixture]
    public class QuestionsControllerTests
    {
        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var expectedTitle = "My expected questions";
            var expectedQuestions = new Questionnaire() {
                QuestionnaireTitle = expectedTitle,
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
                }
            };
            var fakeQuestionRepository = new FakeQuestionRepository() {ExpectedQuestions = expectedQuestions};
            var questionsController = new QuestionsController(fakeQuestionRepository);

            //Act
            var questions = questionsController.Get();

            //Assert
            Assert.That(questions.QuestionnaireTitle, Is.EqualTo(expectedTitle));
            Assert.That(questions.QuestionsText[0], Is.EqualTo(expectedQuestions.QuestionsText[0]));
            Assert.That(questions.QuestionsText[1], Is.EqualTo(expectedQuestions.QuestionsText[1]));
            Assert.That(questions.QuestionsText[2], Is.EqualTo(expectedQuestions.QuestionsText[2]));
            Assert.That(questions.QuestionsText[3], Is.EqualTo(expectedQuestions.QuestionsText[3]));
        }

        [Test]
        public void ShouldGetAnswer()
        {
            //Arrange
            var expectedTitle = "My expected questions";
            var expectedQuestions = new Questionnaire()
            {
                QuestionnaireTitle = expectedTitle,
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
                }
            };
            var fakeQuestionRepository = new FakeQuestionRepository() { ExpectedQuestions = expectedQuestions };
            var questionsController = new QuestionsController(fakeQuestionRepository);

            //Act
            var questions = questionsController.Get();

            //Assert
            Assert.That(questions.QuestionnaireTitle, Is.EqualTo(expectedTitle));
            Assert.That(questions.AnswersText[0], Is.EqualTo(expectedQuestions.AnswersText[0]));
            Assert.That(questions.AnswersText[1], Is.EqualTo(expectedQuestions.AnswersText[1]));
            Assert.That(questions.AnswersText[2], Is.EqualTo(expectedQuestions.AnswersText[2]));
            Assert.That(questions.AnswersText[3], Is.EqualTo(expectedQuestions.AnswersText[3]));
        }
    }
}