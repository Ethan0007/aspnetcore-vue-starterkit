using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Helpers;
using server.Helpers.Errors;
using server.Helpers.Validation;
using server.Configurations;


namespace server.Controllers
{
    // <summary>
    //   Model for testing it can be modify according to user preferences
    // </summary>
    public class TestModel
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public int One { set; get; }
        public bool IsTrue { set; get; }
        public DateTime DateTime { set; get; }
        public object Object { set; get; }
    }

    [Route("api/[controller]")]
    public class ValidatorController : RouteController
    {
        // <summary>
        //   String type validator.
        //   Parameters: 
        //   property, property name , required(true/false) 
        // </summary>
        [HttpPost("[action]")]
        public IActionResult IsString([FromBody]TestModel model)
        {
            var v = new Validator();
            v.IsString(model.FirstName, "firstName", true);
            v.IsString(model.LastName, "lastName", true);
            if (v.ContainsError())
                return Error(v.AsValidationError());
            return Success();
        }

        // <summary>
        //   String type validator.
        //   Parameters: 
        //   property, property name , required(true/false), min , max
        // </summary>
        [HttpPost("[action]")]
        public IActionResult IsStringWithMinMax([FromBody]TestModel model)
        {
            var v = new Validator();
            v.IsString(model.FirstName, "firstName", true).Min(3).Max(10);
            v.IsString(model.LastName, "lastName", true).Min(5).Max(15);
            if (v.ContainsError())
                return Error(v.AsValidationError());
            return Success();
        }

        // <summary>
        //   Number type validator.
        //   Parameters: 
        //   property, property name , required(true/false) 
        // </summary>
        [HttpPost("[action]")]
        public IActionResult IsNumber([FromBody]TestModel model)
        {
            var v = new Validator();
            v.IsNumber(model.One, "one", true);
            if (v.ContainsError())
                return Error(v.AsValidationError());
            return Success();
        }

        // <summary>
        //   Boolean type validator.
        //   Parameters: 
        //   property, property name , required(true/false) 
        // </summary>
        [HttpPost("[action]")]
        public IActionResult IsBool([FromBody]TestModel model)
        {
            var v = new Validator();
            v.IsBool(model.IsTrue, "isTrue", true);
            if (v.ContainsError())
                return Error(v.AsValidationError());
            return Success();
        }

        // <summary>
        //   DateTime type validator.
        //   Parameters: 
        //   property, property name , required(true/false) 
        // </summary>
        [HttpPost("[action]")]
        public IActionResult IsDateTime([FromBody]TestModel model)
        {
            var v = new Validator();
            v.IsDateTime(model.DateTime, "dateTime", true);
            if (v.ContainsError())
                return Error(v.AsValidationError());
            return Success();
        }

        // <summary>
        //   Object type validator.
        //   Parameters: 
        //   property, property name , required(true/false) 
        // </summary>
        [HttpPost("[action]")]
        public IActionResult IsObject([FromBody]TestModel model)
        {
            var v = new Validator();
            v.IsObject(model.Object, "object", true);
            if (v.ContainsError())
                return Error(v.AsValidationError());
            return Success();
        }
    }
}