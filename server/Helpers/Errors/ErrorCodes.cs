/**
 * License: MIT
 * Author: Kevin Villanueva
 * Contact: https://github.com/rhaldkhein
 */

namespace server.Helpers.Errors {

  // 400 error types
  public class BadRequest : Error {
    public BadRequest() {
      StatusCode = 400;
      Title = "Bad Request";
      Message = "Something is wrong with the request";
    }
  }
  public class Unauthorized : Error {
    public Unauthorized() {
      StatusCode = 401;
      Title = "Not Authorized";
      Message = "A valid authentication credentials are required";
    }
  }
  public class Forbidden : Error {
    public Forbidden() {
      StatusCode = 403;
      Title = "Forbidden";
      Message = "Request is not allowed";
    }
  }
  public class NotFound : Error {
    public NotFound() {
      StatusCode = 404;
      Title = "Not Found";
      Message = "Did not found anything matching the request";
    }
  }
  public class Conflict : Error {
    public Conflict() {
      StatusCode = 409;
      Title = "Conflict";
      Message = "Could not be completed due to a conflict";
    }
  }
  public class ValidationError : Error {
    public ValidationError() {
      StatusCode = 400;
      Title = "Validation Failed";
      Message = "The form contains invalid fields";
    }
  }

  // 500 error types
  public class Unavailable : Error {
    public Unavailable() {
      StatusCode = 503;
      Title = "Not Available";
      Message = "Request is currently unavailable";
    }
  }

  // Custom error types
  public class RouteNotFound : Error {
    public RouteNotFound() {
      StatusCode = 404;
      Title = "Route Not Found";
      Message = "No route for the request";
    }
  }
  public class NotImplemented : Error {
    public NotImplemented() {
      StatusCode = 501;
      Title = "Not Implemented";
      Message = "Functionality not supported yet";
    }
  }
}