/**
 * License: MIT
 * Author: Kevin Villanueva
 * Contact: https://github.com/rhaldkhein
 */

namespace server.Helpers.Validation {
  public class BoolProperty : Property {

    protected bool? Value;

    public BoolProperty(bool? val, string name, bool required) : base(name, required) {
      Value = val;
      IsNull = val == null;
      Prepare();
    }

    public BoolProperty True() {
      if (!Validate) return this;
      if (Value != null && Value != true)
        Errors.Add($"Must be true");
      return this;
    }

    public BoolProperty False() {
      if (!Validate) return this;
      if (Value != null && Value != false)
        Errors.Add($"Must be false");
      return this;
    }
  }
}