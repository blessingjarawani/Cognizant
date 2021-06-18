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

        private ExecuteResult CheckIfOutPutCorrect()
        {
            var expected = _response.Output?.Replace("\n", "").Replace("\r", "").Replace(" ", "");
            var result = _expectedOutput.Replace("\n", "").Replace("\r", "").Replace(" ", "");
            return CreateResult(expected != result, $"Invalid OutPut Expected {expected} Returned {result}");
        }

        private ExecuteResult CheckIfExecuted() =>
          CreateResult(string.IsNullOrWhiteSpace(_response.Memory) && string.IsNullOrWhiteSpace(_response.CpuTime), $"Programming has Errors :  {_response.Output}");
    }
}
