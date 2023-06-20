using Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace bookstore.api.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate next;

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Obter o erro
            HttpStatusCode code = HttpStatusCode.InternalServerError;
            string errorMessage = exception.Message;

            if (exception is CustomException)
            {
                CustomException customException = (CustomException)exception;
                code = customException.HttpStatusCode;
            }

            if (exception is WebException)
            {
                WebException webException = (WebException)exception;

                string error = new StreamReader(webException.Response.GetResponseStream()).ReadToEnd();
                if (string.IsNullOrEmpty(error))
                {
                    errorMessage = webException.Message;
                }
                else
                {
                    errorMessage = "Erro aqo realizar ação. Por favor tente novamente.";

                    try
                    {
                        dynamic errorObject = JsonConvert.DeserializeObject(error);
                        errorMessage = errorObject.error;
                    }
                    catch { }
                }

                HttpWebResponse httpWebResponse = webException.Response as HttpWebResponse;
                code = httpWebResponse.StatusCode;
            }

            // Cria o response
            var result = JsonConvert.SerializeObject(new { message = errorMessage, error = errorMessage });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }

        public ErrorMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (WebException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
    }
}
