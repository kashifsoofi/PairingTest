using System.Web.Http;
using QuestionServiceWebApi.Interfaces;

namespace QuestionServiceWebApi.Controllers
{
    public class QuestionsController : ApiController
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMarkingService _markingService;

        public QuestionsController(IQuestionRepository questionRepository, IMarkingService markingService)
        {
            _questionRepository = questionRepository;
            _markingService = markingService;
        }

        public QuestionsController() : this(new QuestionRepository(), new MarkingService())
        {
        }

        // GET api/questions
        public Questionnaire Get()
        {
            return _questionRepository.GetQuestionnaire();
        }

        // GET api/questions/5
        public string Get(int id)
        {
            return "";
        }

        // POST api/questions
        public double Post([FromBody] dynamic questionnaireWithAnswers)
        {
            var questionnaire = questionnaireWithAnswers.Questionnaire.ToObject<Questionnaire>();
            var selectedAnswers = questionnaireWithAnswers.SelectedAnswers.ToObject<int[]>();
            return _markingService.MarkQuestionnaire(questionnaire, selectedAnswers);
        }

        // PUT api/questions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/questions/5
        public void Delete(int id)
        {
        }
    }
}
