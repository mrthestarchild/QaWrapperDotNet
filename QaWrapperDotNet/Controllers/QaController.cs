using System.Web.Http;
using System.Web.Http.Cors;
using QuestionAnswerAi.Controllers;
using QuestionAnswerAi.Models;

namespace QaWrapperDotNet.Controllers
{
    [Route("api")]
    public class QaController : ApiController
    {
        private static readonly string modelPath = System.Web.Hosting.HostingEnvironment.MapPath(@"~\Resources\Models\");
        private readonly QuestionAnswerController _controller = new QuestionAnswerController(modelPath);

        [Route("GetAnswer")]
        [HttpGet]
        public QuestionAnswerModel GetAnswer(string question)
        {
            return _controller.GetAnswerFromQuestion(question);
        }

        [Route("TrainAnswer")]
        [HttpPost]
        public ExternalHumanTrainingResponseModel TrainAnswer(ExternalHumanTrainingModel model)
        {
            return _controller.DoExternalHumanTraining(model);
        }
    }
}