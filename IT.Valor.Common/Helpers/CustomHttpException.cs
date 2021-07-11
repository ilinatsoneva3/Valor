using System;
using System.Net;
using System.Net.Http;

namespace IT.Valor.Common.Helpers
{
    public class CustomHttpException : HttpRequestException
    {
        public HttpStatusCode HttpCode { get; }

        public CustomHttpException(HttpStatusCode code) : this(code, null, null)
        {
        }

        public CustomHttpException(HttpStatusCode code, string message) : this(code, message, null)
        {
        }

        public CustomHttpException(HttpStatusCode code, string message, Exception innerEx)
            : base(message, innerEx)
        {
            HttpCode = code;
        }
    }
}
