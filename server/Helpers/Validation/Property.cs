/**
 * License: MIT
 * Author: Kevin Villanueva
 * Contact: https://github.com/rhaldkhein
 */

using System.Collections.Generic;
namespace server.Helpers.Validation {
  public class Property {
    protected readonly string Name;
    protected bool Required;
    protected bool Validate = true;
    protected bool IsNull = true;
    protected List<string> Errors = new List<string>();

    public Property(string name, bool required) {
      Name = name;
      Required = required;
    }

    protected void Prepare() {
      if (!Required && IsNull) Validate = false;
      if (Validate && IsNull) Errors.Add($"Must be set");
    }

    public Result Results() {
      return new Result() {
        Name = Name,
        Errors = Errors.ToArray()
      };
    }
  }
}