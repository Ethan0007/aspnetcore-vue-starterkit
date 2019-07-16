/**
 * License: MIT
 * Author: Kevin Villanueva
 * Contact: https://github.com/rhaldkhein
 */

namespace server.Helpers.Validation {
  public class IntProperty : Property {
    protected int? Value;

    public IntProperty(int? val, string name, bool required) : base(name, required) {
      Value = val;
      IsNull = val == null;
      Prepare();
    }

    public IntProperty Range(int min, int max) {
      return this.Min(min).Max(max);
    }/* ß */

    public IntProperty Min(int min) {
      if (!Validate) return this;
      if (Value != null && Value < min)
        Errors.Add($"Must be {min} or above");
      return this;
    }

    public IntProperty Max(int max) {
      if (!Validate) return this;
      if (Value != null && Value > max)
        Errors.Add($"Must be {max} or below");
      return this;
    }
  }
}