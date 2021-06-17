﻿using Cognizant.Infrastructure.Shared.Responses.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Infrastructure.Shared.Responses
{
    public class BaseResponse : IBaseResponse
    {
        public bool IsSuccess { get; }

        public string Message { get; }

        protected BaseResponse(bool isSuccess, string message = null)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        public static BaseResponse CreateSuccess() => new BaseResponse(true);
        public static BaseResponse CreateFail(string message) => new BaseResponse(false, message);
    }
}
