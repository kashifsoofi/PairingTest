using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PairingTest.Web.Models;

namespace PairingTest.Web.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly IGetApiClient _getApiClient;

        public QuestionnaireService(IGetApiClient getApiClient)
        {
            _getApiClient = getApiClient;
        }

        public async Task<QuestionnaireViewModel> GetAsync()
        {
            return await _getApiClient.Get<QuestionnaireViewModel>("/api/Questions");
        }
    }
}