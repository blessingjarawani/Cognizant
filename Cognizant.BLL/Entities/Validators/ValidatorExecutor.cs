﻿using Cognizant.BLL.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.BLL.Entities.Validators
{
    public abstract class ValidateExecutor
    {
        private List<Func<ExecuteResult>> _functions;

        protected ValidateExecutor()
        {
            _functions = new List<Func<ExecuteResult>>();
        }

        public ExecuteResult Execute()
        {
            foreach (var func in _functions)
            {
                var funcResult = func.Invoke();
                if (!funcResult.IsSuccess) return funcResult;
            }
            return ExecuteResult.Success();
        }

        protected void AddFunction(Func<ExecuteResult> function)
        {
            _functions.Add(() => function());
        }

        protected ExecuteResult CreateResult(bool notValid, string errorMessage) => notValid ? ExecuteResult.Fail(errorMessage) : ExecuteResult.Success();

        protected ExecuteResult CreateResultIfEdited(bool notValid, bool edited, string errorMessage) => (notValid && edited) ? ExecuteResult.Fail(errorMessage) : ExecuteResult.Success();
    }
}


