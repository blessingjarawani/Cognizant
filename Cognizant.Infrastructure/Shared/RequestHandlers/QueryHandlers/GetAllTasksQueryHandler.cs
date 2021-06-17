using Cognizant.DAL.Dto;
using Cognizant.DAL.Repositories.Abstracts;
using Cognizant.Infrastructure.Shared.Requests.Queries;
using Cognizant.Infrastructure.Shared.Responses;
using Cognizant.Infrastructure.Shared.Responses.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cognizant.Infrastructure.Shared.RequestHandlers.QueryHandlers
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetTasksQuery, IResponse<IEnumerable<TasksDTO>>>
    {
        private readonly ITasksRepository _tasksRepository;
        public GetAllTasksQueryHandler(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public async Task<IResponse<IEnumerable<TasksDTO>>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _tasksRepository.GetAllTasks();
                return Response<IEnumerable<TasksDTO>>.CreateSuccess(result);
            }
            catch (Exception ex)
            {

                return Response<IEnumerable<TasksDTO>>.CreateFail(ex.GetBaseException().Message);
            }
        }
    }
}
