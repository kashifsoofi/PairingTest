using System.Web.Mvc;
using PairingTest.Web.Models;
using PairingTest.Web.Services;
using System.Threading.Tasks;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly IQuestionnaireService _questionnaireService;
        public QuestionnaireController(IQuestionnaireService questionnaireService)
        {
            _questionnaireService = questionnaireService;
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
    }
}
