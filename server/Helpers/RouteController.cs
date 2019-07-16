/**
 * License: MIT
 * Author: Kevin Villanueva
 * Contact: https://github.com/rhaldkhein
 */

using System;
using server.Helpers.Errors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


namespace server.Helpers {
  public class RouteController : Controller {
    protected IServiceProvider ServiceProvider;
    protected IHostingEnvironment Env;
    private object defaultPayload = new object { };
    private string defaultTitle = "Internal Server Error";
    private string defaultMessage = "Oops! Something went wrong";

    public RouteController() { }

    public RouteController(IServiceProvider sp) {
      ServiceProvider = sp;
      Env = sp.GetRequiredService<IHostingEnvironment>();
    }

    private object StripPayload(object payload) {
      if (payload is Exception)
        return Env.IsProduction() ? defaultPayload : payload;
      return payload;
    }

    public object WrapSuccess(object payload, object meta, string code = "Ok") {
      return new {
        success = new { code = code },
        meta = meta,
        payload = payload
      };
    }

    public object WrapError(Error payload, string message = null) {
      return new {
        error = new {
          code = payload.GetType().Name,
          tag = payload.Tag,
          type = payload.Type,
          title = payload.Title,
          message = message ?? payload.Message
        },
        payload = StripPayload(payload.Payload ?? payload)
      };
    }

    public object WrapError(Exception payload, string message = null) {
      // #CHECK Make sure to strip out sensitive data on production
      return new {
        error = new {
          code = payload.GetType().Name,
          title = defaultTitle,
          message = Env.IsProduction() ? defaultMessage : message
        },
        payload = Env.IsProduction() ? defaultPayload : payload
      };
    }

    public OkObjectResult Success(string code = "Ok") {
      Response.Headers.Add("x-api-standard", "1");
      return new OkObjectResult(WrapSuccess(null, null, code));
    }

    public OkObjectResult Success(object payload, string code = "Ok") {
      Response.Headers.Add("x-api-standard", "1");
      return new OkObjectResult(WrapSuccess(payload, null, code));
    }

    public OkObjectResult Success(object payload, object meta, string code = "Ok") {
      Response.Headers.Add("x-api-standard", "1");
      return new OkObjectResult(WrapSuccess(payload, meta, code));
    }

    public ErrorObjectResult Error(Error payload, string message = null) {
      Response.Headers.Add("x-api-standard", "1");
      var err = new ErrorObjectResult(
          WrapError(payload, message != null ? message : payload.Message));
      err.StatusCode = payload.StatusCode;
      return err;
    }
  }
}