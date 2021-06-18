using Cognizant.DAL.Dto;
using Cognizant.DAL.Repositories.Abstracts;
using Cognizant.Infrastructure.Shared.Requests.Queries;
using Cognizant.Infrastructure.Shared.Responses;
using Cognizant.Infrastructure.Shared.Responses.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cognizant.Infrastructure.Shared.RequestHandlers.QueryHandlers
{
    public class GetGameStatsTopNQueryHandler : IRequestHandler<GetGameStatsTopNQuery, IResponse<IEnumerable<GameStatsTopNDTO>>>
    {
        private readonly IGameStatsRepository _gameStatsRepository;

        public GetGameStatsTopNQueryHandler(IGameStatsRepository gameStatsRepository)
        {
            _gameStatsRepository = gameStatsRepository;
        }

        public async Task<IResponse<IEnumerable<GameStatsTopNDTO>>> Handle(GetGameStatsTopNQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _gameStatsRepository.GetTopN(request.TopN);
                return Response<IEnumerable<GameStatsTopNDTO>>.CreateSuccess(result);
            }
            catch (Exception ex)
            {
                return Response<IEnumerable<GameStatsTopNDTO>>.CreateFail(ex.GetBaseException().Message);
            }
        }
    }
}
