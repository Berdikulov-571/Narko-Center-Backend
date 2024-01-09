using System.ComponentModel.DataAnnotations;

namespace NarkoCenter.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class PhoneNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            string phoneNumber = value.ToString();

            if (System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\+998\d{9}$"))
            {
                return true;
            }

            return false;
        }
    }
}