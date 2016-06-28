using NUnit.Framework;
using QuestionServiceWebApi;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi
{
    [TestFixture]
    public class QuestionRepositoryTests
    {
        [Test]
        public void ShouldGetExpectedQuestionnaire()
        {
            var questionRepository = new QuestionRepository();

            var questionnaire = questionRepository.GetQuestionnaire();

            Assert.That(questionnaire.QuestionnaireTitle, Is.EqualTo("Geography Questions"));
            Assert.That(questionnaire.QuestionsText[0], Is.EqualTo("What is the capital of Cuba?"));
            Assert.That(questionnaire.QuestionsText[1], Is.EqualTo("What is the capital of France?"));
            Assert.That(questionnaire.QuestionsText[2], Is.EqualTo("What is the capital of Poland?"));
            Assert.That(questionnaire.QuestionsText[3], Is.EqualTo("What is the capital of Germany?"));

            Assert.That(questionnaire.AnswersText[0], Is.EqualTo("Berlin"));
            Assert.That(questionnaire.AnswersText[1], Is.EqualTo("Warsaw"));
            Assert.That(questionnaire.AnswersText[2], Is.EqualTo("Paris"));
            Assert.That(questionnaire.AnswersText[3], Is.EqualTo("Havana"));
        }
    }
}