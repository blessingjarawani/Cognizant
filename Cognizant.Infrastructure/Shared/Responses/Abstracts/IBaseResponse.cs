using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Infrastructure.Shared.Responses.Abstracts
{
    public interface IBaseResponse
    {
        bool IsSuccess { get; }
        string Message { get; }
    }


}
