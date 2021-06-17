using Cognizant.BLL.Entities;
using Cognizant.DAL.ExternalSoure.ApiClients.Abstracts;
using Cognizant.DAL.Repositories.Abstracts;
using Cognizant.Infrastructure.Shared.Requests.Commands;
using Cognizant.Infrastructure.Shared.Responses;
using Cognizant.Infrastructure.Shared.Responses.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cognizant.Infrastructure.Shared.RequestHandlers.CommandHandlers
{
    public class CompileCommandHandler : IRequestHandler<CompileCommand, IBaseResponse>
    {
        private readonly IJdoodleClient _jdoodleClient;
        private readonly ITasksRepository _taskRepository;

        public CompileCommandHandler(IJdoodleClient jdoodleClient, ITasksRepository taskRepository)
        {
            _jdoodleClient = jdoodleClient;
            _taskRepository = taskRepository;
        }

        public async Task<IBaseResponse> Handle(CompileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var task = await _taskRepository.GetTaskById(request.TaskId);
                if (task == null)
                    return BaseResponse.CreateFail("Selected Task does not exists");
                var compilationResult = await _jdoodleClient.Compile(request);
                if (!compilationResult.IsSuccess)
                    return BaseResponse.CreateFail(compilationResult.Message);
                var executionValidator = new ResultsValidatorEntity(compilationResult.Result,task.ExpectedResult);
                var executionResult = executionValidator.Execute();
                if (!executionResult.IsSuccess)
                    return BaseResponse.CreateFail(executionResult.Message);
                return BaseResponse.CreateSuccess();
            }
            catch (Exception ex)
            {
                return BaseResponse.CreateFail(ex.GetBaseException().Message);
            }
        }
    }
}
