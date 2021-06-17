using Cognizant.Infrastructure.Shared.Requests.Commands;
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
    public class CompilerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;

        public CompilerController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _config = configuration;
        }
      


        [HttpPost("[action]")]

        public async Task<IBaseResponse> Compile([FromBody] CompileCommand command)
        {
            var clientId = _config.GetSection("JdoodleApi:clientId").Value;
            var clientSecret = _config.GetSection("JdoodleApi:clientSecret").Value;
            var executeUrl = _config.GetSection("JdoodleApi:executeUrl").Value;
            command.SetParameters(clientId, clientSecret, executeUrl);
            return await _mediator.Send(command);
        }
            
    }
}
