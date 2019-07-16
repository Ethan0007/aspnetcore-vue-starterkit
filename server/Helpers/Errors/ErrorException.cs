/**
 * License: MIT
 * Author: Kevin Villanueva
 * Contact: https://github.com/rhaldkhein
 */

namespace server.Helpers.Errors {
  public class ErrorException : System.Exception {
    public int StatusCode = 500;
  }
}