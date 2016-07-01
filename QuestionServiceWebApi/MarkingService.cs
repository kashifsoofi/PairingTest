using QuestionServiceWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionServiceWebApi
{
    public class MarkingService : IMarkingService
    {
        public double MarkQuestionnaire(Questionnaire questionnaire, int[] selectedAnswers)
        {
            var correctAnswersCount = 0;
            for (int i = 0; i < questionnaire.QuestionsText.Count; i++)
            {
                if (selectedAnswers[i] == questionnaire.CorrectAnswers[i])
                    correctAnswersCount++;
            }
            return (double)correctAnswersCount / questionnaire.QuestionsText.Count * 100;
        }
    }
}