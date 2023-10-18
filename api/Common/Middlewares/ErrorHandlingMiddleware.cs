using System.Net;
using Newtonsoft.Json;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context) 
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {

        int statusCode;

        if (ex.GetType().GetProperty("StatusCode") != null)
            statusCode = (int) ex.GetType().GetProperty("StatusCode").GetValue(ex, null);
        else
            statusCode = (int) HttpStatusCode.InternalServerError;

        context.Response.ContentType = "application/json";
        context.Response.StatusCode =  statusCode;
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var isDevelopment = environment == Environments.Development;
        
        if( isDevelopment )

            await context.Response.WriteAsync(
                new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = ex.Message != null ? ex.Message : "Internal Server Error.",
                    StackTrace = ex.StackTrace
                }.ToString()
            );
        else
            await context.Response.WriteAsync(
                new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = ex.Message != null ? ex.Message : "Internal Server Error."
                }.ToString()
            );
    }
}

internal class ErrorDetails
{
    public ErrorDetails()
    {
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string StackTrace { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }

    
}