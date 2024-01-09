using System.ComponentModel.DataAnnotations;

namespace NarkoCenter.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class LengthAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            string text = value.ToString();

            if (System.Text.RegularExpressions.Regex.IsMatch(text, @"^.{5,}$"))
            {
                return true;
            }

            return false;
        }
    }
}