using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Domain.Services.Communication
{
    public abstract class BaseResponce
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        public BaseResponce(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
