namespace Common
{
    using System;
    using System.Net;

    public class CustomException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; private set; }

        public string NamespaceClass { get; private set; }

        public string Method { get; private set; }

        public CustomException(string message, HttpStatusCode httpStatusCode, string namespaceClass, string method) : base(message)
        {
            HttpStatusCode = httpStatusCode;
            NamespaceClass = namespaceClass;
            Method = method;
        }

        public static string CustomError(Exception ex)
        {
            string error = "";
            if (ex.InnerException != null)
                error = ex.InnerException.Message;
            else
                error = ex.Message;

            return error;
        }
    }
}
