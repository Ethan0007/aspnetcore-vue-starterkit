/**
 * License: MIT
 * Author: Kevin Villanueva
 * Contact: https://github.com/rhaldkhein
 */

namespace server.Helpers {
  public class Paging {
    public int Page { get; set; } = 1;
    public int Items { get; set; } = 10;
    public int Total { get; set; } = 0;
  }
}