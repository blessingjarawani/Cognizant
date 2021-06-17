using Cognizant.BLL.Entities.Validators;
using Cognizant.BLL.Results;

namespace Cognizant.BLL.Entities
{
    public class ResultsValidatorEntity : ValidateExecutor
    {
        private ResponseEntity _response;
        private string _expectedOutput;

        public ResultsValidatorEntity(ResponseEntity response, string expectedOutput)
        {
            _response = response;
            _expectedOutput = expectedOutput;
            AddValidations();

        }
        private void AddValidations()
        {
            AddFunction(() => CheckIfExecuted());
            AddFunction(() => CheckIfOutPutCorrect());
        }

        private ExecuteResult CheckIfOutPutCorrect() =>
           CreateResult(_response.Output?.Replace(" ", "") != _expectedOutput.Replace(" ", ""), $"Invalid OutPut Expected {_expectedOutput} Returned {_response.Output}");
        private ExecuteResult CheckIfExecuted() =>
          CreateResult(string.IsNullOrWhiteSpace(_response.Memory) && string.IsNullOrWhiteSpace(_response.CpuTime), $"Programming has Errors :  {_response.Output}");
    }
}
