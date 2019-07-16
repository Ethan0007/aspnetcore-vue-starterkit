/**
 * License: MIT
 * Author: Kevin Villanueva
 * Contact: https://github.com/rhaldkhein
 */

using System;

namespace server.Helpers.Validation {
  public class DateTimeProperty : Property {


    protected DateTime? Value;

    public DateTimeProperty(DateTime? val, string name, bool required) : base(name, required) {
      Value = val;
      IsNull = val == null;
      Prepare();
    }

    public DateTimeProperty Range(DateTime min, DateTime max) {
      return this.Min(min).Max(max);
    }

    public DateTimeProperty Min(DateTime min) {
      if (!Validate) return this;
      if (Value != null && Value < min)
        Errors.Add($"Must be {min} or above");
      return this;
    }

    public DateTimeProperty Max(DateTime max) {
      if (!Validate) return this;
      if (Value != null && Value > max)
        Errors.Add($"Must be {max} or below");
      return this;
    }
  }
}