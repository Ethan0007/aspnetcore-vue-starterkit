using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace server.Helpers.Validation
{
    public class StringProperty : Property
    {

        protected string Value;

        public StringProperty(string val, string name, bool required) : base(name, required)
        {
            Value = val;
            IsNull = string.IsNullOrWhiteSpace(Value);
            Prepare();
        }

        public StringProperty IsEmail()
        {
            if (!Validate) return this;
            if (!IsValidEmail(Value))
                Errors.Add("Must be a valid email");
            return this;
        }

        public StringProperty Length(int min, int max)
        {
            return this.Min(min).Max(max);
        }

        public StringProperty Min(int min)
        {
            if (!Validate) return this;
            if (Value == null || Value.Length < min)
                Errors.Add($"Must be at least {min} characters");
            return this;
        }

        public StringProperty Max(int max)
        {
            if (!Validate) return this;
            if (Value != null && Value.Length > max)
                Errors.Add($"Must not exceed {max} characters");
            return this;
        }

        public StringProperty In(string[] arr)
        {
            if (!Validate) return this;
            if (Array.IndexOf(arr, Value) == -1)
                Errors.Add($"Invalid value");
            return this;
        }

        public StringProperty Match(string str, string msg = "Must be matching")
        {
            if (!Validate) return this;
            if (Value != null && Value != str)
                Errors.Add(msg);
            return this;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                  RegexOptions.None, TimeSpan.FromMilliseconds(200));
                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();
                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}