/**
 * License: MIT
 * Author: Kevin Villanueva
 * Contact: https://github.com/rhaldkhein
 */

using System;

namespace server.Helpers.Validation {
  public class TimeSpanProperty : Property {
    protected TimeSpan? Value;

    public TimeSpanProperty(TimeSpan? val, string name, bool required) : base(name, required) {
      Value = val;
      IsNull = val == null;
      Prepare();
    }

    public TimeSpanProperty Range(TimeSpan min, TimeSpan max) {
      return this.Min(min).Max(max);
    }

    public TimeSpanProperty Min(TimeSpan min) {
      if (!Validate) return this;
      if (Value != null && Value < min)
        Errors.Add($"Must be {min} or above");
      return this;
    }

    public TimeSpanProperty Max(TimeSpan max) {
      if (!Validate) return this;
      if (Value != null && Value > max)
        Errors.Add($"Must be {max} or below");
      return this;
    }
  }
}