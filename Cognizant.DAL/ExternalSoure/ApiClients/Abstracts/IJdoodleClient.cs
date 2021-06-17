using Cognizant.BLL.Entities;
using Cognizant.BLL.Results;
using Cognizant.Infrastructure.Shared.Requests.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.DAL.ExternalSoure.ApiClients.Abstracts
{
    public interface IJdoodleClient
    {
        Task<ExecuteResult<ResponseEntity>> Compile(IBaseExecuteCommandRequest baseExecuteCommandRequest);
    }
}
