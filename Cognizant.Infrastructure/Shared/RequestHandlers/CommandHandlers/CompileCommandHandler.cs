using Cognizant.BLL.Entities;
using Cognizant.DAL.Dto;
using Cognizant.DAL.ExternalSoure.ApiClients.Abstracts;
using Cognizant.DAL.Repositories.Abstracts;
using Cognizant.Infrastructure.Shared.Requests.Commands;
using Cognizant.Infrastructure.Shared.Responses;
using Cognizant.Infrastructure.Shared.Responses.Abstracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cognizant.Infrastructure.Shared.RequestHandlers.CommandHandlers
{
    public class CompileCommandHandler : IRequestHandler<CompileCommand, IBaseResponse>
    {
        private readonly IJdoodleClient _jdoodleClient;
        private readonly ITasksRepository _taskRepository;
        private readonly IGameStatsRepository _gameStatsRepository;

        public CompileCommandHandler(IJdoodleClient jdoodleClient, ITasksRepository taskRepository, IGameStatsRepository gameStatsRepository)
        {
            _jdoodleClient = jdoodleClient;
            _taskRepository = taskRepository;
            _gameStatsRepository = gameStatsRepository;
        }

        public async Task<IBaseResponse> Handle(CompileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var task = await _taskRepository.GetTaskById(request.TaskId);
                if (task == null)
                    return BaseResponse.CreateFail("Selected Task does not exists");
                var taskLastSuccesDate = await _gameStatsRepository.GetTaskLastSuccessDate(request.PlayerName, task.Id);
                if (!string.IsNullOrWhiteSpace(taskLastSuccesDate))
                    return BaseResponse.CreateFail($"You have already done the Task on {taskLastSuccesDate}");
                request.Stdin = task.InputParameter;
                var compilationResult = await _jdoodleClient.Compile(request);
                if (!compilationResult.IsSuccess)
                    return BaseResponse.CreateFail(compilationResult.Message);
                var executionValidator = new ResultsValidatorEntity(compilationResult.Result, task.ExpectedOutput);
                var executionResult = executionValidator.Execute();
                var taskResult = new TaskResultDTO(task.Id, request.PlayerName, executionResult.IsSuccess);
                await _gameStatsRepository.SaveChanges(taskResult);
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
