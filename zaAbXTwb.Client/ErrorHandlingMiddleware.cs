﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace zaAbXTwb.Client
{
  /**
   * https://stackoverflow.com/questions/38630076/asp-net-core-web-api-exception-handling
   */
  public class ErrorHandlingMiddleware
  {
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

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
      var code = HttpStatusCode.InternalServerError; // 500 if unexpected

      if (exception is NotFoundException) code = HttpStatusCode.NotFound;
      else if (exception is NotAuthorizedException)
        code = HttpStatusCode.Unauthorized;
      else if (exception is BadRequestException)
        code = HttpStatusCode.BadRequest;

      var result = JsonConvert.SerializeObject(new { error = exception.Message });
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)code;
      return context.Response.WriteAsync(result);
    }
  }

  public class NotFoundException : Exception
  {
  public NotFoundException(string message) : base(message)
  {
  }
}

  public class NotAuthorizedException : Exception
  {
    public NotAuthorizedException(string message) : base(message)
    {
    }
  }

  public class BadRequestException : Exception
  {
    public BadRequestException(string message) : base(message)
    {
    }
  }

}