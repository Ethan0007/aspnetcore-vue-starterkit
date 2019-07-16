/**
 * License: MIT
 * Author: Kevin Villanueva
 * Contact: https://github.com/rhaldkhein
 */

using System;
using System.Collections.Generic;
using System.Linq;
using server.Helpers;
using server.Helpers.Errors;

namespace server.Helpers.Validation {
  public class Validator {
    public IEnumerable<Result> Errors { get; private set; }

    private List<Property> Validations = new List<Property>();

    /*
     * Type validations
     */

    public ObjectProperty IsObject(object val, string name, bool required = false) {
      var validation = new ObjectProperty(val, name, required);
      Validations.Add(validation);
      return validation;
    }

    public StringProperty IsString(string val, string name, bool required = false) {
      var validation = new StringProperty(val, name, required);
      Validations.Add(validation);
      return validation;
    }

    public IntProperty IsNumber(int? val, string name, bool required = false) {
      var validation = new IntProperty(val, name, required);
      Validations.Add(validation);
      return validation;
    }

    public DoubleProperty IsNumber(double? val, string name, bool required = false) {
      var validation = new DoubleProperty(val, name, required);
      Validations.Add(validation);
      return validation;
    }

    public BoolProperty IsBool(bool? val, string name, bool required = false) {
      var validation = new BoolProperty(val, name, required);
      Validations.Add(validation);
      return validation;
    }

    public DateTimeProperty IsDateTime(DateTime? val, string name, bool required = false) {
      var validation = new DateTimeProperty(val, name, required);
      Validations.Add(validation);
      return validation;
    }

    public TimeSpanProperty IsTimeSpan(TimeSpan? val, string name, bool required = false) {
      var validation = new TimeSpanProperty(val, name, required);
      Validations.Add(validation);
      return validation;
    }

    /*
     * Utils 
     */

    public bool Validate() {
      var mapped = Validations.Select(v => v.Results());
      Errors = mapped.Where(v => v.Errors.Length > 0);
      return Errors.Count() <= 0;
    }

    public bool ContainsError() {
      return !Validate();
    }

    public ValidationError AsValidationError() {
      return new ValidationError() { Payload = Errors };
    }

    public IAsyncResult<T> AsIAsyncResultError<T>() {
      return new AsyncResult<T>().Reject(AsValidationError());
    }
  }
}