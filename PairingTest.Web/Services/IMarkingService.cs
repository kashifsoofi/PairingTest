using QuestionServiceWebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.Web.Services
{
    public interface IMarkingService
    {
        Task<double> MarkQuestionnaire(Questionnaire questionnaire, int[] selectedAnswers);
    }
}
