using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using niac.Models.Answers;
using niac.ViewModel;
using System.Net.Http;

namespace niac.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IHttpClientFactory _HttpClientFactory;

        public QuestionController(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            QuestionViewModel model = new QuestionViewModel();

            var client = _HttpClientFactory.CreateClient("NiacClient");

            var response = client.GetAsync("questions_json.ashx?m=GetQuestionDetails&documentId=" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                using (HttpContent content = response.Content)
                {
                    var result = content.ReadAsStringAsync();

                    AnswerRoot r = JsonConvert.DeserializeObject<AnswerRoot>(result.Result);

                    model.AnswerPlainText = r.QuestionsList != null ? r.QuestionsList.Question.AnswerPlainText : string.Empty;
                    model.QuestionText = r.QuestionsList.Question.QuestionText;
                }
            }

            return View(model);
        }
    }
}
