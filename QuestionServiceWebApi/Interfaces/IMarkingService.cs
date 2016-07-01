using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionServiceWebApi.Interfaces
{
    public interface IMarkingService
    {
        double MarkQuestionnaire(Questionnaire questionnaire, int[] selectedAnswers);
    }
}
