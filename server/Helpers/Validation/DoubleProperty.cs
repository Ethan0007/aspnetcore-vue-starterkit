/**
 * License: MIT
 * Author: Kevin Villanueva
 * Contact: https://github.com/rhaldkhein
 */

namespace server.Helpers.Validation {
  public class DoubleProperty : Property {
    protected double? Value;
    public DoubleProperty(double? val, string name, bool required) : base(name, required) {
      Value = val;
      IsNull = val == null;
      Prepare();
    }

    public DoubleProperty Range(double min, double max) {
      return this.Min(min).Max(max);
    }

    public DoubleProperty Min(double min) {
      if (!Validate) return this;
      if (Value != null && Value < min)
        Errors.Add($"Must be {min} or above");
      return this;
    }

    public DoubleProperty Max(double max) {
      if (!Validate) return this;
      if (Value != null && Value > max)
        Errors.Add($"Must be {max} or below");
      return this;
    }
  }
}