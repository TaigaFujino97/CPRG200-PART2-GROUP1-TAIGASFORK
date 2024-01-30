using System.Diagnostics.Eventing.Reader;

namespace TravelExpertsForm
{
    /// <summary>
    /// A static class with a variety of data validation methods
    /// </summary>
    /// <author> Michael Chessall</author>
    /// <date>1/21/2024</date>
    public static class Validator
    {
        public static string LineEnd { get; set; } = "\n";

        public static string IsPresent(string value, string name) // checks that the value is not an empty string
        {
            string msg = "";
            if (value == "")
            {
                msg = $"{name} is a required field.{LineEnd}";
            }
            return msg;
        }

        public static string IsDecimal(string value, string name) // checks that the value is convertable into decimal
        {
            string msg = "";
            if (!Decimal.TryParse(value, out _))
            {
                msg = $"{name} must be a valid decimal value.{LineEnd}";
            }
            return msg;
        }

        public static string IsDate(string value, string name) // checks that the value is convertable into datetime
        {
            string msg = "";
            if (!DateTime.TryParse(value, out _))
            {
                msg = $"{name} must be a valid date.{LineEnd}";
            }
            return msg;
        }

        public static string IsInt32(string value, string name) // checks that the value is convertable into int32
        {
            string msg = "";
            if (!Int32.TryParse(value, out _))
            {
                msg = $"{name} must be a valid integer value.{LineEnd}";
            }
            return msg;
        }

        public static string IsWithinRange(string value, string name, decimal min, // checks that the value is convertable to a decimal
            decimal max)                                                           // within range min and max
        {
            string msg = "";
            if (Decimal.TryParse(value, out decimal number))
            {
                if (number < min || number > max)
                {
                    if(min == max) { msg = $"{name} must be {min}.{LineEnd}"; }
                    else { msg = $"{name} must be between {min} and {max}.{LineEnd}"; }
                    
                }
            }
            return msg;
        }

        public static string IsWithinLength(string value, string name, int min, // checks string has length between min and max
            int max)
        {
            string msg = "";
            if (value.Length < min || value.Length > max)
            {
                if (min == max) { msg = $"{name} must be {min} characters long.{LineEnd}"; }
                else { msg = $"{name} must be between {min} and {max}.{LineEnd} characters long."; }
            }
            return msg;
        }
        // https://stackoverflow.com/a/32837759 Answer to "How to count the number of decimal places in a number"
        public static string DecimalPlacesWithinRange(string value, string name, int min, // checks that value is converable to decimal with decimal places between min and max
            int max)
        {
            string msg = "";
            if (Decimal.TryParse(value, out decimal number))
            {
                int CountDecimalDigits(decimal n) // counts the number of decimal places in a number
                {
                    return n.ToString()
                            .SkipWhile(c => c != '.')
                            .Skip(1)
                            .Count();
                }
                int decimalplaces = CountDecimalDigits(number);
                if (decimalplaces < min || decimalplaces > max)
                {
                    if (min == max) { msg = $"{name} must have {min} decimal places."; }
                    else { msg = $"{name} must have between {min} and {max} decimal places.{LineEnd}"; }
                }
            }
            return msg;
        }
    }
}