/**
 * License: MIT
 * Author: Kevin Villanueva
 * Contact: https://github.com/rhaldkhein
 */

namespace server.Helpers.Errors {
  public class Error {
    public int StatusCode = 400;
    public string Title = "Bad Request";
    public string Message = "Something is wrong with the request";
    public object Payload = null;
    public string Tag = null;
    public string Type = "Error";
  }
}