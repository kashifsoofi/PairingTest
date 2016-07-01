using NUnit.Framework;
using QuestionServiceWebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi
{
    [TestFixture]
    public class MarkingServiceTests
    {
        [TestCase(new int[] { 0, 1, 2, 3 }, new int[] { 0, 0, 0, 0 }, 25.0f)]
        [Test]
        public void ShouldReturnPercentage(int[] correctAnswers, int[] selectedAnswers, double expectedPercentage)
        {
            var questionnaire = new Questionnaire()
            {
                QuestionsText = new List<string>
                {
                    "Question1?",
                    "Question2?",
                    "Question3?",
                    "Question4?"
                },
                CorrectAnswers = correctAnswers
            };

            var markingService = new MarkingService();

            // Act
            var percentage = markingService.MarkQuestionnaire(questionnaire, selectedAnswers);

            // Assert
            Assert.That(percentage, Is.EqualTo(expectedPercentage));
        }
    }
}
