using System;

namespace HomeWork.Helpers
{
    public class BusinessException : Exception
    {
        public BusinessException(string message)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}