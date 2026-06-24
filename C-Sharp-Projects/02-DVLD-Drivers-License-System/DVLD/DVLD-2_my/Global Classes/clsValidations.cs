using System.Text.RegularExpressions;


//namespace DVLD_2_my.Global_Classes
namespace DVLD_2_my
{
    public class clsValidations
    {


        public static bool ValidatePersonID(string digit)
        {
            return Regex.IsMatch(digit, @"^[0-9]+$");
        }

        public static bool ValidateNationalNo(string nationalNoRegex)
        {
            return Regex.IsMatch(nationalNoRegex, @"^[A-Za-z][0-9]*$");
        }

        public static bool ValidateName(string nameRegex)
        {
            return Regex.IsMatch(nameRegex, @"^[a-zA-Z_-]+$");
        }

        public static bool ValidateGender(string gender)
        {
            return Regex.IsMatch(gender, @"^[fFmM]$");
        }

        public static bool ValidateNationality(string nationality)
        {
            return Regex.IsMatch(nationality, @"^[a-zA-Z]+$");
        }

        public static bool ValidateEmail(string emailRegex)
        {
            return Regex.IsMatch(emailRegex, @"^[a-zA-Z0-9._+-]+@[a-zA-Z0-9.-]+\.com$");
        }

        public static bool ValidatePhone(string phone)
        {
            return Regex.IsMatch(phone, @"^[0-9-+]+$");
        }

        public static bool ValidateAddress(string address)
        {
            return Regex.IsMatch(address, @"^[A-Za-z0-9\s,.-]+$");
        }

        public static bool ValidateInteger(string number)
        {
            var pattern = @"^[0-9]*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(number);
        }

        public static bool ValidateFloat(string number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            var regex = new Regex(pattern);

            return regex.IsMatch(number);
        }

        public static bool IsNumber(string number)
        {
            return (ValidateFloat(number) || ValidateInteger(number));
        }
    }

}
