using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Osb.Core.Api.Factory.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

public class OutputMiddleware 
{
    private readonly RequestDelegate _next;
    private readonly IOutputRepositoryFactory _outputRepositoryFactory;
    public OutputMiddleware(RequestDelegate next, IOutputRepositoryFactory outputRepositoryFactory)
    {
        _next = next;
        _outputRepositoryFactory = outputRepositoryFactory;
    }

    public async Task Invoke(HttpContext context)
    {
        var result = string.Empty;
        
        try
        {
            using(var memoryStream = new MemoryStream())
            {
                var originalBody = context.Response.Body;
                context.Response.Body = memoryStream;

                await _next.Invoke(context);

                memoryStream.Seek(0, SeekOrigin.Begin);
                result = new StreamReader(memoryStream).ReadToEnd();
                memoryStream.Seek(0, SeekOrigin.Begin);
                
                await memoryStream.CopyToAsync(originalBody);
                context.Response.Body = originalBody;
            }
            
        }
        catch (Exception ex)
        {
           result = ex.Message;
        }
        finally
        {
            _outputRepositoryFactory.Create().InsertOutputLog(result);
        }
    }

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context) { }

}


