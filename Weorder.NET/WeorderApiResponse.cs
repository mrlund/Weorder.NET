using System;
using System.Collections.Generic;
using System.Text;
using Weorder.NET.Entities;

namespace Weorder.NET
{

    public class WeorderApiResponse<T> where T : class
    {
        private ErrorResponse _errorResponse { get; set; }

        public bool IsSuccessStatusCode { get; set; }
        public T Result { get; set; }

        public WeorderApiResponse()
        {
            IsSuccessStatusCode = false;
        }

        public WeorderApiResponse(ErrorResponse error)
        {
            IsSuccessStatusCode = false;
            _errorResponse = error;
        }

        public WeorderApiResponse(T source)
        {
            Result = source;
            IsSuccessStatusCode = true;
        }

        public ErrorResponse GetError()
        {
            return _errorResponse;
        }


    }
}
