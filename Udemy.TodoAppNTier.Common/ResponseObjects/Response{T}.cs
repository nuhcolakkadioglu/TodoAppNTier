using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.TodoAppNTier.Common.ResponseObjects
{
    public class Response<T> : Response, IResponse<T>
    {
        public Response(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }
        public Response(ResponseType responseType, string message) : base(responseType, message)
        {

        }

        public Response(ResponseType responseType, T data, List<CustomValidationError> customValidationErrors) : base(responseType)
        {
            ValidationErrors = customValidationErrors;
            Data = data;
        }

        public T Data { get; set; }
        public List<CustomValidationError> ValidationErrors { get; set; }
    }
}
