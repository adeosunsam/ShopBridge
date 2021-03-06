using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShopBridge_dtos;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ShopBridge_api.GlobalErrorMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception error)
            {

                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = Response<string>.Fail(error.Message);
                switch (error)
                {
                    case UnauthorizedAccessException e:
                        _logger.LogError(e, e.StackTrace, e.Source, e.ToString());
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        responseModel.Message = e.Message;
                        break;
                    case ArgumentOutOfRangeException e:
                        _logger.LogError(e, e.StackTrace, e.Source, e.ToString());
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Message = e.Message;
                        break;
                    case ArgumentNullException e:
                        _logger.LogError(e, e.StackTrace, e.Source, e.ToString());
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Message = e.Message;
                        break;
                    default:
                        // unhandled error
                        _logger.LogError(error, error.Source, error.InnerException, error.Message, error.ToString());
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.Message = "Internal Server Error. Please Try Again Later.";
                        break;
                }
                var result = JsonConvert.SerializeObject(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
