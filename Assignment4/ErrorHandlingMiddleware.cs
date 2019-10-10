
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assignment3
{

public class ErrorHandlingMiddleware
{
    public HttpStatusCode StatusCode { get; set; }
    public string ContentType { get; set; } = @"text/plain";

    

    private readonly RequestDelegate next;
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context /* other dependencies */)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    public async Task <string> errorString(){
            string virhe = "Player level lower than three";
            return virhe;

        }

    public static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError; // 500 if unexpected
        
        if      (ex is MyNotFoundException)     code = HttpStatusCode.NotFound;
        else if (ex is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
        else if (ex is MyException)             code = HttpStatusCode.BadRequest;

        var result = JsonConvert.SerializeObject(new { error = ex.Message });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }


    public class MyException
    {

        

    }

    public class MyNotFoundException
    {
        public async Task<HttpStatusCode> NFE()
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            code = HttpStatusCode.NotFound;
            return code;

        }
    }

    internal class MyUnauthorizedException
    {
    }

    

    public class HttpStatusCodeException : Exception
{
    public HttpStatusCode StatusCode { get; set; }
    public string ContentType { get; set; } = @"text/plain";

    public HttpStatusCodeException(HttpStatusCode statusCode)
    {
        this.StatusCode = statusCode;
    }

    public HttpStatusCodeException(HttpStatusCode statusCode, string message) : base(message)
    {
        this.StatusCode = statusCode;
    }

    public HttpStatusCodeException(HttpStatusCode statusCode, Exception inner) : this(statusCode, inner.ToString()) { }

    public HttpStatusCodeException(HttpStatusCode statusCode, JObject errorObject) : this(statusCode, errorObject.ToString())
    {
        this.ContentType = @"application/json";
    }

}

    
}
}