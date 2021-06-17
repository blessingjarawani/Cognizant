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
    public class GetProgrammingLanguagesQueryHandler : IRequestHandler<GetProgrammingLanguagesQuery, IResponse<IEnumerable<ProgrammingLanguagesDTO>>>
    {
        private readonly IProgrammingLanguagesRepository _repo;

        public GetProgrammingLanguagesQueryHandler(IProgrammingLanguagesRepository repo)
        {
            _repo = repo;
        }

        public async Task<IResponse<IEnumerable<ProgrammingLanguagesDTO>>> Handle(GetProgrammingLanguagesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repo.GetAll();
                return Response<IEnumerable<ProgrammingLanguagesDTO>>.CreateSuccess(result);
            }
            catch (Exception ex)
            {

                return Response<IEnumerable<ProgrammingLanguagesDTO>>.CreateFail(ex.GetBaseException().Message);
            }
        }
    }
}
