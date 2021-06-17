using Cognizant.Infrastructure.Shared.Responses.Abstracts;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Infrastructure.Shared.Requests.Commands
{
    public class CompileCommand : BaseExecuteCommandRequest, IRequest<IBaseResponse>
    {
        public int TaskId { get; set; }
        public string PlayerName { get; set; }

    }
}