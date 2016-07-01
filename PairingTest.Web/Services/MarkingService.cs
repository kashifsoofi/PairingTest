using QuestionServiceWebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PairingTest.Web.Services
{
    public class MarkingService : IMarkingService
    {
        private readonly IPostApiClient _postApiClient;

        public MarkingService(IPostApiClient postApiClient)
        {
            _postApiClient = postApiClient;
        }

        public async Task<double> MarkQuestionnaire(Questionnaire questionnaire, int[] selectedAnswers)
        {
            return await _postApiClient.Post<double>("/api/Questions", new { Questionnaire = questionnaire, SelectedAnswers = selectedAnswers });
        }
    }
}