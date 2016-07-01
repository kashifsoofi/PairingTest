using System.Web.Mvc;
using PairingTest.Web.Models;
using PairingTest.Web.Services;
using System.Threading.Tasks;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly IQuestionnaireService _questionnaireService;
        private readonly IMarkingService _markingService;

        public QuestionnaireController(IQuestionnaireService questionnaireService, IMarkingService markingService)
        {
            _questionnaireService = questionnaireService;
            _markingService = markingService;
        }

        /* ASYNC ACTION METHOD... IF REQUIRED... */
        public async Task<ViewResult> Index()
        {
            var viewModel = await _questionnaireService.GetAsync();
            return View(viewModel);
        }

        //public ViewResult Index()
        //{
        //    return View(new QuestionnaireViewModel());
        //}

        [HttpPost]
        public async Task<ViewResult> Submit(int[] selectedAnswers)
        {
            var questionnaire = await _questionnaireService.GetQuestionnaire();
            var percentage = await _markingService.MarkQuestionnaire(questionnaire, selectedAnswers);
            ViewData["Percentage"] = percentage;
            return View();
        }
    }
}
