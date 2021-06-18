using Cognizant.DAL.Dto;
using Cognizant.Infrastructure.Shared.Requests.Queries;
using Cognizant.Infrastructure.Shared.Responses.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cognizant.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameStatsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public GameStatsController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost("[action]")]
        public async Task<IResponse<IEnumerable<GameStatsTopNDTO>>> GetTopNPlayers([FromBody] GetGameStatsTopNQuery query)
        {
            int.TryParse(_configuration.GetSection("Props:TopNResult").Value, out var topN);
            query.TopN = topN;
            return await _mediator.Send(query);
        }
    }
}
