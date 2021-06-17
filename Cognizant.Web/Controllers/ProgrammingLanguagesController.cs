using Cognizant.DAL.Dto;
using Cognizant.Infrastructure.Shared.Requests.Queries;
using Cognizant.Infrastructure.Shared.Responses.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cognizant.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProgrammingLanguagesController(IMediator mediator) => _mediator = mediator;

        [HttpPost("[action]")]

        public async Task<IResponse<IEnumerable<ProgrammingLanguagesDTO>>> GetProgrammingLanguages([FromBody] GetProgrammingLanguagesQuery query)
            => await _mediator.Send(query);
        
    }
}
