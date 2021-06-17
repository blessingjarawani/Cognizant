using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.BLL.Results
{
    public class ExecuteResult
    {
        public bool IsSuccess { get; protected set; }
        public string Message { get; protected set; }

        protected ExecuteResult() { }

        public static ExecuteResult Fail(string message) => new ExecuteResult { IsSuccess = false, Message = message };
        public static ExecuteResult Success() => new ExecuteResult { IsSuccess = true };
    }

    public class ExecuteResult<T> : ExecuteResult
    {
        public T Result { get; private set; }

        public static ExecuteResult<T> Fail(string message) => new ExecuteResult<T> { IsSuccess = false, Message = message };
        public static ExecuteResult<T> Success(T result) => new ExecuteResult<T> { IsSuccess = true, Result = result };
    }
}
