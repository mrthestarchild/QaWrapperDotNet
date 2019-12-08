using System.Web.Http;
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
        public QuestionAnswerModel GetAnswer(string question)
        {
            return _controller.GetAnswerFromQuestion(question);
        }

        [Route("TrainAnswer")]
        public ExternalHumanTrainingResponseModel TrainAnswer(ExternalHumanTrainingModel model)
        {
            return _controller.DoExternalHumanTraining(model);
        }
    }
}